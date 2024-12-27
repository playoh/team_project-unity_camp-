using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text score; // 텍스트 컴포넌트 참조
    public float minFontSize = 30f; // 최소 글자 크기
    public float maxFontSize = 100f; // 최대 글자 크기
    public Color minColor = Color.black; // 최소 색 (어두운 색)
    public Color maxColor = Color.white; // 최대 색 (밝은 색)
    private float time;
    public Timer timer;

    // Start is called before the first frame update

    void Start()
    {
        
        // minColor를 #8C9042 색으로 설정
        minColor = new Color(0.549f, 0.564f, 0.259f); // #8C9042을 RGB로 변환하여 설정

        // maxColor를 다른 색상으로 설정할 수 있습니다 (예: F2FF00)
        maxColor = Color.yellow; // 예시로 maxColor를 yellow로 설정
        timer = GameObject.FindObjectOfType<Timer>();
        if (timer != null)
        {
            timer.stopTimer();
            score.text = timer.score;
            print("정보 불러옴." + timer.score);
            Destroy(timer);
        }
        else
        {
            print("실패");
        }

        print(score.text);

        Destroy(timer);
    }

    void Update()
    {
        // 1초 주기로 변화하도록 시간 계산
        time += Time.deltaTime;

        // 글자 크기: minFontSize에서 maxFontSize까지 PingPong
        score.fontSize = Mathf.Lerp(minFontSize, maxFontSize, Mathf.PingPong(time, 1));

        // 글자 색: minColor에서 maxColor까지 PingPong
        score.color = Color.Lerp(minColor, maxColor, Mathf.PingPong(time, 1));

    }

}
