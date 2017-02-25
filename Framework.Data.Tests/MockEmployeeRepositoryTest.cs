using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MbUnit.Framework;
using Moq;
using ChildSupport.Domain;
using ChildSupport.Dal;
using Framework.Data.Repository;

namespace Framework.Data.Tests
{
    [TestFixture]
    public class MockEmployeeRepositoryTest
    {
        private Mock<IRepository<Employee>> _employeeRepositoryMock;
        private List<Employee> _employeeList;        
        private static int _empId1 = 10001, _empId2 = 10002, _empId3 = 10003;
        private static int _newEmpId = 11000;
        private EmployeeRepository _employeeRepository;

        public MockEmployeeRepositoryTest()
        {
            _employeeRepositoryMock = new Mock<IRepository<Employee>>(MockBehavior.Strict);            

            //Collection Initializer
            //Simulate the persistent in memory storage for the employee Repository Tests
            _employeeList = new List<Employee>() { new Employee{ BusinessEntityID = _empId1, Gender = "M"},
                                                   new Employee{ BusinessEntityID = _empId2, Gender = "M"},
                                                   new Employee { BusinessEntityID = _empId3, Gender = "F"}};

            //Setup expectation for the Dispose method of the IRepository<Employee> mock
            //_employeeRepositoryMock.Setup(er => er.Dispose());
            //Setup expectation for the Create method of the IRepository<Employee> mock
            _employeeRepositoryMock.Setup(er => er.Create()).Returns(new Employee());
            //Setup expectation for the Add method of the IRepository<Employee> mock
            _employeeRepositoryMock.Setup(er => er.Add(It.Is<Employee>(e => !string.IsNullOrEmpty(e.BusinessEntityID.ToString())))).Callback((Employee e) =>
                {
                    _employeeList.Add(e);
                }
            ).Returns(_newEmpId);


            //Setup expectation for the Update method of the IRepository<Employee> mock.
            _employeeRepositoryMock.Setup(er => er.Update(It.Is<Employee>(e => !string.IsNullOrEmpty(e.BusinessEntityID.ToString()) && _employeeList.Exists(e1 => e1.BusinessEntityID == e.BusinessEntityID)))).Callback
                ((Employee e) =>
                {
                    //update the employee object in the memory Employee list storage
                    Employee tempEmployee = _employeeList.SingleOrDefault(e1 => e1.BusinessEntityID == e.BusinessEntityID);

                    tempEmployee.BirthDate = e.BirthDate;                    
                    tempEmployee.CurrentFlag = e.CurrentFlag;
                    tempEmployee.EmployeeDepartmentHistories = e.EmployeeDepartmentHistories;
                    tempEmployee.EmployeePayHistories = e.EmployeePayHistories;
                    tempEmployee.Gender = e.Gender;                    
                    tempEmployee.HireDate = e.HireDate;
                    tempEmployee.JobCandidates = e.JobCandidates;
                    tempEmployee.JobTitle = e.JobTitle;
                    tempEmployee.LoginID = e.LoginID;
                    tempEmployee.MaritalStatus = e.MaritalStatus;
                    tempEmployee.ModifiedDate = e.ModifiedDate;
                    tempEmployee.NationalIDNumber = e.NationalIDNumber;
                    tempEmployee.OrganizationLevel = e.OrganizationLevel;
                    tempEmployee.Person = e.Person;
                    tempEmployee.PurchaseOrderHeaders = e.PurchaseOrderHeaders;
                    tempEmployee.SalariedFlag = e.SalariedFlag;
                    tempEmployee.SalesPerson = e.SalesPerson;
                    tempEmployee.SickLeaveHours = e.SickLeaveHours;
                    tempEmployee.VacationHours = e.VacationHours;
                }
            );

            //Setup expectation for the delete method of te IRepository<Employee> mock.
            _employeeRepositoryMock.Setup(er => er.Delete(It.Is<Employee>
                (e => !string.IsNullOrEmpty(e.BusinessEntityID.ToString()) && _employeeList.Exists(e1 => e1.BusinessEntityID == e.BusinessEntityID)))).Callback
                ((Employee e) =>
                {
                    //remove the employee object from the memory employee list storage
                    int index = _employeeList.FindIndex(e1 => e1.BusinessEntityID == e.BusinessEntityID);

                    if (index > -1)
                        _employeeList.RemoveAt(index);
                }
            );  

            //Setup expectation for the Save method of the IRepository<Employee> mock.
           // _employeeRepositoryMock.Setup(er => er.Save());
                        
            _employeeRepository = new EmployeeRepository(_employeeRepositoryMock.Object);
        }

        /// <summary>
        /// Return the POCO employee instance with specified Employee id
        /// </summary>

        [Test]
        public void TestGetEmployeeByKey()
        {
            //Setup expectation for the Find method of the EmployeeRepository mock to return employee whose id match the input parameter.
            Employee emp = new Employee();
            emp.BusinessEntityID = _empId1;
            _employeeRepositoryMock.Setup(er => er.GetByKey(It.Is<Employee>(e => !string.IsNullOrEmpty(e.BusinessEntityID.ToString())))).Returns(_employeeList.Where(li => li.BusinessEntityID == _empId1).SingleOrDefault<Employee>());
                        
            var employee = _employeeRepository.GetByKey(emp);
            Assert.AreEqual(_empId1,employee.BusinessEntityID);
        }

        /// <summary>
        /// Return all the POCO Employee instance.
        /// </summary>
        [Test]
        public void TestGetAll()
        {
            //Setup expectation for the Find method of the EmployeeRepository mock to return all employees.
            _employeeRepositoryMock.Setup(er => er.Find(It.IsAny<Expression<Func<Employee, bool>>>())).Returns(_employeeList.AsEnumerable<Employee>());
            IEnumerable<Employee> employees = _employeeRepository.GetAll();
            
            Assert.AreEqual(3, employees.Count<Employee>());
        }

        /// <summary>
        /// Return an POCO Employee instance from the object services.
        /// </summary>
        [Test]
        public void TestCreateEmployeeEntity()
        {
            ////Create the proxy Employee entity object from the object context
            Employee employee = _employeeRepository.Create();            
            Assert.IsNotNull(employee);
        }

        /// <summary>
        /// Create a new employee with our POCO Employee instance.
        /// </summary>
        [Test]
        public void TestCreateNewEmployee()
        {
            //Create the proxy Employee entity object from the object context
            Employee employee = _employeeRepository.Create();

            employee.BirthDate = DateTime.Now;
            employee.BusinessEntityID = _newEmpId;
            employee.CurrentFlag = true;
            employee.EmployeeDepartmentHistories = null;
            employee.EmployeePayHistories = null;
            employee.Gender = "M";
            employee.HireDate = DateTime.Now;
            employee.JobCandidates = null;
            employee.JobTitle = "er";
            employee.LoginID = "asap";
            employee.MaritalStatus = "single";
            employee.ModifiedDate = DateTime.Now;
            employee.NationalIDNumber = "123456";
            employee.OrganizationLevel = 1;
            employee.Person = null;
            employee.PurchaseOrderHeaders = null;
            employee.SalariedFlag = true;
            employee.SalesPerson = null;
            employee.SickLeaveHours = 12;
            employee.VacationHours = 13;

            long empId = _employeeRepository.Add(employee);

            Assert.IsTrue(empId == _newEmpId);         
        }

        [Test]
        public void TestUpdateEmployee()
        {
            //Setup expectation for the Find method of the EmployeeRepository mock to return employee whose contact name match the input parameter.
            Employee emp = new Employee();
            emp.BusinessEntityID = _empId1;

            _employeeRepositoryMock.Setup(er => er.GetByKey(It.Is<Employee>(e => !string.IsNullOrEmpty(e.BusinessEntityID.ToString())))).Returns(_employeeList.Where(li => li.BusinessEntityID == _empId1).SingleOrDefault<Employee>());

            Employee employee = _employeeRepository.GetByKey(emp);

            employee.VacationHours = 100;
       
            _employeeRepository.Update(employee);

        //    //retrieve the employee to compare
            employee = _employeeRepository.GetByKey(emp);

            Assert.IsTrue(employee.VacationHours == 100, "Vacation Hours not equal to 100");
        }

        /// <summary>
        /// Delete the employee by employee id.
        /// </summary>
        [Test]
        public void TestDeleteEmployeeByEmployeeId()
        {
            //delete employee by employee id
            Employee emp = new Employee();
            emp.BusinessEntityID = _empId3;

            //Setup expectation for the Find method of the EmployeeRepository mock to return employee whose contact name match the input parameter.
            _employeeRepositoryMock.Setup(er => er.GetByKey(It.Is<Employee>(e => !string.IsNullOrEmpty(e.BusinessEntityID.ToString())))).Returns(_employeeList.Where(li => li.BusinessEntityID == _empId3).SingleOrDefault<Employee>());

            _employeeRepository.Delete(emp);
            Assert.IsTrue(_employeeRepository.GetByKey(emp).BusinessEntityID == _empId3, "Employee was not deleted.");
        }

        /// <summary>
        /// Delete the employee by the POCO employee instance.
        /// </summary>
        [Test]
        public void TestDeleteEmployeeByEmployeeObject()
        {
            Employee emp = new Employee();
            emp.BusinessEntityID = _empId3;
            //Setup expectation for the Find method of the EmployeeRepository mock to return employee whose contact name match the input parameter.
            _employeeRepositoryMock.Setup(er => er.GetByKey(It.Is<Employee>(e => !string.IsNullOrEmpty(e.BusinessEntityID.ToString())))).Returns(_employeeList.Where(li => li.BusinessEntityID == _empId3).SingleOrDefault<Employee>());

            ////Create the proxy employee entity object from the object context
            //Employee emp = _employeeRepository.GetById(_empId2);

            _employeeRepository.Delete(emp);

            Assert.IsTrue(_employeeRepository.GetByKey(emp) != null, "cannot delete employee");
        }
    }
}