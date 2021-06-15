using LoginTask.DBModel;
using LoginTask.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginTask.Controllers
{
    public class AccountController : Controller
    {
        UserDBEntities objUserDBEntities = new UserDBEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            UserModel objuserModel = new UserModel();
            return View(objuserModel);
        }
        [HttpPost]

        public ActionResult Register(UserModel objUserModel)
        {
            if (ModelState.IsValid)
            {
                if (!objUserDBEntities.Users.Any(m => m.Email == objUserModel.Email))
                { 
                    User objUser = new DBModel.User();
            objUser.CreatedOn = DateTime.Now;
            objUser.Email = objUserModel.Email;
            objUser.FirstName = objUserModel.FirstName;
            objUser.LastName = objUserModel.LastName;
            objUser.Password = objUserModel.Password;
            objUserDBEntities.Users.Add(objUser);


            objUserDBEntities.Users.Add(objUser);
            objUserDBEntities.SaveChanges();
                objUserModel = new UserModel();
            objUserModel.SuccessMessage = "User is Succesfully Added";
                return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Error", "Email is already exists!");
                    return View();
                }
            }
            return View();
        }



        //[HttpGet]
        //public JsonResult GetddlStructure(string value, string load)
        //{
        //    //Functional
        //    var User = Session["User"] as LoginModel;
        //    var UserId = User != null ? User.Email : 0;
        //    var apiInput = new ApiInput
        //    {
        //        ApiPath = "Content/mytemplate/" + value + "/" + UserId
        //    };
        //    var CSRApi = new CSRApi();
        //    var result = CSRApi.ApiGet(apiInput);
        //    var FunctionalList = JsonConvert.DeserializeObject<List<InfraFunctionalColl>>(Convert.ToString(result)) ??
        //                                   new List<InfraFunctionalColl>();
        //    return Json(FunctionalList, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Login()
        {

            LoginModel objLoginModel = new LoginModel();
            return View(objLoginModel);
        }
        [HttpPost]

        public ActionResult Login(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {
                if (objUserDBEntities.Users.Where(m => m.Email == objLoginModel.Email && m.Password == objLoginModel.Password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", " Incorrect Username or Password");
                    return View();
                }

                else
                {
                    Session["Email"] = objLoginModel.Email;
                   return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return View("Login");
        }
    }
}