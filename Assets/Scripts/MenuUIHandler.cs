using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Text Username;
    
    public void StartNew()
    {
        if (string.IsNullOrEmpty(Username.text))
        {
            DataManager.Instance.Username = "Noname";
        }
        else
        {
            DataManager.Instance.Username = Username.text.ToString();
        }
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
