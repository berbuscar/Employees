using MasGlobal.Employees.TO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.Employees.Core.Integration
{
    /// <summary>
    /// Interface with data access methods for the Employees Service
    /// </summary>
    public interface IEmployeeIntegrationDAO
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>List of <see cref="EmployeeTO"/></returns>
        Task<ICollection<EmployeeTO>> GetAllEmployees();
    }
}
