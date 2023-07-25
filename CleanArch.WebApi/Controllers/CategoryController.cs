﻿using CleanArch.Application.DTOs;
using CleanArch.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebApi.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRespository _categoryRespository;

        public CategoryController(ICategoryRespository categoryRespository)
        {
            _categoryRespository = categoryRespository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()        
            => Ok(await _categoryRespository.GetCategories());
            
        

    }
}