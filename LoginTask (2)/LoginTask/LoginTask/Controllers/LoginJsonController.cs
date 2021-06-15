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
    public class LoginJsonController : Controller
    {
        // GET: LoginJson
                //[HttpGet]
                //public JsonResult GetddlStructure(string value, string load)
                //{
                //    //Functional
                //    var User = Session["Email"] as LoginModel;
                //    var UserId = User != null ? User.Email : 0;
                //    var apiInput = new ApiInput
                //    {
                //        ApiPath = "Content/mytemplate/userdatas.json
                //    };
                //    var CSRApi = new CSRApi();
                //    var result = CSRApi.ApiGet(apiInput);
                //    var FunctionalList = JsonConvert.DeserializeObject<List<InfraFunctionalColl>>(Convert.ToString(result)) ??
                //                                   new List<InfraFunctionalColl>();
                //    return Json(FunctionalList, JsonRequestBehavior.AllowGet);
                //}
        //    }
       // }


        public JsonResult Index1()
        {
            JObject o1 = JObject.Parse(System.IO.File.ReadAllText(@"~\Content\mytemplate\users.json"));

            // read JSON directly from a file
            using (StreamReader file = System.IO.File.OpenText(@"~\Content\mytemplate\users.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
            }
            return JsonToken();
        }

        private JsonResult JsonToken()
        {
            throw new NotImplementedException();
        }

        private JsonResult JsonResult()
        {
            throw new NotImplementedException();
        }

        public ActionResult Index2()
        {
            JObject videogameRatings = new JObject(
    new JProperty("Halo", 9),
    new JProperty("Starcraft", 9),
    new JProperty("Call of Duty", 7.5));

            System.IO.File.WriteAllText(@"~\Content/mytemplate\users.json", videogameRatings.ToString());

            // write JSON directly to a file
            using (StreamWriter file = System.IO.File.CreateText(@"~\Content\mytemplate\users.json"))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                videogameRatings.WriteTo(writer);
            }
            return View();
        }
    }
}