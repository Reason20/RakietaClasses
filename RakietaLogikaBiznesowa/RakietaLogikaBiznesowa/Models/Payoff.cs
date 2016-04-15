namespace RakietaLogikaBiznesowa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payoff")]
    public partial class Payoff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public TypeOfPayment2 TypeOf { get; set; }

        public double Value { get; set; }

        public double PercentOfLoad { get; set; }

        public double PercentOfIncome { get; set; }

        public int LoadsId { get; set; }

        public int? IncomesId { get; set; }

        public int? MoneyboxId { get; set; }

        public virtual Incomes Incomes { get; set; }

        public virtual Loads Installment { get; set; }

        public virtual Moneybox Moneybox { get; set; }
    }
}
