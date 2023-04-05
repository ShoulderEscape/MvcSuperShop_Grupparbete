using ShopGeneral.Commands;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using ShopGeneral.Data;

class Verifyproduct
{
    public async void  ProductVerification (IEnumerable <ShopGeneral.Data.Product> products)
    {
        var client = new HttpClient();
        var i = 0;

        foreach (var product in products) 
        {
            i++;
            try
            {
                var response = await client.GetAsync(product.ImageUrl);
                response.EnsureSuccessStatusCode();

                Console.WriteLine($"bild {i} godkänd");
                //Console.WriteLine($"HTTP error: worked flawlessly");
                //var missingImagesDir = ".\\outfiles\\products\\";   
                //var missingImagesPath = Path.Combine(missingImagesDir, $"missingimages-{DateTime.Now:yyyyMMdd}.txt");
                //var errorMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: PorductCommand {product.Id} missing image: {product.ImageUrl}";
                //File.AppendAllText(missingImagesPath, errorMessage + Environment.NewLine);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HTTP error: {e.Message}");
                var missingImagesDir = ".\\outfiles\\products\\";
                var missingImagesPath = Path.Combine(missingImagesDir, $"missingimages-{DateTime.Now:yyyyMMdd}.txt");
                var errorMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: PorductCommand {product.Id} missing image: {product.ImageUrl}";
                File.AppendAllText(missingImagesPath, errorMessage + Environment.NewLine);
            }
        }

    }
}