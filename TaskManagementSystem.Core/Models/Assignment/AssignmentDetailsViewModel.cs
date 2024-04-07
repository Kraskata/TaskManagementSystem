﻿namespace TaskManagementSystem.Core.Models.Assignment
{
    public class AssignmentDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string DoneBy { get; set; } = string.Empty;
    }
}
