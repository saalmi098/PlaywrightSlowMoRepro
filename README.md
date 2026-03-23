# Playwright SlowMo Issue - Minimal Reproduction

This is a minimal reproduction project demonstrating that Playwright's `SlowMo` setting in `.runsettings` works with `dotnet test` but is ignored when running tests via Visual Studio Test Explorer.

## Reproduction Steps

### Working: Command Line
Run the test via command line:
```bash
dotnet test
```

- **Expected behavior**: Browser actions execute with 1-second delay between each operation (SlowMo=2000).
- **Actual behavior**: SlowMo works correctly - you'll see visible delays.

### Broken: Visual Studio Test Explorer
1. Open `PlaywrightSlowMoRepro.sln` in Visual Studio
2. Open Test Explorer
3. Right-click on `TestSlowMoShouldWorkInVisualStudio` → Run

- **Expected behavior**: Browser actions execute with 1-second delay between each operation (SlowMo=2000).
- **Actual behavior**: SlowMo is ignored - actions execute at normal speed (no delay).

## Configuration Files

- `tests.runsettings` - Contains Playwright LaunchOptions with SlowMo=2000
- `PlaywrightSlowMoRepro.Tests.csproj` - References the runsettings file via `<RunSettingsFilePath>`

## Environment

- .NET 10.0
- Microsoft.Playwright 1.58.0
- Microsoft.Playwright.Xunit.v3 1.58.0
- xUnit v3.2.2
- Visual Studio 2026 Preview (18.4.0)

## Issue

The `<Playwright><LaunchOptions>` settings from `.runsettings` are not being applied when running tests through Visual Studio Test Explorer, despite the runsettings file being correctly loaded (as shown in Test Output window).

The same configuration works perfectly when running `dotnet test` from command line.
