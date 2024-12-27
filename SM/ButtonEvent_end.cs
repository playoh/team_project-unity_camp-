using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvent_last : MonoBehaviour
{

    public Button restartBotton;
    public Button backtomainBotton;

    public void isRestart()
    {
        Debug.Log("재시작");
        SceneManager.LoadScene(1);        
    }

    public void isBacktomain()
    {
        Debug.Log("처음으로");
        SceneManager.LoadScene(0);
    }
}
