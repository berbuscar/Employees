using MasGlobal.Employees.Core.Bussiness;
using System;

namespace MasGlobal.Employees.Core.Factory
{
    public static class EmployeeFactory
    {
        public static Employee Build(string ContractTypeName)
        {
            Employee entity = Activator.CreateInstance(Type.GetType(ContractTypeName)) as Employee;

            return entity;
        }
    }
}
