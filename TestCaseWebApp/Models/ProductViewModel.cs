

using CaseEntity;

namespace TestCaseWebApp.Models
{
    
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories{ get; set; }
        
        public string SelectedCategory { get; set; }

    }
}
