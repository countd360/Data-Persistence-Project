using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Title : MonoBehaviour
{
    public InputField userNameText;

    private void Start()
    {
        Debug.Log("Title start: " + DataManager.Instance.lastUserName);
        userNameText.text = DataManager.Instance.lastUserName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataManager.Instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OnUserNameChanged(string name)
    {
        DataManager.Instance.lastUserName = name;
    }
}
