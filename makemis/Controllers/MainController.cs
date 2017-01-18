using makemis.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace makemis.Controllers {
    public class MainController : ControllerTemplate {
        // GET: Main
        [AllowAnonymous]
        public ActionResult Index() {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Error() {
            try {
                this.LogException(Server.GetLastError());
            } catch { }
            return View();
        }
    }
}