using Backend;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddDataAnnotationsLocalization(options => {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(SharedResource));
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add location services
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Configuring location options
builder.Services.Configure<RequestLocalizationOptions>(options => {
    var SupportedCultures = new[] { "en-US", "es-ES", "en", "es" };
    options.SetDefaultCulture(SupportedCultures[0])
            .AddSupportedCultures(SupportedCultures)
            .AddSupportedUICultures(SupportedCultures)
            .RequestCultureProviders = new List<IRequestCultureProvider>
            {
                new AcceptLanguageHeaderRequestCultureProvider(),
                //new QueryStringRequestCultureProvider(),
                //new CookieRequestCultureProvider(),
                //new RouteDataRequestCultureProvider(),
                /*new CustomRequestCultureProvider(async context =>
                {
                    //Here logic to determine the culture

                    //This example simulates getting the culture "es-ES" as the default.
                    string culture = "es-ES";

                    return new ProviderCultureResult(culture);
                })*/
            };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure and enable request-based localization
app.UseRequestLocalization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
