using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RepositoriesTest.AppCode;

namespace RepositoriesTest.UserControls
{
    public partial class NavigationButtons : System.Web.UI.UserControl
    {
        public Button Prev
        {
            get { return btnPrev; }
        }

        public Button Next
        {
            get { return btnNext; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
                       
        }
    }
}