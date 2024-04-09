using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem.Core.Extentions
{
    public static class ModelExtentions
    {
        public static string GetInformation(this IAssignmentModel assignment)
        {
            string information = assignment.Title.Replace(" ", "-") + GetDescription(assignment.Description);

            information = Regex.Replace(information, @"[^a-zA-Z0-9\-]", string.Empty);

            return information;
        }

        private static string GetDescription(string description)
        {
            description = string.Join("-", description.Split(" ").Take(3));

            return description;
        }
    }
}
