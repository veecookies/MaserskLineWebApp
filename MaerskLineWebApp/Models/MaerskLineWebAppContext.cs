using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MaerskLineWebApp.Models
{
    public class MaerskLineWebAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MaerskLineWebAppContext() : base("name=MaerskLineWebAppContext")
        {
        }

        public System.Data.Entity.DbSet<MaerskLineWebApp.Models.Ship> Ships { get; set; }

        public System.Data.Entity.DbSet<MaerskLineWebApp.Models.Shipyard> Shipyards { get; set; }

        public System.Data.Entity.DbSet<MaerskLineWebApp.Models.ShippingSchedule> ShippingSchedules { get; set; }

        public System.Data.Entity.DbSet<MaerskLineWebApp.Models.Container> Containers { get; set; }
    }
}
