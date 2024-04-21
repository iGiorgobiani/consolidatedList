using System;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using Lists;

//Indicating where file shall be downloaded
string filePath = @"C:\Users\User\OneDrive\Desktop\ConsolidateDlistApp\Consolidated.xml";
//Creating lists of individuals and entities
List<Individual> individuals = new List<Individual>(); 
List<Entity> entities = new List<Entity>();
int individualsAmount = 0; //Using later to count individuals
int entitiesAmount = 0; //Using later to count entities
int individualsError = 0;
int entitiesError = 0;
////////////////////////////////////////////////////

listDownloader.DownloadFile(); // Downloading consolidated list from EU url
// Load the XML document
XDocument xmlDoc = XDocument.Load(filePath);
XElement rootElement = xmlDoc.Root; //Adresses the root element = CONSOLIDATED_LIST

createIndividuals(); // Reading from file all entries of individuals and adding them to the list of individuals
createEntities(); // Reading from file all entries of entities and adding them to the list of entities

PrintList(); //Console writing all lists



void createEntities()
{
    foreach (XElement element in rootElement.Elements())
    {
        //Console.WriteLine(element);
        if (element.Name == "ENTITIES")
        {
            foreach (XElement entityElement in element.Elements("ENTITY"))
            {
                Entity entity = new Entity()
                {
                    DATAID = entityElement.Element("DATAID")?.Value,
                    VERSIONNUM = entityElement.Element("VERSIONNUM")?.Value,
                    FIRST_NAME = entityElement.Element("FIRST_NAME")?.Value,
                    UN_LIST_TYPE = entityElement.Element("UN_LIST_TYPE")?.Value,
                    REFERENCE_NUMBER = entityElement.Element("REFERENCE_NUMBER")?.Value,
                    LISTED_ON = entityElement.Element("LISTED_ON")?.Value,
                    COMMENTS1 = entityElement.Element("COMMENTS1")?.Value,
                    LIST_TYPE = entityElement.Element("LIST_TYPE")?.Value,
                    LIST_DAY_UPDATED = entityElement.Element("LIST_DAY_UPDATED")?.Value,
                    ENTITY_ALIAS = entityElement.Element("ENTITY_ALIAS")?.Value,
                    ENTITY_ADDRESS = entityElement.Element("ENTITY_ADDRESS")?.Value
                };
                entities.Add(entity);
                entitiesAmount++;
            }
        }
        else
        {
            entitiesError++;
        }
    }
}
void createIndividuals()
{
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
        else
        {
            individualsError++;
        }
    }
}
void PrintIndividuals(List<Individual> individuals)
    {
        Console.WriteLine();
        Console.WriteLine($"Errors made when searching for individuals: {individualsError}");
        Console.WriteLine($"Current individuals list: {individualsAmount}\n");
        Console.WriteLine("--------------------------------------------");

        foreach (var individual in individuals)

            Console.WriteLine($"{individual.DATAID} {individual.FIRST_NAME} {individual.SECOND_NAME} {individual.THIRD_NAME}");
    }

void PrintEntities(List<Entity> entities)
{
    Console.WriteLine();
    Console.WriteLine($"Errors made when searching for entities: {entitiesError}");
    Console.WriteLine($"Current entities list: {entitiesAmount}\n");
    Console.WriteLine("--------------------------------------------");

    foreach (var entity in entities)

        Console.WriteLine($"{entity.DATAID} {entity.FIRST_NAME}");
}

void PrintList()
{
    Console.WriteLine();
    Console.WriteLine($"Errors made when searching for individuals: {individualsError}");
    Console.WriteLine($"                                  entities: {entitiesError}");
    Console.WriteLine($"Current individuals list: {individualsAmount} ||");
    Console.Write($"                entities: {entitiesAmount}");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write($" || TOTAL = {individualsAmount + entitiesAmount}\n");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine("INDIVIDUALS");
    Console.WriteLine("--------------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;
    foreach (var individual in individuals)
    {
        Console.WriteLine($"{individual.DATAID} {individual.FIRST_NAME} {individual.SECOND_NAME} {individual.THIRD_NAME}");
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine("ENTITIES");
    Console.WriteLine("--------------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;
    foreach (var entity in entities)
    {
        Console.WriteLine($"{entity.DATAID} {entity.FIRST_NAME}");
    }
}