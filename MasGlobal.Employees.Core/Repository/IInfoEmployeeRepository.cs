using MasGlobal.Employees.TO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.Employees.Core.Repository
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
        Task<ICollection<EmployeeTO>> GetEmployee(int? IdEmployee = null);
    }
}
