using MasGlobal.Employees.Common.Constantes;
using MasGlobal.Employees.Core.Repository;
using MasGlobal.Employees.TO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace MasGlobal.Employees.Api.Controllers
{
    [AllowAnonymous]
    public class EmployeeController : ApiController
    {
        private IInfoEmployeeRepository _repository;

        /// <summary>
        /// Crea una nueva instancia del tipo <see cref="MasGlobal.Employees.Web.Controllers.EmployeeController"/>
        /// </summary>
        /// <param name="repository">Instancia del repositorio inyectada a través de spring.</param>    
        public EmployeeController(IInfoEmployeeRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all info about employees
        /// </summary>
        [HttpGet]
        [ResponseType(typeof(ICollection<EmployeeTO>))]
        [Route(ConstantesApi.getEmployeesUri)]
        public async Task<IHttpActionResult> GetInfoEmployees(int? IdEmployee = null)
        {
            ICollection<EmployeeTO> EmployeesInfo = await _repository.GetEmployee(IdEmployee); 
            return Ok(EmployeesInfo);
        }
    }

    
}
