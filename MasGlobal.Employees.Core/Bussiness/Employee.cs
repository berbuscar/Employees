using System;

namespace MasGlobal.Employees.Core.Bussiness
{
    public abstract class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContractTypeName { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public double HourlySalary { get; set; }

        public double MonthlySalary { get; set; }

        public double AnnualSalary { get; set; }

        public abstract void CalcAnnualSalary();
    }
}
