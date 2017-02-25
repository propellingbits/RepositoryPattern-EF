using System;
using Framework.Data.Repository;
using ChildSupport.Domain;

namespace ChildSupport.Dal.Specification
{
    public class EmployeeSpecification
    {
        public static Specification<Employee> EmployeeJoinedEarlierThanThis(DateTime dateTime)
        {
            return new Specification<Employee>(e => e.HireDate > dateTime);
        }

        public static Specification<Employee> EmployeeJoinedLaterThanThis(DateTime dateTime)
        {
            return new Specification<Employee>(e => e.HireDate < dateTime);
        }

        public static Specification<Employee> EmployeeByJobTitle(string jobTitle)
        {
            return new Specification<Employee>(e => e.JobTitle == jobTitle);
        }
    }
}
