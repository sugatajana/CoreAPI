using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    [Table("recipe_customerProfile")]
    public class CustomerProfile
    {
        [Key]
        public string CustomerProfileId { get; set; }
        #nullable enable
        public string? CustomerId { get; set; }
        public double? MonthlyIncome { get; set; }
        public double? ExpenseEssential { get; set; }
        public double? ExpenseNonEssential { get; set; }
        public double? ExpenseTotalEMI { get; set; }
        public double? ExpenseMonthlyInsurance { get; set; }
        public double? InvestPrimaryHome { get; set; }
        public double? InvestOtherProperty { get; set; }
        public double? InvestEquity { get; set; }
        public double? InvestSavings { get; set; }
        public double? InvestGold { get; set; }
        public double? InvestOther { get; set; }
        public double? LoanCreditCard { get; set; }
        public double? LoanHome { get; set; }
        public double? LoanVehicle { get; set; }
        public double? LoanEducation { get; set; }
        public double? LoanPersonal { get; set; }
        public double? LoanOther { get; set; }
        public DateTime? datecreated { get; set; }
        public string? createdby { get; set; }
        public string? createdIP { get; set; }
        public DateTime? datemodified { get; set; }
        public string? modifiedby { get; set; }
        public string? modifiedIP { get; set; }
        public double? TotalExpense { get; set; }
    }
}
