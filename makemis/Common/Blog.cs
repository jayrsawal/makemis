using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;
using makemis.Models;
using AdoLib;

namespace makemis.Common {
    public class Blog {
        Database db;

        public Blog(Database _db) {
            this.db = _db;
        }


        public List<BlogModel> GetBlogs(string strBlogTypeID = null) {
            List<BlogModel> blogs = new List<BlogModel>();
            SqlCommand cmd = new SqlCommand();

            string strCommand = @"select * from blog";
            if (strBlogTypeID != null) {
                strCommand += " where blogtypeid=@id";
                cmd.Parameters.AddWithValue("@blogtypeid", strBlogTypeID);
            }
            cmd.CommandText = strCommand;
            XDocument xmlBlog = db.ExecQuery(cmd, "Blog");

            foreach (XElement nd in xmlBlog.Descendants("Blog")) {
                BlogModel blog = new BlogModel();
                blog.SerializeFromXml(nd);
                blogs.Add(blog);
            }

            return blogs;
        }



        public BlogModel GetBlog(string strId) {
            BlogModel blog = new BlogModel();

            SqlCommand cmd = new SqlCommand(@"select * from blog where id=@id");
            cmd.Parameters.AddWithValue("@id", strId);
            XElement nd = db.ExecQueryElem(cmd, "Blog");

            blog.SerializeFromXml(nd);
            return blog;
        }



        public bool AddNewBlog(BlogModel blog) {
            SqlCommand cmd = new SqlCommand(@"
insert into blog(nav, navtitle, title, caption, html, blogtypeid, active, publishdate)
values(@nav, @navtitle, @title, @caption, @html, @blogtypeid, @active, @publishdate)
");
            if (blog.Nav) {
                cmd.Parameters.AddWithValue("@nav", 1);
            } else {
                cmd.Parameters.AddWithValue("@nav", DBNull.Value);
            }

            if (blog.Active) {
                cmd.Parameters.AddWithValue("@active", 1);
            } else {
                cmd.Parameters.AddWithValue("@active", DBNull.Value);
            }

            cmd.Parameters.AddWithValue("@navtitle", blog.NavTitle);
            cmd.Parameters.AddWithValue("@title", blog.Title);
            cmd.Parameters.AddWithValue("@caption", blog.Caption);
            cmd.Parameters.AddWithValue("@html", blog.Html);
            cmd.Parameters.AddWithValue("@blogtypeid", blog.BlogTypeId);
            cmd.Parameters.AddWithValue("@publishdate", blog.PublishDate);

            try {
                db.ExecNonQuery(cmd);
            } catch {
                return false;
            }
            return true;
        }



        public bool EditBlog(BlogModel blog) {
            SqlCommand cmd = new SqlCommand(@"
update blog set active=@active
, nav=@nav
, navtitle=@navtitle
, title=@title
, caption=@caption
, html=@html
, blogtypeid=@blogtypeid
, publishdate=@publishdate
where id=@id
");
            cmd.Parameters.AddWithValue("@id", blog.Id);

            if (blog.Nav) {
                cmd.Parameters.AddWithValue("@nav", 1);
            } else {
                cmd.Parameters.AddWithValue("@nav", DBNull.Value);
            }

            if (blog.Active) {
                cmd.Parameters.AddWithValue("@active", 1);
            } else {
                cmd.Parameters.AddWithValue("@active", DBNull.Value);
            }

            cmd.Parameters.AddWithValue("@navtitle", blog.NavTitle);
            cmd.Parameters.AddWithValue("@title", blog.Title);
            cmd.Parameters.AddWithValue("@caption", blog.Caption);
            cmd.Parameters.AddWithValue("@html", blog.Html);
            cmd.Parameters.AddWithValue("@blogtypeid", blog.BlogTypeId);
            cmd.Parameters.AddWithValue("@publishdate", blog.PublishDate);
            try {
                db.ExecNonQuery(cmd);
            } catch {
                return false;
            }
            return true;
        }



        public bool DeleteBlog(string strId) {
            SqlCommand cmd = new SqlCommand(@"
update blog set active=null where id=@id
");
            cmd.Parameters.AddWithValue("@id", strId);

            try {
                db.ExecNonQuery(cmd);
            } catch {
                return false;
            }
            return true;
        }

    }
}