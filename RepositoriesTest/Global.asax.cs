using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using Framework.Data.Repository;
using ChildSupport.Domain;
using ChildSupport.Dal;
using System.Workflow.Runtime;
using System.Workflow.Activities;

namespace RepositoriesTest
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            new UnityBootStrapper();

            //we can either register repositories using the following call or keep on 
            //using the web.config approach
            // we can discontinue storing the repositories in the application variable,
            // instead we can get the instance by calling servicelocation.getinstance
            //RepositoriesInitializer.RegisterInstances();

            IEmployeeRepository employeeRepository = new EmployeeRepository(ServiceLocator.Current.GetInstance<IRepository<Employee>>("EmployeeRepository"));
            
            Application[Repositories.EmployeeRepository] = employeeRepository;            
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            Application[Repositories.EmployeeRepository] = null;
        }
    }
}