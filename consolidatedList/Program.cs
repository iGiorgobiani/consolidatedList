using System;
using System.Net;
using unList.Individual;


listDownloader.DownloadFile(); // Downloading consolidated list from EU url

List<Individual> individuals = new List<Individual>(); //creation of list of individuals
Individual individual1 = new Individual()
{
    DATAID = "12345",
    VERSIONNUM = "1.0",
    FIRST_NAME = "John",
    SECOND_NAME = "Doe",
    THIRD_NAME = "Smith",
    UN_LIST_TYPE = "Terrorist",
    REFERENCE_NUMBER = "UN123456",
    LISTED_ON = "2023-04-10",
    NAME_ORIGINAL_SCRIPT = "John Doe Smith",
    COMMENTS1 = "Suspected terrorist activity",
    TITLE = "Mr.",
    DESIGNATION = "Leader",
    NATIONALITY = "US",
    LIST_TYPE = "UN List",
    LIST_DAY_UPDATED = "2023-04-10",
    INDIVIDUAL_ALIAS = "Johnny",
    INDIVIDUAL_ADDRESS = "123 Main St, Anytown, USA",
    DATE_OF_BIRTH = "1980-01-01",
    PLACE_OF_BIRTH = "New York, USA"
}; //Tester individual1
individuals.Add(individual1); // Add individual1 to the list


PrintIndividuals(individuals);














static void PrintIndividuals(List<Individual> individuals)
{
    Console.WriteLine();
    Console.WriteLine("Current individuals list:\n");
    Console.WriteLine("--------------------------------------------");

    foreach (var individual in individuals)
     
        Console.WriteLine($"{individual.DATAID} {individual.FIRST_NAME} {individual.SECOND_NAME} {individual.THIRD_NAME}");
}