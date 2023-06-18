using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Design_Patterns.Builder.EmployeeBuilderDemo;
using static Design_Patterns.Builder.FunctionalBuilderProgram;

namespace Design_Patterns.Builder
{
    /// <summary>
    /// Extended class with method Purchase Year method.
    /// </summary>
    public static class EquipmentBuilderExtensions
    {
        public static EquipmentBuilder PurchaseYear(this EquipmentBuilder builder, string purchaseYear)
        {
            return builder.Do(p => p.PurchaseYear = purchaseYear);
        }
    }

    public static class EmployeeBuilderExtensions
    {
        public static EmployeeBuilder Salary(this EmployeeBuilder builder, int salary)
        {
            return builder.Do(p => p.Salary = salary);
        }
    }
}
