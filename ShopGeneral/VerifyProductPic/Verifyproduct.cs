using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Verifyproduct
{
    public void ProducVerification  
    {
        var client = new HttpClient();

        Console.Write("Enter the URL of the image to fetch: ");
        var imageUrl = Console.ReadLine();
        Console.Write("Enter the product ID: ");
        var productId = Console.ReadLine();

        try
        {
            var response = await client.GetAsync(imageUrl);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"HTTP error: {e.Message}");
            var missingImagesDir = ".\\outfiles\\products\\";
            var missingImagesPath = Path.Combine(missingImagesDir, $"missingimages-{DateTime.Now:yyyyMMdd}.txt");
            var errorMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: Product {productId} missing image: {imageUrl}";
            File.AppendAllText(missingImagesPath, errorMessage + Environment.NewLine);
        }
    }
}