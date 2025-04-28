using Framework.Driver;
using Microsoft.Playwright;

namespace ApplicationTest.Pages;

public interface IContactPage
{
    Task ClickSubmitBtn();
    Task PopulateMandateFields(string forename, string email, string message);
    ILocator CheckMadateFieldForename();
    ILocator CheckMadateFieldEmail();
    ILocator CheckMadateFieldMessage();
    ILocator LoadingBarLocator();
    ILocator CheckSuccessMessage(string forename);
}

public class ContactPage : IContactPage
{
    private readonly IPage _page;
    public ContactPage(IPlaywrightDriver playwrightDriver) => _page = playwrightDriver.Page.Result;

    private ILocator _forenameLocator => _page.GetByRole(AriaRole.Textbox, new() { Name = "Forename *" });
    private ILocator _emailLocator => _page.GetByRole(AriaRole.Textbox, new() { Name = "Email *" });
    private ILocator _messageLocator => _page.GetByRole(AriaRole.Textbox, new() { Name = "Message *" });
    public async Task ClickSubmitBtn() => await _page.GetByRole(AriaRole.Link, new() { Name = "Submit" }).ClickAsync();
    public async Task PopulateMandateFields(string forename, string email, string message)
    {
        await _forenameLocator.FillAsync(forename);
        await _emailLocator.FillAsync(email);
        await _messageLocator.FillAsync(message);
    }
    public ILocator CheckMadateFieldForename()
    {
        return _page.GetByText("Forename is required");
    }
    public ILocator CheckMadateFieldEmail()
    {
        return _page.GetByText("Email is required");
    }
    public ILocator CheckMadateFieldMessage()
    {
        return _page.GetByText("Message is required");
    }
    public ILocator LoadingBarLocator()
    {
        return _page.Locator(".modal-body");
    }
    public ILocator CheckSuccessMessage(string forename)
    {
        return _page.GetByText($"Thanks {forename}, we appreciate");
    }
}