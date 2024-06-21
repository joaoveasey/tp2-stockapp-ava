using System;
using System.ComponentModel.DataAnnotations;
using StockApp.Domain.Validation;

namespace StockApp.Domain.Entities
{
    public class Product
    {
        #region Atributos

        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The Name must be between 3 and 100 characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "The Description must be between 5 and 500 characters long.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price must be a positive value.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Stock field is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "The Stock must be a non-negative integer.")]
        public int Stock { get; set; }

        [StringLength(250, ErrorMessage = "The Image URL must be at most 250 characters long.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "The CategoryId field is required.")]
        public int CategoryId { get; set; }

        #endregion

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Update Invalid Id value");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public Category Category { get; set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description, description is required.");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 characters.");
            DomainExceptionValidation.When(price < 0, "Invalid price negative value.");
            DomainExceptionValidation.When(stock < 0, "Invalid stock negative value.");

            if (!string.IsNullOrEmpty(image))
            {
                DomainExceptionValidation.When(image.Length > 250, "Invalid image name, too long, maximum 250 characters.");
            }
        }
    }
}
