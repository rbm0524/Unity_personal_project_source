using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public string sceneName = "Play";

    void Start()
    {
        Cursor.visible = true;
    }
    public void ClickStart()
    {
        Debug.Log("���� ����");
        SceneManager.LoadScene(sceneName);
    }
}