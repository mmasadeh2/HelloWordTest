using MVCHelloWorldEntity.Models;
using MVCHelloWorldVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MVCHelloWorldDAL
{
    public class EmployeeDAL :IDisposable
    {
        MVCHelloWorldContext dbContext;

        #region Constructor
        public EmployeeDAL()
        {
            dbContext = new MVCHelloWorldContext();
        }

        public void Dispose()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
        #endregion

        #region Get
        public IEnumerable<EmployeeVM> GetAllEmployees()
        {
            List<Employee> ListOfEntityEmployees = dbContext.Employees.Include(p => p.Gender).ToList();
            List<EmployeeVM> ListOfViewModelEmployees = new List<EmployeeVM>();

            foreach (Employee _Employee in ListOfEntityEmployees)
            {
                EmployeeVM _EmployeeVM = new EmployeeVM();

                _EmployeeVM.Name = _Employee.Name;
                _EmployeeVM.Age = _Employee.Age;
                _EmployeeVM.GenderID = _Employee.GenderID;
                _EmployeeVM.Email = _Employee.Email;

                GenderVM _Gender = new GenderVM();

                _Gender.GenderDesc = _Employee.Gender.GenderDesc;

                _EmployeeVM.Gender = _Gender;
                ListOfViewModelEmployees.Add(_EmployeeVM);
            }

            return ListOfViewModelEmployees;
        }
        #endregion

        #region Insert
        public int InsertEmployee(EmployeeVM _EmployeeVM)
        {
            try
            {
                Employee _Employee = new Employee();

                _Employee.Name = _EmployeeVM.Name;
                _Employee.Age = _EmployeeVM.Age;
                _Employee.Email = _EmployeeVM.Email;
                _Employee.GenderID = _EmployeeVM.GenderID;

                dbContext.Employees.Add(_Employee);
                dbContext.SaveChanges();

                return _Employee.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        public int UpdateEmployee(EmployeeVM _EmployeeVM)
        {
            try
            {
                Employee _Employee = dbContext.Employees.SingleOrDefault(bate5a => bate5a.ID == _EmployeeVM.ID);
                _Employee.Name = _EmployeeVM.Name;
                _Employee.Age = _EmployeeVM.Age;
                _Employee.Email = _EmployeeVM.Email;
                _Employee.GenderID = _EmployeeVM.GenderID;

                
                dbContext.SaveChanges();

                return _Employee.ID;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region Delete
        public bool DeleteEmployee(int ID)
        {
            try
            {
                Employee _Employee = dbContext.Employees.SingleOrDefault(p => p.ID == ID);

                dbContext.Employees.Remove(_Employee);

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

    }
}
