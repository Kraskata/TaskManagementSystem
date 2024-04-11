﻿using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.Components
{
    public class AdminMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
