using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using EhbEvo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EhbEvoApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Voornaam")]
        public string FirstName { get; set; }
        [DisplayName("Achternaam")]
        public string LastName { get; set; }
        [DisplayName("Bevoegdheid")]
        public UserRoles Role { get; set; }
        [DisplayName("Departement")]
        [Required]
        public int? DepartmentId { get; set; }
        [DisplayName("Departement")]
        [ForeignKey("DepartmentId")]
        
        public Department Department { get; set; }
        [DisplayName("OpleidingId")]
        public int? ProgramId { get; set; }
        [DisplayName("Opleiding")]
        [ForeignKey("ProgramId")]
        public Program Program { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<Comment> Comments { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<Feedback> Feedback { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<Like> Likes { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date { get; set; }

    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Post> Posts { get; set; }
        public System.Data.Entity.DbSet<Program> Programs { get; set; }
        public System.Data.Entity.DbSet<Department> Departments { get; set; }

        public System.Data.Entity.DbSet<EhbEvo.Models.Feedback> Feedbacks { get; set; }
        public System.Data.Entity.DbSet<EhbEvo.Models.Comment> Comments { get; set; }

        //public System.Data.Entity.DbSet<EhbEvoApp.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}