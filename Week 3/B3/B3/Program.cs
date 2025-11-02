struct Product
{
    public string Name;
    public double Price;
    public int Quantity;
    public string Category;

    public Product(string name, double price, int quantity, string category)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        Category = category;
    }

    public double Revenue()
    {
        return Price * Quantity;
    }
}
class Program
{
    static Dictionary<string, List<Product>> products = new Dictionary<string, List<Product>>();
    static void Main(string[] args)
    {
        Console.WriteLine("1. Thêm / Cập nhật sản phẩm");
        Console.WriteLine("2. Tra cứu sản phẩm theo mã");
        Console.WriteLine("3. Sản phẩm bán chạy nhất");
        Console.WriteLine("4. Sản phẩm bán chạy nhất theo danh mục");
        Console.WriteLine("5. Tổng doanh thu theo danh mục");
        Console.WriteLine("0. Thoát");
        Console.Write("Chọn chức năng: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddOrUpdateProduct();
                break;
            case "2":
                SearchProduct();
                break;
            case "3":
                BestSellingProduct();
                break;
            case "4":
                BestSellingProductByCategory();
                break;
            case "5":
                TotalRevenueByCategory();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Chức năng không hợp lệ.");
                break;
        }
    }
    static void AddOrUpdateProduct()
    {
        Console.Write("Nhập mã sản phẩm: ");
        string code = Console.ReadLine();

        Console.Write("Nhập tên sản phẩm: ");
        string name = Console.ReadLine();

        Console.Write("Nhập giá sản phẩm: ");
        double price = double.Parse(Console.ReadLine());

        Console.Write("Nhập số lượng bán: ");
        int quantity = int.Parse(Console.ReadLine());

        Console.Write("Nhập danh mục sản phẩm: ");
        string category = Console.ReadLine();

        if (products.ContainsKey(code))
        {
            Product p = products[code];
            p.Quantity += quantity;
            p.Category = category;
            p.Price = price;
            products[code] = p;
            Console.WriteLine("Cập nhật sản phẩm thành công!");
        }
        else
        {
            Product p = new Product(name, price, quantity, category);
            products.Add(code, p);
            Console.WriteLine("Thêm sản phẩm thành công!");
        }
    }

    static void SearchProduct()
    {
        Console.Write("Nhập mã sản phẩm cần tra cứu: ");
        string code = Console.ReadLine();

        if (products.ContainsKey(code))
        {
            Product p = products[code];
            Console.WriteLine($"Tên: {p.Name}, Giá: {p.Price}, Số lượng bán: {p.Quantity}, Danh mục: {p.Category}");
        }
        else
        {
            Console.WriteLine("Sản phẩm không tồn tại.");
        }
    }

    static void BestSellingProduct()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("Chưa có sản phẩm nào.");
            return;
        }

        var bestSelling = products.Values.OrderByDescending(p => p.Quantity).First();
        Console.WriteLine($"Sản phẩm bán chạy nhất: Tên: {bestSelling.Name}, Số lượng bán: {bestSelling.Quantity}");
    }

    static void BestSellingProductByCategory()
    {
        Console.Write("Nhập danh mục cần tra cứu: ");
        string category = Console.ReadLine();
        var filteredProducts = products.Values.Where(p => p.Category == category);
        if (!filteredProducts.Any())
        {
            Console.WriteLine("Không có sản phẩm trong danh mục này.");
            return;
        }
        var bestSelling = filteredProducts.OrderByDescending(p => p.Quantity).First();
        Console.WriteLine($"Sản phẩm bán chạy nhất trong danh mục {category}: Tên: {bestSelling.Name}, Số lượng bán: {bestSelling.Quantity}");
    }

    static void TotalRevenueByCategory()
    {
        Console.Write("Nhập danh mục cần tính doanh thu: ");
        string category = Console.ReadLine();
        var filteredProducts = products.Values.Where(p => p.Category == category);
        if (!filteredProducts.Any())
        {
            Console.WriteLine("Không có sản phẩm trong danh mục này.");
            return;
        }
        double totalRevenue = filteredProducts.Sum(p => p.Revenue());
        Console.WriteLine($"Tổng doanh thu trong danh mục {category}: {totalRevenue}");
    }
}