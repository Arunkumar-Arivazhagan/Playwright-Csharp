using ApplicationTest.Fixture;
using ApplicationTest.Pages;
using Framework.Config;
using Framework.Driver;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationTest;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddSingleton(ConfigReader.ReadConfig())
            .AddScoped<IPlaywrightDriver, PlaywrightDriver>()
            .AddScoped<IPlaywrightDriverInitializer, PlaywrightDriverInitializer>()
            .AddScoped<IContactPage, ContactPage>()
            .AddScoped<IHomePage, HomePage>()
            .AddScoped<IShopPage, ShopPage>()
            .AddScoped<ICartPage, CartPage>()
            .AddScoped<ITestFixtureBase, TestFixtureBase>();
    }
}