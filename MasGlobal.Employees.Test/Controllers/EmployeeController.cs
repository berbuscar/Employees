using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using LightInject;
using MasGlobal.Employees.Core.Integration;
using MasGlobal.Employees.Core.Repository;
using MasGlobal.Employees.DAO.Integration;
using MasGlobal.Employees.TO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;

namespace MasGlobal.Employees.Test
{
    [TestClass]
    public class EmployeeController
    {
        public static ServiceContainer Container { get; set; }
        public EmployeeController()
        {
            //Se registra el encargado de resolver las instancias y dependencias
            //Service Container
            Container = new ServiceContainer();
            Container.Register<IEmployeeIntegrationDAO, EmployeeIntegrationDAO>();
            Container.Register<IInfoEmployeeRepository, InfoEmployeeRepository>();
        }

        [TestMethod]
        public void GetInfoEmployeesByURL()
        {
            //token
            RestClient client;
            string employeesServiceUrl = ConfigurationManager.AppSettings["APIRoot"];
            client = new RestClient(employeesServiceUrl);           

            var request = new RestRequest("GetInfoEmployees", Method.GET);
            request.AddQueryParameter("IdEmployee", "1"); // aplica para cada estacion, etiqueta, parametro

            // execute the request
            IRestResponse response = client.ExecuteAsGet(request, "GET");

            List<EmployeeTO> ListEmployees = JsonConvert.DeserializeObject<List<EmployeeTO>>(response.Content);

            Assert.IsNotNull(ListEmployees);
            Assert.IsTrue(ListEmployees.Count > 0);
        }


        [TestMethod]
        public async Task GetAllInfoEmployeesByRepository()
        {
            var _employeeRepository = Container.GetInstance<IInfoEmployeeRepository>();
            var employees = await _employeeRepository.GetEmployee();

            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Count > 0);
        }

        [TestMethod]
        public async Task GetByIdInfoEmployeesByRepository_Exists_Data()
        {
            var _employeeRepository = Container.GetInstance<IInfoEmployeeRepository>();
            var employees = await _employeeRepository.GetEmployee(1);

            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Count > 0);
        }

        [TestMethod]
        public async Task GetByIdInfoEmployeesByRepository_Not_Exists_Data()
        {
            var _employeeRepository = Container.GetInstance<IInfoEmployeeRepository>();
            var employees = await _employeeRepository.GetEmployee(12);

            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Count > 0);
        }
    }
}
