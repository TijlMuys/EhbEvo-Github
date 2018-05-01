using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EhbEvo.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public UserRoles Role { get; set; }
        [Required]
        public int DepartementId { get; set; }
        [ForeignKey("DepartementId")]
        public Departement Departement { get; set; }
        public ICollection<Post> Posts { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<Comment> Comments { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<Feedback> Feedback { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<Like> Likes { get; set; }
        [Timestamp]
        public Byte[] TimeStamp { get; set; }

    }
}