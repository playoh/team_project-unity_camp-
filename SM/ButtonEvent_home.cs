using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    public Button startBotton;
    public Button exitBotton;

    // Start is cal7led before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isStart()
    {
        Debug.Log("����");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex < totalScenes - 1)
        {
            // ���� ������ �̵�
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            // ������ ���̸� ù ��° ������ �̵�
            SceneManager.LoadScene(0);
        }
    }
    public void isExit()
    {
    #if UNITY_EDITOR
            EditorApplication.isPlaying = false; // Unity Editor���� ���� ����
    #else
        Application.Quit(); // ����� ���ӿ��� ����
    #endif
        Debug.Log("����");
    }

}
