﻿using StockApp.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StockApp.Domain.Entities
{
    public class Product
    {
        #region Atributos
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "The name must be at most 100 characters long.")]
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set;}

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(500, ErrorMessage = "The Name must be at most 500 characters long.")]
        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The price must be a non-negative value.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The Stock must be a non-negative value.")]
        public int Stock { get; set;}

        [StringLength(250, ErrorMessage = "The Image name must be at most 250 characters long.")]
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
            Id= id;
            ValidateDomain(name, description, price, stock, image);
        }



        public Category Category { get; set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description, name is required.");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters.");

            DomainExceptionValidation.When(price < 0, "Invalid price negative value.");

            DomainExceptionValidation.When(stock < 0, "Invalid stock negative value.");

            if (!string.IsNullOrEmpty(Image))
            {
                DomainExceptionValidation.When(image.Length > 250, "Invalid image name, too long, maximum 250 characters.");

            }


        }
    }
}