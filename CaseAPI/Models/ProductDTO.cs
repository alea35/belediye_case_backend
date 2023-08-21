using System.Reflection.Metadata.Ecma335;

namespace CaseAPI.Models
{
    public class ProductDTO
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }
    }
}
