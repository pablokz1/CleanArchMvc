using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidadeDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value!");
            Id = id;
            ValidadeDomain(name);
        }

        public void Update(string name)
        {
            ValidadeDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidadeDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Invalid name. Name is required!");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name. Too short, minimum 3 characters!");

            Name = name;
        }
    }
}
