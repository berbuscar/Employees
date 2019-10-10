using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MasGlobal.Employees.TO
{
    /// <summary>
    /// Class that represent an employee entity from data source
    /// </summary>
    public class EmployeeTO
    {
        [JsonProperty(Order = 1)]
        public int Id { get; set; }

        [JsonProperty(Order = 2)]
        public string Name { get; set; }

        [JsonProperty(Order = 3)]
        public string ContractTypeName { get; set; }

        [JsonProperty(Order = 4)]
        public int RoleId { get; set; }

        [JsonProperty(Order = 5)]
        public string RoleName { get; set; }

        [JsonProperty(Order = 6)]
        public string RoleDescription { get; set; }

        [JsonProperty(Order = 7)]
        public double HourlySalary { get; set; }

        [JsonProperty(Order = 8)]
        public double MonthlySalary { get; set; }

        [JsonProperty(Order = 9)]
        public double AnnualSalary { get; set; }

    }
}
