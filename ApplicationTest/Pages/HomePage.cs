using Framework.Driver;
using Microsoft.Playwright;

namespace ApplicationTest.Pages;

public interface IHomePage
{
    Task HomeBtnClick();
    Task ShopBtnClick();
    Task ContactBtnClick();
}

public class HomePage : IHomePage
{
    private readonly IPage _page;

    public HomePage(IPlaywrightDriver playwrightDriver) => _page = playwrightDriver.Page.Result;
    
    public async Task HomeBtnClick() => await _page.GetByRole(AriaRole.Link, new() { Name = "Home" }).ClickAsync();
    public async Task ShopBtnClick() => await _page.GetByRole(AriaRole.Link, new() { 
            Name = "Shop",
            Exact = true 
        })
        .ClickAsync();
    public async Task ContactBtnClick() => await _page.GetByRole(AriaRole.Link, new() { Name = "Contact" }).ClickAsync();
}