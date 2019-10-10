using MasGlobal.Employees.Web.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http.Results;
using System.Web.Http.ModelBinding;
using System.Threading.Tasks;
using Spring.Rest.Client;
using MasGlobal.Employees.Common.Constantes;
using MasGlobal.Employees.Common.ProveedoresDependencias;
using MasGlobal.Employees.TO;

namespace MasGlobal.Employees.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private RestTemplate _proxy;

        /// <summary>
        /// Crea una nueva instancia del tipo <see cref="CapturasController"/>
        /// </summary>
        public EmployeeController()
        {
            _proxy = LocalizadorServicio<RestTemplate>.GetService();
        }

        /// <summary>
        /// Crea una nueva instancia del tipo <see cref="CapturasController"/>
        /// </summary>
        /// <param name="proxy">proxy rest inyectado a través del contenedor de instancias de spring</param>
        public EmployeeController(RestTemplate proxy)
        {
            _proxy = proxy;
        }

        public ActionResult Index()
        {
            return View();
        }       

        /// <summary>
        /// Get all info about employees
        /// </summary>
        public JsonResult GetInfoEmployees(int? IdEmployee)
        {
            var EmployeesInfo = _proxy.GetForObject<ICollection<EmployeeTO>>($"{ConstantesApi.getEmployeesUri}?IdEmployee={IdEmployee}");
            return Json(EmployeesInfo);
        }
    }

    
}
