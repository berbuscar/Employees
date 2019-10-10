using MasGlobal.Employees.Core.Bussiness;
using System;

namespace MasGlobal.Employees.Core.Factory
{
    public static class EmployeeFactory
    {
        public static Employee Build(string ContractTypeName)
        {
            switch (ContractTypeName)
            {
                case "1":
                    return new HourlySalaryEmployee();
                case "2":
                    return new MonthlySalaryEmployee();
                default:
                    throw new Exception(string.Format("InvalidContractType {0}", ContractTypeName));

            }
        }
    }
}
