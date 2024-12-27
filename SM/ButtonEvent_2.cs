using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvent_end : MonoBehaviour
{
    public Timer timer;
    public Button nextBotton;
    public Timer tm;
 

    public void isNext()
    {
        //tm.stopTimer();        
        SceneManager.LoadScene(3);

    }
}
