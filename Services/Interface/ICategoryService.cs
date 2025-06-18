using BackendBookMannu.Models.Dto;

namespace BackendBookMannu.Services.Interface
{
    

        public interface ICategoryService
        {
            Task<IEnumerable<CategoryDTO>> GetAllCategories();
            Task<CategoryDTO?> GetCategoryById(int id);

        }
    
}
