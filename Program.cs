using ExtraVert;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Pathos",
        LightNeeds = 3,
        AskingPrice = 15.0M,
        City = "Asheville, NC",
        Zip = 26478,
        Sold = false
    },
    new Plant()
    {
        Species = "Snake Plant",
        LightNeeds = 1,
        AskingPrice = 22.0M,
        City = "Raleigh, NC",
        Zip = 20520,
        Sold = false
    },
    new Plant()
    {
        Species = "Eucalyptus",
        LightNeeds = 2,
        AskingPrice = 12.0M,
        City = "Richmond, VA",
        Zip = 29562,
        Sold = true
    },
    new Plant()
    {
        Species = "Lavender",
        LightNeeds = 4,
        AskingPrice = 30.0M,
        City = "Charlottesville, VA",
        Zip = 27654,
        Sold = false
    }
};
// *********** METHODS ************

void ListPlants()
{
    Console.WriteLine(" **** ALL PLANTS **** ");
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }
} 

// Greeting and Main Menu
string greeting = @"    **********  Welcome to ExtraVert! ********** 
The best place to browse, buy, and list secondhand plants.
";

string options = @"Choose an option to begin:
    1. View All Plants";

Console.WriteLine(greeting);
Console.WriteLine(options);
ListPlants();
