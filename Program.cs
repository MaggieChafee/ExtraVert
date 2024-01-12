using System.Linq.Expressions;
using ExtraVert;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Pathos",
        LightNeeds = 3,
        AskingPrice = 15.00M,
        City = "Asheville, NC",
        Zip = 26478,
        Sold = false
    },
    new Plant()
    {
        Species = "Snake Plant",
        LightNeeds = 1,
        AskingPrice = 22.00M,
        City = "Raleigh, NC",
        Zip = 20520,
        Sold = false
    },
    new Plant()
    {
        Species = "Ficus",
        LightNeeds = 2,
        AskingPrice = 12.00M,
        City = "Richmond, VA",
        Zip = 29562,
        Sold = true
    },
    new Plant()
    {
        Species = "Fiddle-Leaf Fig",
        LightNeeds = 4,
        AskingPrice = 30.00M,
        City = "Charlottesville, VA",
        Zip = 27654,
        Sold = false
    }
};
// *********** METHODS ************

// View All Plants
 void ListPlants()
{
    Console.WriteLine("    **** ALL PLANTS **** ");
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. A {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for ${plants[i].AskingPrice} dollars.");
    }
} 

// Create a Plant
void addPlant()
{
    Console.WriteLine(@"********** POST A PLANT **********

Start by entering the plant species:");

    string plantSpecies = Console.ReadLine().Trim();

    int plantLight = 0;
    while (plantLight > 5 || plantLight < 1)
    {
        Console.WriteLine(@"How much light does your plant need? 
    1. Full Shade
    2. Partial Shade
    3. Not Picky
    4. Some Direct Light
    5. All the Light");
        plantLight = Convert.ToInt32(Console.ReadLine());
    }

    decimal plantPrice = 0.0M;
    while (plantPrice <= 1)
    {
        Console.WriteLine("What is the starting asking price for this plant?");
        plantPrice = Convert.ToDecimal(Console.ReadLine());
    }
    
    string plantCity = null;
    while (plantCity == null)
    {
        Console.WriteLine("Enter the city this plant is being sold from:");
        plantCity = Console.ReadLine().Trim();
    }

    int plantZip = 0;
    while (plantZip == 0) 
    {
        Console.WriteLine("What is the associated Zip code?");
        plantZip = Convert.ToInt32(Console.ReadLine());
    }
    
    bool plantSold = false;

    Plant createPlant = new Plant
    {
        Species = plantSpecies,
        LightNeeds = plantLight,
        AskingPrice = plantPrice,
        City = plantCity,
        Zip = plantZip,
        Sold = plantSold
    };

    plants.Add(createPlant);
    Console.WriteLine(@"
Your plant has been added!
");
}

// ********** Greeting and Main Menu **********
string greeting = @"    **********  Welcome to ExtraVert! ********** 
The best place to browse, buy, and list secondhand plants.";

string options = @"
Choose an option:
    1. Display all Plants
    2. Post a Plant to be Adopted
    3. Adopt a Plant
    4. Delist a Plant
    0. Exit
";

Console.WriteLine(greeting);

void MainMenu()
{
    Console.WriteLine(@"
        Please select a number to continue.");
    Console.WriteLine(options);
}

MainMenu();

string choice = null;
while (choice != "0")
{
    choice = Console.ReadLine().Trim();

    switch (choice)
    {
        case "1":
            Console.Clear();
            ListPlants();
            MainMenu();
            break;
        case "2":
            Console.Clear();
            addPlant();
            MainMenu();
            break;
        case "3":
            Console.Clear();
            Console.WriteLine("Adopt a Plant");
            break;
        case "4":
            Console.Clear();
            Console.WriteLine("Delist a plant");
            break;
        case "0":
            Console.WriteLine("Goodbye");
            break;
        default:
            Console.WriteLine("Invalid entry. Please try again.");
            break;
    }   
}

