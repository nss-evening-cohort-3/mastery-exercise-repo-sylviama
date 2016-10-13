using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepoQuiz.Models
{
    public class MajorPick
    {
        [Key]
        public int MajorId { get; set; }
        [Required]
        public string MajorName { get; set; }
    }
}