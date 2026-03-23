# Steps to Reproduce

1. Clone or download this repository
2. Open terminal and navigate to the solution directory:
   ```powershell
   cd PlaywrightSlowMoRepro
   ```
3. Restore NuGet packages:
   ```powershell
   dotnet restore
   ```
4. Build the solution:
   ```powershell
   dotnet build
   ```
5. Install Playwright Chromium browser:
   ```powershell
   cd PlaywrightSlowMoRepro.Tests\bin\Debug\net10.0
   .\playwright.ps1 install chromium
   cd ..\..\..
   ```
6. **Test via command line** (SlowMo WORKS):
   ```powershell
   dotnet test
   ```
   **Expected:** Browser opens with visible 2-second delays between each action  
   **Result:** ✅ SlowMo works correctly

7. **Test via Visual Studio** (SlowMo FAILS):
   - Open `PlaywrightSlowMoRepro.sln` in Visual Studio 2022/2025
   - Open Test Explorer (Test → Test Explorer)
   - Right-click on `TestSlowMoShouldWorkInVisualStudio` test → Run
   
   **Expected:** Browser opens with visible 2-second delays between each action  
   **Result:** ❌ SlowMo is ignored - actions execute at normal speed

## What You Should Observe

**When running via `dotnet test`:**
- Browser launches in headed mode
- Each action has a visible 2-second pause
- You can clearly see each step: navigate → click "Get started" → click "Writing tests"

**When running via Visual Studio Test Explorer:**
- Browser launches in headed mode (HEADED env var works)
- Actions execute immediately with NO delay
- Same test, same `.runsettings` file, but SlowMo setting is ignored
