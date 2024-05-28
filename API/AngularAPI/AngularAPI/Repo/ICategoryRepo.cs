using AngularAPI.Models.DTO;
using System.ComponentModel;

namespace AngularAPI.Repo
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<CategoryDto>> GetAllCats();
        Task<CategoryDto> CreateCategory(CreateCategoryDto categoryDto);
    }
}
