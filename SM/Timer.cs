using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private static Timer timerinstance;
    public TMP_Text elapsedTimeText;
    public float elapsedTime = 0f; // ��� �ð�
    public float totalTime = 0f;
    public string score = "";
    public Score s;

    // Start is called before the first frame update
    void Awake()
    {
        // �̹� �����ϴ� Ÿ�̸� ��ü�� ������, �� ��ü�� ����ϰ� ���� ��ü�� ����
        if (timerinstance != null)
        {
            print("����");
            Destroy(this.gameObject);
        }
        else
        {
            print("�ı�");
            timerinstance = this;
            DontDestroyOnLoad(this.gameObject); // �� ��ȯ �ÿ��� �ı����� �ʵ���
        }

        if ((s = GameObject.FindObjectOfType<Score>()) != null)
        {
            s.score.text = score;
            print("����");
        }else
        {
            print("����");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        calcTimer();
    }

    private void calcTimer()
    {
        // ��� �ð� ���
        elapsedTime += Time.deltaTime;

        // ��, ��, �и��� ���
        int minutes = Mathf.FloorToInt(elapsedTime / 60); // ��
        int seconds = Mathf.FloorToInt(elapsedTime % 60); // ��
        int milliseconds = Mathf.FloorToInt((elapsedTime * 10) % 10); // �и���

        // TextMeshPro UI ������Ʈ
        elapsedTimeText.text = $"Time: {minutes:D2}:{seconds:D2}:{milliseconds}"; // �� �ڸ� ��/��, �� �ڸ� �и���
    }

    public void stopTimer()
    {
        totalTime = elapsedTime;
        print(totalTime);

        int minutes = Mathf.FloorToInt(totalTime / 60); // ��
        int seconds = Mathf.FloorToInt(totalTime % 60); // ��
        int milliseconds = Mathf.FloorToInt((totalTime * 10) % 10); // �и���

        // TextMeshPro UI ������Ʈ
        
        score = "YOUR SCORE: " + $"Time: {minutes:D2}:{seconds:D2}:{milliseconds}"; // �� �ڸ� ��/��, �� �ڸ� �и���
    }

    // TimerManager Ŭ������ ������ �ν��Ͻ��� ��ȯ�ϴ� �Ӽ�
    public static Timer Instance
    {
        get
        {
            return timerinstance;
        }
    }
}
