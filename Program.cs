using System.Linq.Expressions;
using System.Xml.Serialization;
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

// Adopt a Plant
void adoptPlant()
{
    Console.WriteLine(@"********** ADOPT A PLANT **********

Here are the currently available plants:
");
    List<Plant> availablePlants = plants.Where(s => s.Sold == false).ToList();
    
    if (availablePlants.Count == 0)
    {
        Console.WriteLine("Looks like there are no available plants. Try again later!");
    } else
    {
        
        for (int i = 0; i < availablePlants.Count; i++)
        {
            Console.WriteLine($"{i + 1}. A {availablePlants[i].Species} in {availablePlants[i].City} for ${availablePlants[i].AskingPrice} dollars.");
        }
        Console.WriteLine("Which plant do you want to adopt?");
        Plant chosen = null;
        while (chosen == null)
        {
            try
            {
                int response = int.Parse(Console.ReadLine().Trim());
                chosen = availablePlants[response - 1];

                chosen.Sold = true;

                Console.WriteLine($"Congratulations! You have adopted {chosen.Species}.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please type only integars!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Please choose an existing item only!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Please follow the prompt!");
            }
        }
    }   
}

// Delist a Plant
void delistPlant()
{
    Console.WriteLine(@"********** DELIST A PLANT **********

Which Plant would you like to remove?
");
    ListPlants();
    Plant chosen = null;

    while (chosen == null)
    {
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosen = plants[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integars!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Please follow the prompt!");
        }
    }
    Console.WriteLine($@"Are you sure you want to delete {chosen.Species}?
    1. Yes
    2. No");

    string finalChoice = Console.ReadLine().Trim();

    if (finalChoice == "1")
    {
        plants.Remove(chosen);
        Console.WriteLine($"{chosen.Species} has been removed.");
    } else if (finalChoice == "2")
    {
        Console.WriteLine("Nevermind!");
    } else
    {
        Console.WriteLine("Invalid Entry.");
    }
}

// Plant of the Day
void PlantOfTheDay()
{
    List<Plant> availablePlants = plants.Where(s => s.Sold == false).ToList();
    Random random = new Random();
    int randomIntegar = random.Next(0, availablePlants.Count);
    Plant randomPlant = availablePlants[randomIntegar];

    Console.WriteLine(@$" ********** PLANT OF THE DAY **********

    Our plant of the day is {randomPlant.Species}!

        Location: {randomPlant.City}
        Light Needs: {randomPlant.LightNeeds}
        Price: ${randomPlant.AskingPrice}");
}

// Search for a Plant
void searchPlants()
{
    Console.WriteLine(@" ********** SEARCH FOR A PLANT **********
Find the perfect plant based on lighting where you live. How would you describe the available light where you live?

    1. Full Shade
    2. Partial Shade
    3. Not Picky
    4. Some Direct Light
    5. All the Light");

    int response = int.Parse(Console.ReadLine().Trim());
    List<Plant> matchingPlants = plants.Where(p => p.LightNeeds == response).ToList();
    try
    {
        if (matchingPlants.Count == 0)
        {
            Console.WriteLine("Looks like we don't have any plants for what you are looking for. Sorry!");
        }
        else
        {
            foreach (Plant plant in matchingPlants)
            {
                Console.WriteLine($@"Plants matching your needs:
    {plant.Species}");
            }
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Please type only integars!");
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("Please choose an existing item only!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Console.WriteLine("Please follow the prompt!");
    }
  
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
    5. Plant of the Day 
    6. Search for a Plant
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
            Console.WriteLine("    **** ALL PLANTS **** ");
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
            adoptPlant();
            MainMenu();
            break;
        case "4":
            Console.Clear();
            delistPlant();
            MainMenu();
            break;
        case "5":
            Console.Clear();
            PlantOfTheDay();
            MainMenu();
            break;
        case "6":
            Console.Clear();
            searchPlants();
            MainMenu();
            break;
        case "0":
            Console.WriteLine("Goodbye.");
            break;
        default:
            Console.WriteLine("Invalid entry. Please try again.");
            break;
    }   
}

