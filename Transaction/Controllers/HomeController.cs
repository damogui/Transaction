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
            
            MySqlConnection conn =
                new MySqlConnection(
                    "Database=xini2ng;Data Source=127.0.0.1;User Id=root;Password=root;pooling=false;CharSet=utf8");
            MySqlTransaction tran= conn.BeginTransaction();
            MySqlHelper.ExecuteNonQuery(tran, CommandType.Text,"");


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
    }
}