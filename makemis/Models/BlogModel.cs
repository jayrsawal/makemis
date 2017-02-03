using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace makemis.Models {
    public class BlogModel {

        public BlogModel() {
            this.Active = false;
            this.Nav = false;
            this.NavTitle = "";
            this.Title = "";
            this.Caption = "";
            this.Html = "";
            this.BlogTypeId = "";
            this.PublishDate = DateTime.Now;
        }

        public string Id { get; set; }
        public bool Active { get; set; }
        public bool Nav { get; set; }
        public string NavTitle { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public string Html { get; set; }
        public DateTime PublishDate { get; set; }
        public string BlogTypeId { get; set; }

        public void SerializeFromXml( XElement nd ) { 
            if(nd.Element("active").Value != "") {
                this.Active = true;
            }

            if (nd.Element("nav").Value != "") {
                this.Nav = true;
            }

            this.Id = nd.Element("id").Value;
            this.NavTitle = nd.Element("navtitle").Value;
            this.Title = nd.Element("title").Value;
            this.Caption = nd.Element("caption").Value;
            this.Html = nd.Element("html").Value;
            this.BlogTypeId = nd.Element("blogtypeid").Value;

            DateTime dt;
            DateTime.TryParse(nd.Element("NavTitle").Value, out dt);
            this.PublishDate = dt;
        }

    }
}