using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoriesTest.AppCode
{
    public enum CustodialRole
    {
        CP=1,
        NCP
    }

    public class User
    {
        public CustodialRole CustodyRole
        {
            get;
            set;
        }
    }
}