using System;
using System.Net;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Inputs;
using Lists;


//Indicating where file shall be downloaded
string filePath = @"C:\Users\User\OneDrive\Desktop\ConsolidateDlistApp\Consolidated.xml";
string inputPath = @"C:\Users\User\OneDrive\Desktop\ConsolidateDlistApp\input.txt";
string inputName = File.ReadAllText(inputPath); //To save input list

//Creating lists of individuals and entities
List<Individual> individuals = new List<Individual>(); 
List<Entity> entities = new List<Entity>();
List<InputIndividual> inputIndividuals = new List<InputIndividual>(); // Creating list for user input, which later will be compared to list of xml
int individualsAmount = 0; //Using later to count individuals
int entitiesAmount = 0; //Using later to count entities
int individualsError = 0;
int entitiesError = 0;
int inputIndividualsAmount = 0;
////////////////////////////////////////////////////

//listDownloader.DownloadFile(); // Downloading consolidated list from EU url
// Load the XML document
XDocument xmlDoc = XDocument.Load(filePath);
XElement rootElement = xmlDoc.Root; //Adresses the root element = CONSOLIDATED_LIST

//individualInput();

Console.WriteLine($"USER INPUT\n_______________\n\nNAME: {inputName}");
createIndividuals();
inputVsIndividual();








void inputVsIndividual() 
{
    bool similarityFound = false; // Flag to track if any similarity > 75 is found

    for (var i = 0; i < individuals.Count; i++)
    {
        string sumName = $"{individuals[i].FIRST_NAME} {individuals[i].SECOND_NAME} {individuals[i].THIRD_NAME}";
        double similar = CompareStrings(sumName, inputName);

        if (similar > 75)
        {
            Console.WriteLine($"SIMILARITY : {similar}");
            Console.WriteLine("BETWEEN");
            Console.WriteLine($"{sumName} and {inputName}");
            similarityFound = true; // Set flag to true if similarity > 75 is found
        }
    }
    if (!similarityFound)
    {
        Console.WriteLine("No significant similarity has been detected");
    }
} //reports about similarity between user input and individuals list
void individualInput() //Collecting input about individual and adding it to the list for later manipulation
{
    // creating strings where input information will be held
    var firstName = "";
    var secondName = "";
    var thirdName = "";
    var nationality = "";
    var address = ""; 
    var dateOfBirth = ""; //Final version will have a dropdown
    var placeOfBirth = ""; //Final version will have a dropdown

    Console.WriteLine("Information about individual shall be indicated below");
    Console.WriteLine("_________________________________");
    Console.WriteLine("Please indicate first name");
    firstName = Console.ReadLine();
    Console.WriteLine("Please indicate second name");
    secondName = Console.ReadLine();
    Console.WriteLine("Please indicate third name");
    thirdName = Console.ReadLine();
    Console.WriteLine("Please indicate nationality");
    nationality = Console.ReadLine();
    Console.WriteLine("Please indicate address");
    address = Console.ReadLine();
    Console.WriteLine("Please indicate date of birth");
    dateOfBirth = Console.ReadLine();
    Console.WriteLine("Please indicate placeOfBirth");
    placeOfBirth = Console.ReadLine();


    // Create an Individual object with the collected input
    InputIndividual inputIndividual = new InputIndividual
    {
        FIRST_NAME = firstName,
        SECOND_NAME = secondName,
        THIRD_NAME = thirdName,
        NATIONALITY = nationality,
        INDIVIDUAL_ADDRESS = address,
        DATE_OF_BIRTH = dateOfBirth,
        PLACE_OF_BIRTH = placeOfBirth
    };
    inputIndividuals.Add(inputIndividual);
    inputIndividualsAmount++;

    using (StreamWriter writer = new StreamWriter(inputPath))
    {
        writer.WriteLine($"{inputIndividual.FIRST_NAME} {inputIndividual.SECOND_NAME} {inputIndividual.THIRD_NAME}");
    }

    Console.WriteLine($"Text saved to {inputPath}");
} //asks for user input, adds it to the list, writes the list to txt file
static void ReadDataFromFile(string fileRead)
{
    // Read all lines from the text file
    string[] lines = File.ReadAllLines(fileRead);

    // Display each line of the file
    foreach (string line in lines)
    {
        Console.WriteLine(line);
    }
} //reads data from txt file
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
} // creates entities list based on XML file
void createIndividuals() // creates individuals list based on XML file
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
} //creates individuals list based on XML file
void PrintIndividuals(List<Individual> individuals)
    {
        Console.WriteLine();
        Console.WriteLine($"Errors made when searching for individuals: {individualsError}");
        Console.WriteLine($"Current individuals list: {individualsAmount}\n");
        Console.WriteLine("--------------------------------------------");

        foreach (var individual in individuals)

            Console.WriteLine($"{individual.DATAID} {individual.FIRST_NAME} {individual.SECOND_NAME} {individual.THIRD_NAME}");
    } //prints individuals
void PrintEntities(List<Entity> entities)
{
    Console.WriteLine();
    Console.WriteLine($"Errors made when searching for entities: {entitiesError}");
    Console.WriteLine($"Current entities list: {entitiesAmount}\n");
    Console.WriteLine("--------------------------------------------");

    foreach (var entity in entities)

        Console.WriteLine($"{entity.DATAID} {entity.FIRST_NAME}");
} //prints entities
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
} // prints list of individuals and entities
void PrintInputIndividualInput()
{
    Console.WriteLine();
    Console.WriteLine($"Current input individuals list: {inputIndividualsAmount}\n");
    Console.WriteLine("--------------------------------------------");

    foreach (var inputIndividual in inputIndividuals)

        Console.WriteLine($"{inputIndividual.FIRST_NAME}");
} //prints list of input individuals
partial class Program // Compares the two strings based on letter pair matches
{
    static double CompareStrings(string str1, string str2)
    {
        List<string> pairs1 = WordLetterPairs(str1.ToUpper());
        List<string> pairs2 = WordLetterPairs(str2.ToUpper());

        int intersection = 0;
        int union = pairs1.Count + pairs2.Count;

        for (int i = 0; i < pairs1.Count; i++)
        {
            for (int j = 0; j < pairs2.Count; j++)
            {
                if (pairs1[i] == pairs2[j])
                {
                    intersection++;
                    pairs2.RemoveAt(j); // Must remove the match to prevent "AAAA" from appearing to match "AA" with 100% success
                    break;
                }
            }
        }

        return (2.0 * intersection * 100) / union; // returns in percentage
    }

    // Gets all letter pairs for each
    static List<string> WordLetterPairs(string str)
    {
        List<string> allPairs = new List<string>();

        // Tokenize the string and put the tokens/words into an array
        string[] words = Regex.Split(str, @"\s");

        // For each word
        foreach (string word in words)
        {
            if (!string.IsNullOrEmpty(word))
            {
                // Find the pairs of characters
                string[] pairsInWord = LetterPairs(word);

                foreach (string pair in pairsInWord)
                {
                    allPairs.Add(pair);
                }
            }
        }
        return allPairs;

    }


    // Generates an array containing every two consecutive letters in the input string
    static string[] LetterPairs(string str)
    {
        int numPairs = str.Length - 1;
        string[] pairs = new string[numPairs];

        for (int i = 0; i < numPairs; i++)
        {
            pairs[i] = str.Substring(i, 2);
        }
        return pairs;
    }
}

