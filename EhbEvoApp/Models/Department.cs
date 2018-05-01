using EhbEvoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EhbEvo.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [DisplayName("Departement")]
        public string DepartmentName { get; set; }
        public virtual ICollection<Program> Programs { get; set; }

        public Department()
        {
            this.Programs = new List<Program>();
        }

    }
}