//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>()
{
    new Product
    {
        Name = "Trumpet",
        Price = 899.99m,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Trombone",
        Price = 749.99m,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "French Horn",
        Price = 1299.99m,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Sonnets of Love",
        Price = 19.99m,
        ProductTypeId = 2,
    },
    new Product
    {
        Name = "Modern Verses",
        Price = 24.99m,
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
DisplayMenu();

void DisplayMenu()
{
    string choice = null;
    while (choice != "5")
    {
        Console.WriteLine(
            @"Choose an option
                            1. Display all Products
                            2. Delete a product
                            3. Add a product
                            4. Update a product
                            5. Exit"
        );
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
    }
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    int counter = 1;

    foreach (Product product in products)
    {
        var thisProductType = productTypes.FirstOrDefault(item => item.Id == product.ProductTypeId);
        Console.WriteLine($"{counter++}. {product.Name} --- {thisProductType.Title}");
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
    decimal askingPrice = int.Parse(Console.ReadLine());

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

        Console.WriteLine("\nWhat would you like to update?");
        Console.WriteLine("1. Update name");
        Console.WriteLine("2. Update price");
        Console.WriteLine("4. Update product type");

        string updateThis = Console.ReadLine();

        if (updateThis == "1")
        {
            Console.WriteLine("Enter new name:");
            product.Name = Console.ReadLine();
        }
        else if (updateThis == "2")
        {
            Console.WriteLine("Enter new price:");
            product.Price = decimal.Parse(Console.ReadLine());
        }
        else if (updateThis == "3")
        {
            foreach (ProductType type in productTypes)
            {
                Console.WriteLine($"{type.Id}. {type.Title}");
            }

            Console.WriteLine("Enter new product type number:");

            int newType = int.Parse(Console.ReadLine());

            if (productTypes.Any(type => type.Id == newType))
            {
                product.ProductTypeId = newType;
            }
            else
            {
                Console.WriteLine("That's not a valid type!");
            }
        }
    }
}

// don't move or change this!
public partial class Program { }
