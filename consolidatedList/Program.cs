using System;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using unList.Individual;

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
int individualsAmount = 0; //Using later to count individuals

//listDownloader.DownloadFile(); // Downloading consolidated list from EU url


string filePath = @"C:\Users\User\OneDrive\Desktop\ConsolidateDlistApp\Consolidated.xml";

// Load the XML document
XDocument xmlDoc = XDocument.Load(filePath);

XElement rootElement = xmlDoc.Root; //Adresses the root element = CONSOLIDATED_LIST


foreach (XElement element in rootElement.Elements())
{
    if (element.Name == "INDIVIDUALS")
    {
        foreach (XElement individualElement in element.Elements("INDIVIDUAL"))
        {
            Individual individual = new Individual()
            {
                DATAID = individualElement.Element("DATAID")?.Value,
                VERSIONNUM = individualElement.Element("VERSIONNUM")?.Value,
                FIRST_NAME = individualElement.Element("FIRST_NAME")?.Value,
                SECOND_NAME = individualElement.Element("SECOND_NAME")?.Value,
                THIRD_NAME = individualElement.Element("THIRD_NAME")?.Value,
                UN_LIST_TYPE = individualElement.Element("UN_LIST_TYPE")?.Value,
                REFERENCE_NUMBER = individualElement.Element("REFERENCE_NUMBER")?.Value,
                LISTED_ON = individualElement.Element("LISTED_ON")?.Value,
                NAME_ORIGINAL_SCRIPT = individualElement.Element("NAME_ORIGINAL_SCRIPT")?.Value,
                COMMENTS1 = individualElement.Element("COMMENTS1")?.Value,
                TITLE = individualElement.Element("TITLE")?.Value,
                DESIGNATION = individualElement.Element("DESIGNATION")?.Value,
                NATIONALITY = individualElement.Element("NATIONALITY")?.Value,
                LIST_TYPE = individualElement.Element("LIST_TYPE")?.Value,
                LIST_DAY_UPDATED = individualElement.Element("LIST_DAY_UPDATED")?.Value,
                INDIVIDUAL_ADDRESS = individualElement.Element("INDIVIDUAL_ADDRESS")?.Value,
                DATE_OF_BIRTH = individualElement.Element("DATE_OF_BIRTH")?.Value,
                PLACE_OF_BIRTH = individualElement.Element("PLACE_OF_BIRTH")?.Value
            };
            individuals.Add(individual);
            individualsAmount++;
        }
    }
}


PrintIndividuals(individuals);














void PrintIndividuals(List<Individual> individuals)
{
    Console.WriteLine();
    Console.WriteLine($"Current individuals list: {individualsAmount}\n");
    Console.WriteLine("--------------------------------------------");

    foreach (var individual in individuals)
     
        Console.WriteLine($"{individual.DATAID} {individual.FIRST_NAME} {individual.SECOND_NAME} {individual.THIRD_NAME}");
}