using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLineWebApp.Models
{
    public class Container
    {
        public int ContainerID { get; set; }

        [Required]
        public String Container_Description { get; set; }

        public int Container_Weight { get; set; }
    }
}