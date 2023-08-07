using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma",            2021,   "Canary Is",    2426,   "Stratovolcano"),
    new Eruption("Villarrica",          1963,   "Chile",        2847,   "Stratovolcano"),
    new Eruption("Chaiten",             2008,   "Chile",        1122,   "Caldera"),
    new Eruption("Kilauea",             2018,   "Hawaiian Is",  1122,   "Shield Volcano"),
    new Eruption("Hekla",               1206,   "Iceland",      1490,   "Stratovolcano"),
    new Eruption("Taupo",               1910,   "New Zealand",  760,    "Caldera"),
    new Eruption("Lengai, Ol Doinyo",   1927,   "Tanzania",     2962,   "Stratovolcano"),
    new Eruption("Santorini",           46,     "Greece",       367,    "Shield Volcano"),
    new Eruption("Katla",               950,    "Iceland",      1490,   "Subglacial Volcano"),
    new Eruption("Aira",                766,    "Japan",        1117,   "Stratovolcano"),
    new Eruption("Ceboruco",            930,    "Mexico",       2280,   "Stratovolcano"),
    new Eruption("Etna",                1329,   "Italy",        3320,   "Stratovolcano"),
    new Eruption("Bardarbunga",         1477,   "Iceland",      2000,   "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
Console.WriteLine("Assignments:");
// 1. Use LINQ to find the first eruption that is in Chile and print the result.
Console.WriteLine("1:");
Console.WriteLine(eruptions.Where(c => c.Location == "Chile" ).OrderBy(c => c.Year).First());

// 2. Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
Console.WriteLine("2:");
if (eruptions.Any(c => c.Location == "Hawaiian Is"))
{
    Console.WriteLine(eruptions.Where(c => c.Location == "Hawaiian Is").First());
}
else
{
    Console.WriteLine("No Hawaiian Is Eruption found.");
}

// 3.Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."
Console.WriteLine("3:");
if (eruptions.Any(c => c.Location == "Greenland"))
{
    Console.WriteLine(eruptions.Where(c => c.Location == "Greenland").First());
}
else
{
    Console.WriteLine("No Greenland Eruption found.");
}

// 4. Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
Console.WriteLine("4:");
Console.WriteLine(eruptions.OrderBy(c => c.Year).FirstOrDefault(c => c.Location == "New Zealand" && c.Year > 1900));

// 5.Find all eruptions where the volcano's elevation is over 2000m and print them.
Console.WriteLine("5:");
IEnumerable<Eruption> eruptionElevation2000 = eruptions.Where(c => c.ElevationInMeters > 2000);
PrintEach(eruptionElevation2000, "Elevation over 2000m:");

// 6. Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
Console.WriteLine("6:");
IEnumerable<Eruption> eruptionsL = eruptions.Where(c => c.Volcano[0] == 'L');
PrintEach(eruptionsL, string.Format("There are {0} eruption(s) found:", eruptionsL.Count()));


// 7. Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
Console.WriteLine("7:");
int highestElevation = eruptions.Max(c => c.ElevationInMeters);
Console.WriteLine($"The highest elevation is {highestElevation} meters.");

// 8. Use the highest elevation variable to find and print the name of the Volcano with that elevation.
Console.WriteLine("8:");
Eruption highestVolcano = eruptions.Single(c => c.ElevationInMeters == highestElevation);
Console.WriteLine($"Highest volcano name: {highestVolcano.Volcano}");

// 9. Print all Volcano names alphabetically.
Console.WriteLine("9:");
IEnumerable<Eruption> allVolcanoNamesAZ = eruptions.OrderBy(c => c.Volcano);
foreach(Eruption volcano in allVolcanoNamesAZ)
{
    Console.WriteLine(volcano.Volcano);
}

// 10. Print the sum of all the elevations of the volcanoes combined.
Console.WriteLine("10:");
int volcanoHeightSum = eruptions.Select(c => c.ElevationInMeters).Sum();
Console.WriteLine($"Sum of all volcano heights: {volcanoHeightSum} meters");

// 11. Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)
Console.WriteLine("11:");
bool volcanos2000 = eruptions.Any(c => c.Year == 2000);
Console.WriteLine(volcanos2000?"Volcanoes have erupted in the year 2000.":"No volcanoes erupted in the year 2000.");

// 12. Find all stratovolcanoes and print just the first three (Hint: look up Take)
Console.WriteLine("12:");
IEnumerable<Eruption> stratovolcanoes3 = eruptions.Where(c => c.Type == "Stratovolcano").Take(3);
PrintEach(stratovolcanoes3, "3 stratovolcanoes:");

// 13. Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
Console.WriteLine("13:");
IEnumerable<Eruption> eruptionsBefore1000 = eruptions.Where(c => c.Year < 1000).OrderBy(c => c.Volcano);
PrintEach(eruptionsBefore1000, "Eruptions before the year 1000 CE:");

// 14. Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
Console.WriteLine("14:");
string[] eruptionsBefore1000Names = eruptions.Where(c => c.Year < 1000).OrderBy(c => c.Volcano).Select(c => c.Volcano).ToArray();
Console.WriteLine("{0}", String.Join("\n", eruptionsBefore1000Names));

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
