using Microsoft.Playwright;

namespace Framework.Driver;

public interface IPlaywrightDriver
{
    Task<IPage> Page { get; }
    Task<IBrowser> Browser { get; }
    Task<IBrowserContext> BrowserContext { get; }
}