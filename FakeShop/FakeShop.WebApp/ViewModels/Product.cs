using System.ComponentModel.DataAnnotations;

namespace FakeShop.WebApp.ViewModels
{
    public class Product
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Naslov je obavezan.")]
        [StringLength(maximumLength: 25, ErrorMessage = "Naslov može imati maksimalno 25 znakova")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Cijena je obavezan.")]
        [Range(1, 1000, ErrorMessage = "Cijena može biti između 1 i 1000")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Opis je obavezan,")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Kategorija je obavezna.")]
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
