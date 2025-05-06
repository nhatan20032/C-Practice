using CSharpPracice_1.Entities;
using CSharpPracice_1.Interfaces;
using System.Diagnostics;

namespace CSharpPracice_1.Services
{
    public class ProductServices : IProductServices
    {
        private List<Products> listProducts = new();
        private string storageFolder = Path.Combine(Directory.GetCurrentDirectory(), "product_images");

        public ProductServices()
        {
        }

        public void Create(Products products)
        {
            try
            {
                if (!File.Exists(products.ImagePath))
                {
                    Console.WriteLine("Image not exist, please try again!");
                    return;
                }

                Directory.CreateDirectory(storageFolder);

                string fileName = Path.GetFileName(products.ImagePath);
                string destImagePath = Path.Combine(storageFolder, $"{Guid.NewGuid()}_{fileName}");

                var product = new Products
                {
                    Id = listProducts.Count + 1,
                    Name = products.Name,
                    Description = products.Description,
                    Category = products.Category,
                    Price = products.Price,
                    Quantity = products.Quantity,
                    CreateAt = DateTime.Now,
                    ImagePath = destImagePath,
                };

                listProducts.Add(product);

                Console.WriteLine("\nProduct Created\n");
                Console.WriteLine($"Id sản phẩm: {product.Id}");
                Console.WriteLine($"Tên sản phẩm: {product.Name}");
                Console.WriteLine($"Mô tả sản phẩm: {product.Description}");
                Console.WriteLine($"Thể loại sản phẩm: {product.Category}");
                Console.WriteLine($"Giá sản phẩm: {product.Price}");
                Console.WriteLine($"Số lượng sản phẩm: {product.Quantity}");
                Console.WriteLine($"Thời gian tạo sản phẩm: {product.CreateAt}");
                Console.WriteLine($"Đường dẫn ảnh: {product.ImagePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã sảy ra lỗi {ex}");
            }
        }

        public void Delete(int id)
        {
            var productDelete = listProducts.FirstOrDefault(p => p.Id == id);
            if (productDelete == null) return;
            listProducts.Remove(productDelete);
            Console.WriteLine("Đã xoá được sản phẩn");
        }

        public List<Products> GetAll(string search)
        {
            return string.IsNullOrWhiteSpace(search)
                ? listProducts
                : listProducts.Where(t =>
                    t.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    t.Category.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Products GetById(int id)
        {
            return listProducts.FirstOrDefault(t => t.Id == id) ?? null;
        }

        public void BubbleSortByName()
        {
            if (listProducts.Count < 1)
            {
                Console.WriteLine("Không có phần tử nào trong mảng để sắp xếp");
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < listProducts.Count - 1; i++)
            {

                for (int j = 0; j < listProducts.Count - i - 1; j++)
                {

                    if (string.Compare(listProducts[j].Name, listProducts[j + 1].Name, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        var temp = listProducts[j];
                        listProducts[j] = listProducts[j + 1];
                        listProducts[j + 1] = temp;
                    }

                }

            }

            stopwatch.Stop();

            Console.WriteLine("Đã bubble sort xong !! \n");

            for (int i = 0; i < listProducts.Count; i++)
            {
                Console.WriteLine($"Tên sản phẩm: {listProducts[i].Name}");
                Console.WriteLine("======================\n");
            }

            Console.WriteLine($"Thời gian hoàn thành sắp xếp {stopwatch.ElapsedMilliseconds}\n");
        }

        public void Update(Products products)
        {
            var index = listProducts.FindIndex(t => t.Id == products.Id);

            if (index == -1)
            {
                Console.WriteLine("Không tìm thấy sản phẩm để cập nhật.");
                return;
            }

            listProducts[index] = products;
            Console.WriteLine("Cập nhật sản phẩm thành công.");
        }
    }
}
