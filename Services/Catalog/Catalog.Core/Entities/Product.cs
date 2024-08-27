using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities;

public class Product : BaseEntity
{
    [BsonElement("Name")]
    public required string Name { get; set; }
    public required string Summary { get; set; }
    public required string Description { get; set; }
    public required string ImageFile { get; set; }
    public required ProductBrand Brands { get; set; }
    public required ProductType Types { get; set; }
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }
}