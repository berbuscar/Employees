using MasGlobal.Employees.TO;
using System.Collections.Generic;

namespace MasGlobal.Employees.Core.Bussiness
{
    /// <summary>
    /// Interface with operations for the Employees Service
    /// </summary>
    public interface IInfoEmployeeRepository
    {
        

        /// <summary>
        /// Get an employee by id
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <returns>Instance of <see cref="EmployeeTO"/> with Employee information</returns>
        List<EmployeeTO> GetEmployee(string id);
    }
}
