using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private static Timer timerinstance;
    public TMP_Text elapsedTimeText;
    public float elapsedTime = 0f; // 경과 시간
    public float totalTime = 0f;
    public string score = "";
    public Score s;

    // Start is called before the first frame update
    void Awake()
    {
        // 이미 존재하는 타이머 객체가 있으면, 그 객체를 사용하고 현재 객체는 삭제
        if (timerinstance != null)
        {
            print("유지");
            Destroy(this.gameObject);
        }
        else
        {
            print("파괴");
            timerinstance = this;
            DontDestroyOnLoad(this.gameObject); // 씬 전환 시에도 파괴되지 않도록
        }

        if ((s = GameObject.FindObjectOfType<Score>()) != null)
        {
            s.score.text = score;
            print("성공");
        }else
        {
            print("실패");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        calcTimer();
    }

    private void calcTimer()
    {
        // 경과 시간 계산
        elapsedTime += Time.deltaTime;

        // 분, 초, 밀리초 계산
        int minutes = Mathf.FloorToInt(elapsedTime / 60); // 분
        int seconds = Mathf.FloorToInt(elapsedTime % 60); // 초
        int milliseconds = Mathf.FloorToInt((elapsedTime * 10) % 10); // 밀리초

        // TextMeshPro UI 업데이트
        elapsedTimeText.text = $"Time: {minutes:D2}:{seconds:D2}:{milliseconds}"; // 두 자리 분/초, 세 자리 밀리초
    }

    public void stopTimer()
    {
        totalTime = elapsedTime;
        print(totalTime);

        int minutes = Mathf.FloorToInt(totalTime / 60); // 분
        int seconds = Mathf.FloorToInt(totalTime % 60); // 초
        int milliseconds = Mathf.FloorToInt((totalTime * 10) % 10); // 밀리초

        // TextMeshPro UI 업데이트
        
        score = "YOUR SCORE: " + $"Time: {minutes:D2}:{seconds:D2}:{milliseconds}"; // 두 자리 분/초, 세 자리 밀리초
    }

    // TimerManager 클래스의 유일한 인스턴스를 반환하는 속성
    public static Timer Instance
    {
        get
        {
            return timerinstance;
        }
    }
}
