using AutoMapper;
using Receptdatabas.Repositories.Intefaces;
using Receptdatabas.Repositories.Models.DTOs;
using Receptdatabas.Repositories.Models.Entities;
using Receptdatabas.Services.Interfaces;

namespace Receptdatabas.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public void CreateCategory(Category category)
        {
            if(category.Name != null)
            {
                _categoryRepository.CreateCategory(category);
            }
            else
            {
                throw new ArgumentException("Invalid category details");
            }
        }

        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public CategoryDto GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
