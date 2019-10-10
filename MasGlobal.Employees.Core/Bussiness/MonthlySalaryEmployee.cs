namespace MasGlobal.Employees.Core.Bussiness
{
    public class MonthlySalaryEmployee: Employee
    {
        public override void CalcAnnualSalary()
        {
            this.AnnualSalary = this.MonthlySalary * 12 ;
        }
    }
}
