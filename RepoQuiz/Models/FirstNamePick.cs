using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepoQuiz.Models
{
    public class FirstNamePick
    {
        [Key]
        public int FirstNameId { get; set; }
        [Required]
        public string FirstName { get; set; }
    }
}