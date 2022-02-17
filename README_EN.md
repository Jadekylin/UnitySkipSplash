# UnitySkipSplash

## Intro
- A script for Skipping Unity Logo Splash Screen.

## Usage
- Require Unity2019.4 or higher.
- Put [`SkipSplash.cs`](https://github.com/psygames/UnitySkipSplash/blob/main/SkipSplash.cs) into any folder of your Unity project (but `Editor`).
- All done, build app and enjoy it.

## All Codes
```csharp
/* ---------------------------------------------------------------- */
/*                    Skip Unity Splash Screen                      */
/*                      Create by psygames                          */
/*            https://github.com/psygames/UnitySkipSplash           */
/* ---------------------------------------------------------------- */

#if !UNITY_EDITOR
using UnityEngine;
using UnityEngine.Rendering;

public class SkipSplash
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    private static void BeforeSplashScreen()
    {
#if UNITY_WEBGL
        Application.focusChanged += Application_focusChanged;
#else
        System.Threading.Tasks.Task.Run(AsyncSkip);
#endif
    }

#if UNITY_WEBGL
    private static void Application_focusChanged(bool obj)
    {
        Application.focusChanged -= Application_focusChanged;
        SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
    }

#else
    private static void AsyncSkip()
    {
        SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
    }
#endif

}
#endif
```