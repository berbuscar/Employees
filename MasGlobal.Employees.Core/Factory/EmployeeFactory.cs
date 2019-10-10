using MasGlobal.Employees.Core.Bussiness;
using System;

namespace MasGlobal.Employees.Core.Factory
{
    public abstract class EmployeeFactory
    {
        public abstract Employee GetEmployee(string ContractTypeName);
        
    }
}
