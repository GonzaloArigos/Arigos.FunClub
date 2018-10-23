using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FunClub.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public string GetDashboard()
        {
            return JsonConvert.SerializeObject(BLL.DashboardBLL.GetDashBoard(User.Identity.Name), Formatting.None,
                     new JsonSerializerSettings()
                     {
                         ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                     });
        }

    }
}