using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            IEnumerable<MvcPersonModel> empList;
            HttpResponseMessage response = GlobalVariables.
                WebApiClient.
                GetAsync("Person").
                Result;
            empList = response.Content.ReadAsAsync<IEnumerable<MvcPersonModel>>().Result;
            return View(empList);
        }
    }
}