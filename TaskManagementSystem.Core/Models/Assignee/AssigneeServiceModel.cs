using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Core.Models.Assignee
{
    public class AssigneeServiceModel
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;

        [Display(Name= "Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        [Display(Name = "G-mail")]
        public string Gmail { get; set; } = null!;

    }
}
