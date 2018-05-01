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
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public int Evopoints { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        [Required]
        public PostType PostType { get; set; }
        [Required]
        public PostCategory PostCategory { get; set; }
        [Required]
        public string Title { get; set; }
        [AllowHtml]
        [Required]
        public string Content { get; set; }
        public string ImgUrl { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date { get; set; }

        public Post()
        {
            this.Evopoints = 50;
            this.Feedback = new List<Feedback>();
        }
    }
}