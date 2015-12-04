namespace funkyrestaurants.web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Funkyrestaurant
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string Adress { get; set; }

        public double? AverageStars { get; set; }
    }
}
