namespace MasGlobal.Employees.Core.Bussiness
{
    public class HourlySalaryEmployee: Employee
    {
        public override void CalcAnnualSalary()
        {
            this.AnnualSalary = 120 * this.HourlySalary * 12;
        }
    }
}
