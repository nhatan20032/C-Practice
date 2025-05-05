using CSharpPracice_1.Entities;
namespace CSharpPracice_1.Interfaces
{
    public interface IProductServices
    {
        public List<Products> GetAll(string search);
        public Products GetById(int id);
        public void Create(Products products);
        public void Update(Products products);
        public void Delete(int id);
    }
}
