using Framework.Driver;
using Microsoft.Playwright;
namespace ApplicationTest.Pages;

public interface ICartPage
{
    Task<decimal> GetSubtotal(string productName);
    Task<decimal> GetPrice(string productName);
    Task<int> GetQuantity(string productName);
    Task<decimal> GetTotal();
}

public class CartPage : ICartPage
{
    private readonly IPage _page;
    public CartPage(IPlaywrightDriver playwrightDriver) => _page = playwrightDriver.Page.Result;
    public async Task<decimal> GetSubtotal(string productName)
    {
        // Assuming each product row has a class like 'cart-item' and subtotal in a specific element
        var subtotalText = await _page.Locator($"//tr[contains(@class, 'cart-item') and .//td[contains(text(), '{productName}')]]//td[@class='subtotal']").InnerTextAsync();
        // Remove any currency symbols and convert to decimal
        return decimal.Parse(subtotalText.Replace("$", "").Trim());
    }

    public async Task<decimal> GetPrice(string productName)
    {
        // Assuming price is in a specific cell in the product row
        var priceText = await _page.Locator($"//tr[contains(@class, 'cart-item') and .//td[contains(text(), '{productName}')]]//td[@class='price']").InnerTextAsync();
        return decimal.Parse(priceText.Replace("$", "").Trim());
    }

    public async Task<int> GetQuantity(string productName)
    {
        // Assuming quantity is in an input field or a specific cell
        var quantityValue = await _page.Locator($"//tr[contains(@class, 'cart-item') and .//td[contains(text(), '{productName}')]]//input[@class='quantity']").InputValueAsync();
        if (string.IsNullOrEmpty(quantityValue))
        {
            quantityValue = await _page.Locator($"//tr[contains(@class, 'cart-item') and .//td[contains(text(), '{productName}')]]//td[@class='quantity']").InnerTextAsync();
        }
        return int.Parse(quantityValue);
    }

    public async Task<decimal> GetTotal()
    {
        // Assuming the total is in an element with a specific class or ID
        var totalText = await _page.Locator("//tfoot//td[@id='total']").InnerTextAsync();
        return decimal.Parse(totalText.Replace("$", "").Trim());
    }
}