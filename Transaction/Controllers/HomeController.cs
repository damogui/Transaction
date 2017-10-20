using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using MySqlHelper = Dao.MySqlHelper;

namespace Transaction.Controllers
{
    public class HomeController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["ourConn"].ConnectionString;
        //MySqlHelper
        public ActionResult Index()
        {

          


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }




        public JsonResult OptionMysql()
        {

            MySqlConnection conn =
              new MySqlConnection(connectionString);
            conn.Open();
            MySqlTransaction tran = conn.BeginTransaction();
            object obj = MySqlHelper.ExecuteScalar(connectionString, CommandType.Text, "SELECT  age FROM Test   WHERE id=2");
            int age = Convert.ToInt32(obj) + 1;
            int num1 = MySqlHelper.ExecuteNonQuery(tran, CommandType.Text, "INSERT INTO `ourtool`.`Test` ( `Name`, `CreateTime`, `Age`) VALUES ('梁朝伟', NOW(), 11) ;");
            int num2 = MySqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, "UPDATE  Test  SET  age="+ age + " WHERE id=2");

            int num3 = MySqlHelper.ExecuteNonQuery(tran, CommandType.Text, "INSERT INTO `ourtool`.`Test` ( `Name`, `CreateTime`, `Age`) VALUES ('周润发', NOW(), 11) ;");


            try
            {
                tran.Commit();
                conn.Dispose();


            }
            catch (Exception ex)
            {
                tran.Rollback();
                string msg = ex.Message;

            }

            JsonResult jsonResult=new JsonResult();
            jsonResult.Data = string.Format("{0}-{1}-{2}-{3}",obj,num1,num2,num3);

            return jsonResult;

        }
    }
}