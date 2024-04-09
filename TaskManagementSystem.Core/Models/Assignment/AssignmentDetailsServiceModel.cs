using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Models.Assignee;

namespace TaskManagementSystem.Core.Models.Assignment
{
    public class AssignmentDetailsServiceModel : AssignmentServiceModel
    {
        public string Category { get; set; } = null!;

        public AssigneeServiceModel Assignee { get; set; } = null!;

        public string Assigned { get; set; } = null!;
    }
}
