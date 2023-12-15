using CleanArchMcv.Domain.Validation;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMcv.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        private Category()
        {
        }

        public Category(string name)
        {
            ValidationDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidationDomain(name);
        }

        public void Update(string name)
        {
            ValidationDomain(name);
        }

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
                "Invalid name. Name is requerid");

            DomainExceptionValidation.When(name.Length < 3,
                "Name invalid, Name need more 3 word");

            Name = name;
        }
    }
}
