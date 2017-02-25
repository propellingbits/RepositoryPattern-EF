using System;
using System.Collections.Generic;
using ChildSupport.Dal;
using ChildSupport.Domain;
using RepositoriesTest.AppCode;

namespace RepositoriesTest
{
    public partial class Default1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IEmployeeRepository employeeRepository = (IEmployeeRepository)Application[Repositories.EmployeeRepository];

            Employee emp;
            
            IEnumerable<KeyValuePair<string, object>> entityKeyValues = new KeyValuePair<string, object>[] {
            new KeyValuePair<string, object>("BusinessEntityID", 1) };

            emp = employeeRepository.GetByKey(entityKeyValues);
        }
    }
}