using EhbEvo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EhbEvoApp.Models
{
    public class Program
    {
        [Key]
        public int ProgramId { get; set; }
        [Required]
        [DisplayName("Opleiding")]
        public string ProgramName { get; set; }
        [DisplayName("Opleidingstype")]
        public string ProgramType { get; set; }
        public virtual ICollection<Department> Departments { get; set; }

        public Program()
        {
            this.Departments = new List<Department>();
        }
    }

    public static class DepartmentExtention
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<Program> programs, int programid)
        {
            return
                programs.OrderBy(d => d.ProgramType)
                      .Select(program =>
                          new SelectListItem
                          {
                              Selected = (program.ProgramId == programid),
                              Text = program.ProgramName,
                              Value = program.ProgramId.ToString()
                          });
        }
    }
}