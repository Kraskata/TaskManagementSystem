using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IAssignmentModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
