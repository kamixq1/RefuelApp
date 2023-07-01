namespace RefuelApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logins
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        [Required]
        [StringLength(255)]
        public string Passwords { get; set; }
    }
}
