using MasGlobal.Employees.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasGlobal.Employees.Core.Bussiness
{
    /// <summary>
    /// Implement operations for the Employees Service
    /// </summary>
    public class InfoEmployeeRepository : IInfoEmployeeRepository
    {
        //private readonly EmployeeFactory employeeFactory;

        //public EmployeeRepository()
        //{
        //    employeeFactory = new ConcreteEmployeeFactory();
        //}

        ///// <summary>
        ///// Instance DAO for Employees
        ///// </summary>
        //public IEmployeeDAO EmployeeDAO { get; set; }

        /// <see cref="Employees.Core.Employee.IEmployeeRepository.GetEmployee(int)"
        public List<EmployeeTO> GetEmployee(string id)
        {
            //Get employees list from data source
            var employees = new List<EmployeeTO>();
            return employees;
        }       
    }
}
