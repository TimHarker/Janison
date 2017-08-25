using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Janison.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Cost { get; set; }
        [Range(30, 180, ErrorMessage = "Duration must be between 30 min and 180 min")]
        public int? Duration { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }
        [NotMapped]
        public string State
        {
            get
            {
                return (DateCreated.Date > DateTime.Today.AddDays(-7) ? "New" : string.Empty);
            }
        }
        [Column(TypeName = "datetime2")]
        public DateTime? DateModified { get; set; }
        public bool Enabled { get; set; }

        public virtual ICollection<Module> Modules { get; set; }
    }
}