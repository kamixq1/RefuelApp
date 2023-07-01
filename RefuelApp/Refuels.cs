namespace RefuelApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Refuels
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public double Quantity { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime RefuelDate { get; set; }

        [Required]
        public string Odometer { get; set; }
        public double Cost { get; set; }
    }
}
