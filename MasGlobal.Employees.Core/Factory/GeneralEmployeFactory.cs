using MasGlobal.Employees.Core.Bussiness;
using System;

namespace MasGlobal.Employees.Core.Factory
{
    public class GeneralEmployeFactory: EmployeeFactory
    {
        public override Employee GetEmployee(string ContractTypeName)
        {
            Employee entity = Activator.CreateInstance(Type.GetType(ContractTypeName)) as Employee;

            return entity;
        }
    }
}
