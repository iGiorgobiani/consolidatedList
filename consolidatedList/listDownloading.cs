using System.Net;

public class listDownloader
{
    public static void Main(string[] args)
    {
        DownloadFile();
    }

    public static void DownloadFile()
    {
        string url = "https://scsanctions.un.org/resources/xml/en/consolidated.xml";
        string downloadPath = @"C:\Users\User\OneDrive\Desktop\ConsolidateDlistApp\Consolidated.xml";

        using (WebClient client = new WebClient())
        {
            client.DownloadFile(url, downloadPath);
        }

        Console.WriteLine("File downloaded successfully.");
    }
}