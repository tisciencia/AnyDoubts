using System.Collections.Generic;
using AnyDoubts.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace AnyDoubts.Web.ViewModels
{
    public class UserProfile
    {
        public IList<Question> Questions { get; set; }
        
        [Required]        
        [StringLength(255, ErrorMessage = "Must be less than 255 characters")]
        public string NewQuestion { get; set; }
    }
}