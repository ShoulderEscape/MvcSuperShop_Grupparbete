public class Verifyproduct : IVerifyproductValidator
{
    public void VerifyproductMain(IEnumerable<ShopGeneral.Data.Product> products)
    {
        var task = ProductVerification(products);
      
        task.Wait();
        Writetofile(task.Result);
    }

    private async Task<IEnumerable<string>> ProductVerification(IEnumerable<ShopGeneral.Data.Product> products)
    {
        var client = new HttpClient();
        var i = 0;
        var httperrorlist = new List<string>();

        foreach (var product in products)
        {
            i++;
            try
            {
                var response = await client.GetAsync(product.ImageUrl);
                response.EnsureSuccessStatusCode();

                //Console.WriteLine($"bild {i} godkänd");
                //var errorMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: Product {product.Id} missing image: {product.ImageUrl}";
                //httperrorlist.Add(errorMessage); (MANUAL TEST)
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HTTP error: {e.Message}");
                var errorMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: Product {product.Id} missing image: {product.ImageUrl}";
                httperrorlist.Add(errorMessage);
            }

        }
        return httperrorlist;
    }
    public void Writetofile(IEnumerable<string> httperrors)
    {
        var missingImagesDir = ".\\outfiles\\products\\";
        var missingImagesPath = Path.Combine(missingImagesDir, $"missingimages-{DateTime.Now:yyyyMMdd}.txt");

        using (StreamWriter streamWriter = new StreamWriter(missingImagesPath))
        {
            foreach (var httperror in httperrors)
            {
                Console.WriteLine(" wrote to file ");
                //File.AppendAllText(missingImagesPath, httperror + Environment.NewLine);
                streamWriter.WriteLine(httperror+Environment.NewLine);
            }
        }



}

}