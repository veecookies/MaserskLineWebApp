using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaerskLineWebApp.Models
{
    public class ShippingSchedule
    {
        public int ShippingScheduleID { get; set; }

        [ForeignKey("Ship")]
        public int ShipID { get; set; }
        public Ship Ship { get; set; }
        
        [ForeignKey("Container")]
        public int ContainerID { get; set; }
        public Container Container { get; set; }

        [DataType(DataType.Currency)]
        public Double Charges { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime Departure_Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime Arrival_Date { get; set; }

        [ForeignKey("Shipyard1")]
        public int Departure_ShipyardID { get; set; }
        public virtual Shipyard Shipyard1 { get; set; }

        [ForeignKey("Shipyard2")]
        public int Arrival_ShipyardID { get; set; }
        public virtual Shipyard Shipyard2 { get; set; }
    }
}