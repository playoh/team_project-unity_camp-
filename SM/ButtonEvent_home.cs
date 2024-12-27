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
        Debug.Log("시작");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex < totalScenes - 1)
        {
            // 다음 씬으로 이동
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            // 마지막 씬이면 첫 번째 씬으로 이동
            SceneManager.LoadScene(0);
        }
    }
    public void isExit()
    {
    #if UNITY_EDITOR
            EditorApplication.isPlaying = false; // Unity Editor에서 게임 중지
    #else
        Application.Quit(); // 빌드된 게임에서 종료
    #endif
        Debug.Log("종료");
    }

}
