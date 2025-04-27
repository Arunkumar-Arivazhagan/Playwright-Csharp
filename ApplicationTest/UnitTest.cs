using ApplicationTest.Pages;
using AutoFixture.Xunit2;
using Framework.Config;
using Framework.Driver;
using Microsoft.Playwright;

namespace ApplicationTest;


public class UnitTest
{
    private readonly IPlaywrightDriver _playwrightDriver;
    private readonly TestSettings _testSettings;
    private readonly IContactPage _contactPage;
    private readonly IHomePage _homePage;
    // private readonly IShopPage _shopPage;

    public UnitTest(IPlaywrightDriver playwrightDriver, TestSettings testSettings, IContactPage contactPage, IHomePage homePage)
    //IShopPage shopPage
    {
        _playwrightDriver = playwrightDriver;
        _testSettings = testSettings;
        _contactPage = contactPage;
        _homePage = homePage;
        // _shopPage = shopPage;
    }

    [Fact]
    public async Task TestCase1()
    {
        //Navigate
        var page = await _playwrightDriver.Page;
        await page.GotoAsync(_testSettings.ApplicationUrl);
        
        //Actions
        await _homePage.ContactBtnClick();
        await _contactPage.ClickSubmitBtn();
        
        //Assertion
        var forenameMandate = _contactPage.CheckMadateFieldForename();
        await Assertions.Expect(forenameMandate).ToBeVisibleAsync();
        var emailMandate = _contactPage.CheckMadateFieldEmail();
        await Assertions.Expect(emailMandate).ToBeVisibleAsync();
        var messageMandate = _contactPage.CheckMadateFieldMessage();
        await Assertions.Expect(messageMandate).ToBeVisibleAsync();
        
        //Action
        await _contactPage.PopulateMandateFields("Test", "test@gmail.com", "Test");
        
        //Assertion
        await Assertions.Expect(forenameMandate).Not.ToBeVisibleAsync();
        await Assertions.Expect(emailMandate).Not.ToBeVisibleAsync();
        await Assertions.Expect(messageMandate).Not.ToBeVisibleAsync();
        
        //Action
        await _contactPage.ClickSubmitBtn();
    }
    [Theory]
    [InlineData("Test1","Test1@gmail.com","Test1")]
    [InlineData("Test2","Test2@gmail.com","Test2")]
    [InlineData("Test3","Test3@gmail.com","Test3")]
    [InlineData("Test4","Test4@gmail.com","Test4")]
    [InlineData("Test5","Test5@gmail.com","Test5")]
    public async Task TestCase2(string forename, string email, string message)
    {
        //Navigate
        var page = await _playwrightDriver.Page;
        await page.GotoAsync(_testSettings.ApplicationUrl);
        
        //Actions
        await _homePage.ContactBtnClick();
        await _contactPage.PopulateMandateFields(forename, email, message);
        await _contactPage.ClickSubmitBtn();
        
        //Assertion
        var loadingBarLocator = _contactPage.LoadingBarLocator();
        await Assertions.Expect(loadingBarLocator)
            .ToBeHiddenAsync(new LocatorAssertionsToBeHiddenOptions { Timeout = 15000 });
        var successMessage = _contactPage.CheckSuccessMessage(forename);
        await Assertions.Expect(successMessage).ToBeVisibleAsync();
    }
    
}