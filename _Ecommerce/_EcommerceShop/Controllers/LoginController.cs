using _EcommerceShop.Common;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace _EcommerceShop.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }
        // GET: Login
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            var cmd = new UserLoginRepository();
            var result = cmd.Execute(email,Encryptor.MD5Hash(password));
            if (result)
            {
                var userSession = new UserLogin();
                var user = new UserGetByIdRepository().GetUserByEmail(email);
                userSession.UserId = user.ID;
                userSession.Name = user.FirstName +" "+ user.MiddleName + " " + user.LastName;
                Session.Add(CommonConstants.USER_SESSION, userSession);
                if (user.Level == 1)
                {
                    return RedirectToAction("AdminIndex", "AdminHome","Admin");
                }
                else if(user.Level == 0)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }
            return View();
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(string first_name,string middle_name,string last_name,string email,string password,string repassword,string phone,DateTime dateOfBirth,string address,string avatar,int gender)
        {
            if ( password == repassword)
            {

                long code = new Random().Next(000000, 999999);
                int check = new UserCheckRepository().Execute(email);
                if (check == 0)
                {
                    var cmd = new UserInsertRepository();
                    bool res = cmd.Execute(first_name, middle_name, last_name, email, Encryptor.MD5Hash(password), code, dateOfBirth, address, avatar, 0, gender, phone);
                    if (res)
                    {
                        SmtpClient smtp = new SmtpClient();
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = true;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.Credentials = new System.Net.NetworkCredential("k43ecommerce@gmail.com", "Ecommerce1999");

                        MailMessage msg = new MailMessage();
                        msg.To.Add(email);
                        msg.Subject = "Mã kích hoạt tài khoản của bạn!!";
                        msg.Body = "Gửi " + first_name + " " + middle_name + " " + last_name + ", Mã kích hoạt tài khoản của bạn là: " + code + "  \n\nCảm ơn bạn!";
                        msg.From = new MailAddress("k43ecommerce@gmail.com");
                        smtp.Send(msg);
                        var user = new UserGetByIdRepository().GetUserByEmail(email);
                        string Action = "Confirm/" + user.ID;
                        return RedirectToAction(Action, "Login");
                    }
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
            return View();
        }

        public ActionResult Confirm(long id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Confirm(long code,long id)
        {
            var cmd = new UserConfirmRepository();
            bool res = cmd.Execute(code,1, id);
            if (res)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
    }
}