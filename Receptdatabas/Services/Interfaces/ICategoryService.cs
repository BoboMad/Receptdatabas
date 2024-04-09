using Receptdatabas.Repositories.Models.DTOs;
using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Services.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategory(Category category);
        CategoryDto GetCategory(int id);
        IEnumerable<CategoryDto> GetAllCategories();
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
