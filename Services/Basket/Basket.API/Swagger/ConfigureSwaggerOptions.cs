using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Basket.API.Swagger;

public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var descr in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(descr.GroupName, ProvideApiInfo(descr));
        }
    }

    private OpenApiInfo ProvideApiInfo(ApiVersionDescription descr)
    {
        var info = new OpenApiInfo()
        {
            Title = "Basket API Microservice",
            Version = descr.ApiVersion.ToString(),
            Description = "Fetches details about Basket",
            Contact = new OpenApiContact() { Name = "Duresa FEyisa", Email = "duresafeyisa2022@gmai.com" },
            License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
        };
        if (descr.IsDeprecated)
        {
            info.Description += " API Version has been deprecated!!!";
        }

        return info;
    }
}