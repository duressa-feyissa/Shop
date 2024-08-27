using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;
using System.IO;

namespace Catalog.Infrastructure.Data
{
    public static class BrandContextSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
        {
            bool checkBrands = brandCollection.Find(b => true).Any();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SeedData", "brands.json");

            if (!checkBrands)
            {
                try
                {
                    if (!File.Exists(path))
                    {
                        throw new FileNotFoundException($"The file '{path}' was not found.");
                    }

                    var brandsData = File.ReadAllText(path);
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    if (brands != null)
                    {
                        foreach (var item in brands)
                        {
                            brandCollection.InsertOneAsync(item).Wait(); // Ensure completion of async operation
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw; // Re-throw the exception if necessary
                }
            }
        }
    }
}