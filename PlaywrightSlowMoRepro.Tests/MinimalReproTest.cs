using Microsoft.Playwright;
using Microsoft.Playwright.Xunit.v3;
using Xunit;

namespace PlaywrightSlowMoRepro.Tests;

public class MinimalReproTest : PageTest
{
    [Fact]
    public async Task TestSlowMo()
    {
        await Page.GotoAsync("https://playwright.dev/dotnet");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Generating tests" }).ClickAsync();
        Assert.NotNull(Page);
    }
}