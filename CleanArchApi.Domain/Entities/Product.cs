﻿using CleanArch.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public Product() { }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name, description, price, stock, image);           
        }



        public void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
                "Invalid name. Name is requerid");

            DomainExceptionValidation.When(name.Length < 3,
                "Name invalid, Name need more 3 word");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description),
                "Invalid name. Description is requerid");

            DomainExceptionValidation.When(description.Length < 3,
                "Name invalid, Description need more 3 word");

            DomainExceptionValidation.When(price < 0,
                "Invalid price value");

            DomainExceptionValidation.When(stock < 0,
                "Invalid stock value");

            DomainExceptionValidation.When(image.Length > 250,
                "Image too long. Image need be less of 250 characters");

            
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;

        }
    }
}
