using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpayTest.Models;

namespace EpayTest.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult EpayTest()
        {
            ViewBag.Message = "Test ATM";

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TestEpay testPayInfo )
        {
            int userInput = testPayInfo.UserInput;
            ViewBag.UserOutPut10 = Get10s(userInput) + " * 10";

            if (userInput >= 50)
            {
                int CalValue_50_Mod = userInput % 50;
                int userOutPut50s = Get50s(userInput - CalValue_50_Mod);
                ViewBag.UserOutPut50 = userOutPut50s + " * 50";
                if (userOutPut50s >= 2)
                {
                    int numOf_10s = 5;
                    if(CalValue_50_Mod >=10)
                    {
                        numOf_10s = numOf_10s + Get10s(CalValue_50_Mod);
                    }
                    ViewBag.UserOutPut50_10 = userOutPut50s - 1 + " * 50 +" +  numOf_10s + " * 10";
                }
              
                if (CalValue_50_Mod != 0)
                {
                    ViewBag.UserOutPut50 = ViewBag.UserOutPut50 + " + " + Get10s(CalValue_50_Mod) + " * 10";
                }
            }
            if (userInput >= 100)
            {
                int CalValue_100_Mod = userInput % 100;
                ViewBag.UserOutPut100 = Get100s(userInput - CalValue_100_Mod) + " * 100";
                ViewBag.UserOutPut100_10 = ViewBag.UserOutPut100;


                if (CalValue_100_Mod >= 50 )
                {
                   
                    int CalValue_50_Mod = CalValue_100_Mod % 50;
                    int Cal_50s = CalValue_100_Mod - CalValue_50_Mod;
                    ViewBag.UserOutPut100 = ViewBag.UserOutPut100 +"+ "+ Get50s(Cal_50s) + " * 50";
                    if (CalValue_50_Mod != 0)
                    {
                        if(CalValue_50_Mod >= 10)
                        ViewBag.UserOutPut100 = ViewBag.UserOutPut100 + " + " + Get10s(CalValue_50_Mod) + " * 10";
                        if(CalValue_100_Mod >= 10)
                        ViewBag.UserOutPut100_10 = ViewBag.UserOutPut100_10 + " + " + Get10s(CalValue_100_Mod) + " * 10";
                    }
                    else
                    {
                        if(CalValue_100_Mod >=10)
                        ViewBag.UserOutPut100_10 = ViewBag.UserOutPut100_10 + " + " + Get10s(CalValue_100_Mod) + " * 10";
                    }
                }

                else
                {
                    if (CalValue_100_Mod >=10)
                    ViewBag.UserOutPut100 = ViewBag.UserOutPut100 + " + " + Get10s(CalValue_100_Mod) + " * 10";
                    ViewBag.UserOutPut100_10 = "";
                   

                }
            }
          

            return View();
        }
        public int Get10s(int inPutval)
        {
            return inPutval / 10;

        }
        public int Get50s(int inPutval)
        {
            return inPutval / 50;

        }
        public int Get100s(int inPutval)
        {
            return inPutval / 100;

        }
        
    }
}