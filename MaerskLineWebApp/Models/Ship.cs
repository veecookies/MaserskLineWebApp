using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLineWebApp.Models
{
    public class Ship
    {
        public int ShipID { get; set; }

        [Required]
        public String Ship_Name { get; set; }

        public String Ship_Description { get; set; }

        public int Max_Containers { get; set; }
    }
}