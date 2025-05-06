using CSharpPracice_1.Entities;
using CSharpPracice_1.Interfaces;
using CSharpPracice_1.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

IProductServices _productServices = new ProductServices();

while (true)
{
    Console.WriteLine("\n==== MENU ====");
    Console.WriteLine("1. Tạo sản phẩm");
    Console.WriteLine("2. Xoá sản phẩm");
    Console.WriteLine("3. Sửa sản phẩm");
    Console.WriteLine("4. Xem tất cả sản phẩm");
    Console.WriteLine("5. Tìm kiếm sản phẩm theo ID");
    Console.WriteLine("6. Sắp xếp nổi bọt (Bubble sort) theo tên");
    Console.WriteLine("8. Thoát");
    Console.Write("Chọn: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Nhập tên: ");
            var name = Console.ReadLine();

            Console.Write("Nhập thể loại: ");
            var category = Console.ReadLine();

            Console.Write("Nhập mô tả: ");
            var description = Console.ReadLine();

            decimal price;
            int quantity;

            Console.Write("Nhập giá: ");
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Giá không hợp lệ. Vui lòng nhập lại:");
            }

            Console.Write("Nhập số lượng: ");
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Số lượng không hợp lệ. Vui lòng nhập lại:");
            }

            Console.Write("Nhập đường dẫn ảnh : ");
            var picture = Console.ReadLine();

            var product = new Products
            {
                Name = name!,
                Category = category!,
                Description = description!,
                Price = price,
                Quantity = quantity,
                ImagePath = picture
            };


            _productServices.Create(product);

            Console.WriteLine("===============");
            break;
        case "2":
            Console.Write("Nhập ID để xoá sản phẩm: ");
            var idDelete = int.Parse(Console.ReadLine()!);

            _productServices.Delete(idDelete);

            Console.WriteLine("===============");
            break;
        case "3":
            Console.Write("Nhập ID để có thể sửa: ");
            var idUpdate = int.Parse(Console.ReadLine()!);

            Products productUpdate = _productServices.GetById(idUpdate);

            if (_productServices.GetById(idUpdate) == null)
            {
                Console.WriteLine("Không có sản phẩm này");
                break;
            };

            Console.Write("Sửa tên? (Y/N): ");
            var confirm = Console.ReadLine();

            if (confirm?.ToUpper() == "Y")
            {
                Console.Write("Nhập tên mới: ");
                productUpdate.Name = Console.ReadLine()!;
            }

            Console.WriteLine("Sửa mô tả? (Y/N): ");
            confirm = Console.ReadLine();

            if (confirm?.ToUpper() == "Y")
            {
                Console.Write("Nhập mô tả mới: ");
                productUpdate.Description = Console.ReadLine()!;
            }

            Console.Write("Sửa thể loại? (Y/N): ");
            confirm = Console.ReadLine();

            if (confirm?.ToUpper() == "Y")
            {
                Console.Write("Nhập thể loại mới: ");
                productUpdate.Category = Console.ReadLine()!;
            }

            Console.Write("Sửa giá? (Y/N): ");
            confirm = Console.ReadLine();

            if (confirm?.ToUpper() == "Y")
            {
                Console.Write("Nhập giá mới: ");
                productUpdate.Price = decimal.Parse(Console.ReadLine()!);
            }

            Console.Write("Sửa số lượng? (Y/N): ");
            confirm = Console.ReadLine();

            if (confirm?.ToUpper() == "Y")
            {
                Console.Write("Nhập lượng mới: ");
                productUpdate.Quantity = int.Parse(Console.ReadLine()!);
            }

            Console.Write("Sửa ảnh? (Y/N): ");
            confirm = Console.ReadLine();

            if (confirm?.ToUpper() == "Y")
            {
                Console.Write("Nhập ảnh mới: ");
                productUpdate.ImagePath = Console.ReadLine()!;
            }

            _productServices.Update(productUpdate);

            Console.WriteLine("===============");
            break;
        case "4":
            Console.Write("\nSearch: ");
            var search = Console.ReadLine();

            var obj = _productServices.GetAll(search!);

            for (int i = 0; i < obj.Count; i++)
            {
                Console.WriteLine($"\nSố thứ tự: {i + 1}");
                Console.WriteLine($"Tên sản phẩm: {obj[i].Name}");
                Console.WriteLine($"Mô tả : {obj[i].Description}");
                Console.WriteLine($"Thể loại : {obj[i].Category}");
                Console.WriteLine($"Giá : {obj[i].Price}");
                Console.WriteLine($"Số lượng : {obj[i].Quantity}");
                Console.WriteLine($"Đường dẫn ảnh : {obj[i].ImagePath}");
                Console.WriteLine("===============\n");
            }
            break;
        case "5":
            Console.WriteLine("Nhập ID: ");
            var findById = int.Parse(Console.ReadLine()!);

            var productById = _productServices.GetById(findById);

            if (productById == null)
            {
                Console.WriteLine("Không có sản phẩm này");
                break;
            }

            Console.WriteLine($"Tên sản phẩm: {productById.Name}");
            Console.WriteLine($"Mô tả : {productById.Description}");
            Console.WriteLine($"Thể loại : {productById.Category}");
            Console.WriteLine($"Giá : {productById.Price}");
            Console.WriteLine($"Số lượng : {productById.Quantity}");
            Console.WriteLine($"Đường dẫn ảnh : {productById.ImagePath}");
            Console.WriteLine("===============");
            break;
        case "6":
            Console.WriteLine("\nĐang sắp xếp \n");
            _productServices.BubbleSortByName();
            break;
        case "8":
            return;

        default:
            Console.WriteLine("Lựa chọn không hợp lệ");
            break;
    }
}

