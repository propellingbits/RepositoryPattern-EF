using System.Linq;
using ChildSupport.Domain;
using Framework.Data.Repository;

namespace ChildSupport.Dal
{   
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository        
    {   
        //Explict public default constructor
        public EmployeeRepository(IRepository<Employee> genericEmployeeRepository) : base(genericEmployeeRepository)
        {
            
        }        

        /// <summary>
        /// Update the details of the employee
        /// </summary>
        /// <param name="employee">employee object to update.</param>
        /// <returns>The count that indicates no of rows affected in the underlying persistence storage</returns>
        /*public void UpdateEmployee(Employee employee)
        {
            //_genericAccountRepository.Attach(new ACCOUNT() {ACCOUNTID = account.ACCOUNTID });

            _genericEmployeeRepository.Update(employee);    

            //int count = 0;

            //using (UnitOfWorkScope unitOfWorkScope = new UnitOfWorkScope(ScopeOptions.SaveAllWhenScopeEnds))
            //{
            //    unitOfWorkScope.AddObjectSource(_genericEmployeeRepository);

            //    _genericEmployeeRepository.Update(Employee);

            //    foreach (Order_Detail orderDetail in Employee.Order_Details)
            //    {
            //        _genericOrderDetailRepository.Update(orderDetail);
            //    }

            //    count = unitOfWorkScope.Complete();

            //}


            //return count;
        }*/        
    }
}
