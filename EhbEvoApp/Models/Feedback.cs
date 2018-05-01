using EhbEvoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EhbEvo.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
        [Required]
        [AllowHtml]
        public string Content { get; set; }
        [Range(0, 10)]
        public int? Rating { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Feedback()
        {
            this.Comments = new List<Comment>();
        }

    }
}