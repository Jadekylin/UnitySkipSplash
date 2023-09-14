#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class SetSplashBlack : IPreprocessBuildWithReport 
{
    public int callbackOrder { get; }
    
    public void OnPreprocessBuild(BuildReport report) 
    {
        PlayerSettings.SplashScreen.unityLogoStyle = PlayerSettings.SplashScreen.UnityLogoStyle.LightOnDark;
        PlayerSettings.SplashScreen.backgroundColor = Color.black;
    }
}
#endif
