using MasGlobal.Employees.Core.Integration;
using MasGlobal.Employees.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MasGlobal.Employees.Common.Auxiliares;

namespace MasGlobal.Employees.DAO.Integration
{
    public class EmployeeIntegrationDAO : IEmployeeIntegrationDAO
    {
        /// <see cref="MasGlobal.Employees.Domain.Integration.EmployeeIntegrationDAO.GetEmployees"/>
        public async Task<ICollection<EmployeeTO>> GetAllEmployees()
        {            
            //read api url
            var proxy = new HttpClient();
            string employeesUrl = ConfigurationManager.AppSettings["masglobaltestapi_url"];

            if (string.IsNullOrWhiteSpace(employeesUrl))
            {
                throw new Exception(string.Format("Key Required on config file {0}", "masglobaltestapi_url"));
            }
            HttpResponseMessage response = await proxy.GetAsync(employeesUrl);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new OrderedContractResolver()
            };

            var employees = JsonConvert.DeserializeObject<List<EmployeeTO>>(content, settings);            
            //Create client for requesting Employees list

            return employees;
        }
    }
}
