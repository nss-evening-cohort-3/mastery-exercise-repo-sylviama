using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepoQuiz.Models
{
    public class LastNamePick
    {
        [Key]
        public int LastNameId { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}