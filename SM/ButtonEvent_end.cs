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
        Debug.Log("�����");
        SceneManager.LoadScene(1);        
    }

    public void isBacktomain()
    {
        Debug.Log("ó������");
        SceneManager.LoadScene(0);
    }
}
