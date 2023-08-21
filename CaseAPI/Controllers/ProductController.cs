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
    public class ProductController : ControllerBase
    {
        IProductRepository productRepository;
        public ProductController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        [HttpGet("GetAll")]
        public List<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        [HttpGet("GetById")]
        public Product GetById(Guid id)
        {
            return productRepository.GetById(id);
        }

        [HttpPost("Create")]
        public RequestReponse Create(ProductDTO product)
        {
            try
            {
                productRepository.Create(new Product()
                {
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    Name = product.Name,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Unit = product.Unit,
                    Id = new Guid()
                });

            }
            catch (Exception ex)
            {
                Failure(ex.Message);
            }
            return new RequestReponse() { IsOk = true };
        }
        [HttpPost("Update")]
        public RequestReponse Update(ProductDTO product)
        {
            try
            {
                productRepository.Update(new Product()
                {
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    Name = product.Name,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Unit = product.Unit,
                    Id = product.Id
                });
            }
            catch (Exception ex)
            {
                Failure(ex.Message);
            }
            return new RequestReponse() { IsOk = true };
        }

        [HttpGet("Delete")]
        public RequestReponse Delete(Guid id)
        {
            try
            {
                var product = productRepository.GetById(id);
                productRepository.Delete(product);
            }
            catch (Exception ex)
            {
                Failure(ex.Message);
            }
            return new RequestReponse() { IsOk = true };
        }
        [HttpGet("Filter")]
        public List<Product> Filter(string sortOrder,string category)
        {
            return productRepository.FilterProducts(sortOrder,category);
        }

        private RequestReponse Failure(string ex)
        {
            return new RequestReponse { IsOk = false, Errors = new List<string> { ex } };
        }
    }
}
