using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.IO;
using System.Runtime.Caching;

namespace RepositoriesTest.AppCode
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnLoad(e);
            this.MasterPageFile = "~/MasterPage/Site.Master";
        }             
    }
}