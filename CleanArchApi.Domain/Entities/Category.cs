using CleanArch.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidationDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            ValidationDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
                "Invalid name. Name is requerid");

            DomainExceptionValidation.When(name.Length > 3,
                "Name invalid, Name need more 3 word");

            Name= name;
        }
    }
}
