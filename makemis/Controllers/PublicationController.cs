﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using makemis.Models;
using makemis.Common;

namespace makemis.Controllers
{
    public class PublicationController : ControllerTemplate
    {
        // GET: Publication
        [AllowAnonymous]
        public ActionResult Get(string id) {
            //string id = Request.Params["name"].ToString();
            Blog b = new Blog(this.db);
            BlogModel blog = b.GetBlog(id);
            ViewBag.Blog = blog;
            ViewBag.Page = "M. Shimabukuro";
            ViewBag.Title = blog.NavTitle;
            this.PageViewLog(Request);
            return View("Index");
        }

        [AllowAnonymous]
        public ActionResult Publication() {
            ViewBag.Page = "M. Shimabukuro";
            ViewBag.Title = "Publicatixons";
            this.PageViewLog(Request);
            return View();
        }

        [AllowAnonymous]
        public ActionResult Application() {
            ViewBag.Page = "M. Shimabukuro";
            ViewBag.Title = "Publications";
            this.PageViewLog(Request);
            return View();
        }
    }
}