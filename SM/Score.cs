using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text score; // �ؽ�Ʈ ������Ʈ ����
    public float minFontSize = 30f; // �ּ� ���� ũ��
    public float maxFontSize = 100f; // �ִ� ���� ũ��
    public Color minColor = Color.black; // �ּ� �� (��ο� ��)
    public Color maxColor = Color.white; // �ִ� �� (���� ��)
    private float time;
    public Timer timer;

    // Start is called before the first frame update

    void Start()
    {
        
        // minColor�� #8C9042 ������ ����
        minColor = new Color(0.549f, 0.564f, 0.259f); // #8C9042�� RGB�� ��ȯ�Ͽ� ����

        // maxColor�� �ٸ� �������� ������ �� �ֽ��ϴ� (��: F2FF00)
        maxColor = Color.yellow; // ���÷� maxColor�� yellow�� ����
        timer = GameObject.FindObjectOfType<Timer>();
        if (timer != null)
        {
            timer.stopTimer();
            score.text = timer.score;
            print("���� �ҷ���." + timer.score);
            Destroy(timer);
        }
        else
        {
            print("����");
        }

        print(score.text);

        Destroy(timer);
    }

    void Update()
    {
        // 1�� �ֱ�� ��ȭ�ϵ��� �ð� ���
        time += Time.deltaTime;

        // ���� ũ��: minFontSize���� maxFontSize���� PingPong
        score.fontSize = Mathf.Lerp(minFontSize, maxFontSize, Mathf.PingPong(time, 1));

        // ���� ��: minColor���� maxColor���� PingPong
        score.color = Color.Lerp(minColor, maxColor, Mathf.PingPong(time, 1));

    }

}
