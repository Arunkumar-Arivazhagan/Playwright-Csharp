using Framework.Driver;
using Microsoft.Playwright;
namespace ApplicationTest.Pages;

public interface IShopPage
{
    Task GoToCart();
}

public class ShopPage : IShopPage
{
    private readonly IPage _page;
    public ShopPage(IPlaywrightDriver playwrightDriver) => _page = playwrightDriver.Page.Result;
    public async Task GoToCart()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = "Cart" }).ClickAsync();
    }
}