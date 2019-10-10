using MasGlobal.Employees.Core.Bussiness;
using MasGlobal.Employees.Core.Integration;
using MasGlobal.Employees.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using MasGlobal.Employees.Common.Mapper;

namespace MasGlobal.Employees.Core.Repository
{
    /// <summary>
    /// Implement operations for the Employees Service
    /// </summary>
    public class InfoEmployeeRepository : IInfoEmployeeRepository
    {
        private string NameSpaceFactoryUrl;
        /// <summary>
        /// Instance DAO for Employees
        /// </summary>
        public IEmployeeIntegrationDAO EmployeeIntegrationDAO { get; set; }

        public InfoEmployeeRepository()
        {
            NameSpaceFactoryUrl = ConfigurationManager.AppSettings["NameSpaceFactory"];
            if (string.IsNullOrWhiteSpace(NameSpaceFactoryUrl))
            {
                throw new Exception(string.Format("Key Required on config file {0}", "NameSpaceFactory"));
            }
        }

        /// <see cref="Employees.Core.Employee.IEmployeeRepository.GetEmployee(int)"
        public async Task<ICollection<EmployeeTO>> GetEmployee(int? IdEmployee = null)
        {
            ContractMapper mapper = new ContractMapper();
            //Get employees list from data source
            ICollection<EmployeeTO> employees = await EmployeeIntegrationDAO.GetAllEmployees();
            //Find employe by id
            employees = (from emp in employees
                         where IdEmployee == null ? emp.Id != null : emp.Id.Equals(IdEmployee)
                         select emp).ToList();

            List<EmployeeTO> EmployeesFactory = new List<EmployeeTO>();
            // Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
            Parallel.ForEach(employees, (currentEmployee) =>
            {
                //select factory
                var EmployeeFactory = Employee.GetEmploye(NameSpaceFactoryUrl + currentEmployee.ContractTypeName);
                //init factory whit data
                EmployeeFactory = mapper.MapRequestToExpected(EmployeeFactory,
                                                              currentEmployee,
                                                              typeof(Employee)) as Employee;
                //calc AnnualSalary
                EmployeeFactory.CalcAnnualSalary();
                currentEmployee = mapper.MapResponseToExpected(EmployeeFactory, 
                                                               typeof(Employee), 
                                                               typeof(EmployeeTO)) as EmployeeTO;

                EmployeesFactory.Add(currentEmployee);

            });

            return EmployeesFactory;
        }
    }
}
