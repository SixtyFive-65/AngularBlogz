using AngularAPI.Data;
using AngularAPI.Models.Domain;
using AngularAPI.Models.DTO;
using AngularAPI.Repo;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepo categoryRepo;

        public CategoriesController(ICategoryRepo categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto request)
        {
            var cat = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            var result = await categoryRepo.CreateCategory(request);

            if (result != null)
            {

                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllCats")]
        public async Task<IActionResult> GetAllCategories()
        {
            var data = await categoryRepo.GetAllCats();

            if (data != null && data.Any())
            {
                return Ok(data);
            }

            return NotFound();
        }
    }
}
