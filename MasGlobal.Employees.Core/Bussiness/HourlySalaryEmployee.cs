namespace MasGlobal.Employees.Core.Bussiness
{
    public class HourlySalaryEmployee: Employee
    {
        private double BaseAnnual { get; } = 120;

        public override void CalcAnnualSalary()
        {
            this.AnnualSalary = this.BaseAnnual * this.HourlySalary * 12;
        }
    }
}
