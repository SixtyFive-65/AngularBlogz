using AngularAPI.Data;
using AngularAPI.Models.Domain;
using AngularAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace AngularAPI.Repo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AngularApiDbContext angularApiDbContext;

        public CategoryRepo(AngularApiDbContext angularApiDbContext)
        {
            this.angularApiDbContext = angularApiDbContext;
        }
        public async Task<CategoryDto> CreateCategory(CreateCategoryDto categoryDto)
        {
            var catt = new Category
            {
                Name = categoryDto.Name,
                UrlHandle = categoryDto.UrlHandle
            };

            await angularApiDbContext.Category.AddAsync(catt);

            await angularApiDbContext.SaveChangesAsync();

            return new CategoryDto { Id = catt.Id, Name = catt.Name, UrlHandle = catt.UrlHandle };
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCats()
        {
            var data = await angularApiDbContext.Category.ToListAsync();

            var response = data.Select(p => new CategoryDto
            {
                Id = p.Id,
                Name = p.Name,
                UrlHandle = p.UrlHandle
            });

            return response;
        }
    }
}
