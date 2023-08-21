using CaseAPI.Models;
using CaseDAL.Abstract;
using CaseEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        [HttpGet("GetAll")]
        public List<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        [HttpGet("GetById")]
        public Category GetById(Guid id)
        {
            var category = categoryRepository.GetById(id);
            return category;
        }

        [HttpPost("Create")]
        public RequestReponse Create(CategoryDTO category)
        {
            try
            {
                categoryRepository.Create(new Category() { Id = new Guid(), Name = category.Name, Description = category.Description });
            }
            catch (Exception ex)
            {
                return Failure(ex.Message);
            }
            
            return new RequestReponse { IsOk = true };
        }

        [HttpPost("Update")]
        public RequestReponse Update(Category category)
        {
            try
            {
                categoryRepository.Update(category);
            }
            catch (Exception ex)
            {
                return Failure(ex.Message);
            }
            return new RequestReponse { IsOk = true };
        }

        [HttpGet("Delete")]
        public RequestReponse Delete(Guid id)
        {
            try
            {
                var product = categoryRepository.GetById(id);
                categoryRepository.Delete(product);
            }
            catch (Exception ex)
            {
                return Failure(ex.Message);
            }
            return new RequestReponse { IsOk = true };
        }

        private  RequestReponse Failure(string ex)
        {
            return new RequestReponse { IsOk = false, Errors = new List<string> { ex } };
        }

    }
}
