namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayoffSet")]
    public partial class PayoffSet
    {
        public int Id { get; set; }

        public TypeOfPayment2 TypeOf { get; set; }

        public double Value { get; set; }

        public double PercentOfLoad { get; set; }

        public double PercentOfIncome { get; set; }

        public int LoadsId { get; set; }

        public int? IncomesId { get; set; }

        public int? MoneyboxId { get; set; }

        public virtual Incomes Incomes { get; set; }

        public virtual Loads Loads { get; set; }

        public virtual MoneyboxSet MoneyboxSet { get; set; }
    }
}
