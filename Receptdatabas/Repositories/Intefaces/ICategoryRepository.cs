using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Repositories.Intefaces
{
    public interface ICategoryRepository
    {
        Category GetCategory(int id);
        void CreateCategory(Category category);
        IEnumerable<Category> GetAllCategories();
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
