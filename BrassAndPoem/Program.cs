//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>()
{
    new Product
    {
        Name = "Trumpet",
        Price = 150.99M,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Trombone",
        Price = 246.99M,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Tuba",
        Price = 1250.99M,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Ozymandias",
        Price = 12350.99M,
        ProductTypeId = 2,
    },
    new Product
    {
        Name = "Leaves of Grass",
        Price = 15650.99M,
        ProductTypeId = 2,
    },
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List.
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType { Id = 1, Title = "Brass" },
    new ProductType { Id = 2, Title = "Poem" },
};

//put your greeting here
Console.WriteLine("Welcome to Brass and Poem!");

//implement your loop here
RunMenu();

void DisplayMenu() // No parameters needed
{
    Console.WriteLine(
        @"1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit"
    );
}

void RunMenu()
{
    string choice = null;
    while (choice != "5")
    {
        DisplayMenu();
        choice = Console.ReadLine();
        if (choice == "1")
        {
            DisplayAllProducts(products, productTypes);
        }
        else if (choice == "2")
        {
            DeleteProduct(products, productTypes);
        }
        else if (choice == "3")
        {
            AddProduct(products, productTypes);
        }
        else if (choice == "4")
        {
            UpdateProduct(products, productTypes);
        }
        else if (choice == "5")
        {
            Console.WriteLine("GOODBYE");
        }
        else
        {
            Console.WriteLine("Incorrect input! Please enter a number!");
        }
    }
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    int counter = 1;

    foreach (Product product in products)
    {
        var thisProductType = productTypes.FirstOrDefault(item => item.Id == product.ProductTypeId);
        Console.WriteLine(
            $"{counter++}. {product.Name} --- {thisProductType.Title} --- {product.Price}"
        );
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);

    Console.WriteLine("Please choose which product you would like to DELETE:");

    int deleteChoice = int.Parse(Console.ReadLine());

    if (deleteChoice > 0 && deleteChoice <= products.Count)
    {
        Product productToRemove = products[deleteChoice - 1];
        products.RemoveAt(deleteChoice - 1);
        Console.WriteLine($"\n{productToRemove.Name} has been deleted!!!");
    }
    else
    {
        Console.WriteLine("invalid product number, please try again...");
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Enter your product's name:");
    string name = Console.ReadLine();

    Console.WriteLine("Enter your product's asking price:");
    decimal askingPrice = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Is your product:");
    int counter = 1;
    foreach (ProductType type in productTypes)
    {
        Console.WriteLine($"{counter++}. {type.Title}");
    }

    int typeChoice = int.Parse(Console.ReadLine());

    Product newProduct = new Product
    {
        Name = name,
        Price = askingPrice,
        ProductTypeId = productTypes[typeChoice - 1].Id,
    };

    products.Add(newProduct);
    Console.WriteLine($"\n{name} has been added to the available products!");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
    Console.WriteLine("Enter the number of the product you'd like to update:");

    int productChoice = int.Parse(Console.ReadLine()) - 1;

    if (productChoice >= 0 && productChoice < products.Count)
    {
        Product product = products[productChoice];

        Console.WriteLine("Enter new name:");
        string newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
        {
            product.Name = newName;
        }

        Console.WriteLine("Enter new price:");
        string newPrice = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newPrice))
        {
            product.Price = decimal.Parse(newPrice);
        }

        Console.WriteLine("Enter new product type number:");
        foreach (ProductType type in productTypes)
        {
            Console.WriteLine($"{type.Id}. {type.Title}");
        }
        string newType = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newType))
        {
            int typeId = int.Parse(newType);
            if (productTypes.Any(type => type.Id == typeId))
            {
                product.ProductTypeId = typeId;
            }
        }
    }
}

// don't move or change this!
public partial class Program { }
