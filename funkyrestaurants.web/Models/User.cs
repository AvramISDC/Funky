namespace funkyrestaurants.web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }
    }
}
