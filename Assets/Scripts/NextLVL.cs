using UnityEngine;
using System.Runtime.InteropServices;

public class NextLVL : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RedirectToUrl(string url);

    public void QuitGame()
    {
        string redirectUrl = "https://hotnovels.eu/trial_2";

#if UNITY_WEBGL && !UNITY_EDITOR
        RedirectToUrl(redirectUrl);
#else
        Application.OpenURL(redirectUrl);
#endif
    }
}