using System;
using System.Threading.Tasks;

public interface IVerifyproductValidator
{
    public void VerifyproductMain(IEnumerable<ShopGeneral.Data.Product> products);

    public async Task<IEnumerable<string>> ProductVerification(IEnumerable<ShopGeneral.Data.Product> products) => new List<string>();
    public void Writetofile(IEnumerable<string> httperrors);
}
