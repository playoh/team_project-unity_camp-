// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class GameManage : MonoBehaviour
// {
//     public int totalItemCount;
//     public int stage;
//     public TMP_Text totalCountText;
//     public TMP_Text currentCountText;
//     void Awake()
//     {
//         totalCountText.text = totalItemCount.ToString();
//     }
//     public void GetItem(int count){
//         currentCountText.text = count.ToString(); //계속해서 UI를 업뎃 해줌
//     }
//     public void ExitGame(){
//         #if UNITY_EDITOR
//         UnityEditor.EditorApplication.isPlaying = false;
//         #else
//         Application.Quit();
//         #endif
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    [Header("Item Settings")]
    public int totalItemCount = 5;
    public int stage = 1;

    [Header("UI References")]
    public TMP_Text totalCountText;
    public TMP_Text currentCountText;
    

    void Awake()
    {
        if (totalCountText != null)
        {
            totalCountText.text = totalItemCount.ToString();
        }
        else
        {
            Debug.LogError("Total Count Text is not assigned in the Inspector.");
        }

        if (currentCountText != null)
        {
            currentCountText.text = "0";
        }
        else
        {
            Debug.LogError("Current Count Text is not assigned in the Inspector.");
        }
    }
    public void RestartStage()
    {
        // 현재 스테이지를 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GetItem(int count)
    {
        if (currentCountText != null)
        {
            currentCountText.text = count.ToString();
        }
        else
        {
            Debug.LogError("Current Count Text is not assigned in the Inspector.");
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
