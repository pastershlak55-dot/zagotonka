using UnityEngine;
using System.Runtime.InteropServices;

public class QuitHandler : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void WebGLQuit();

    public void QuitGame()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            WebGLQuit();
#else
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
#endif
    }
}