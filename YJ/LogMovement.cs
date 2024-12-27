using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour
{
    public float rotSpeed;
    // Start is called before the first frame update
    void Start() //게임을 실행시키는 순간 실행되는 함수
    {
        rotSpeed = 15f;
    }

    // Update is called once per frame
    void Update() //매 프레임마다 실행되는 함수
    {
        transform.Rotate(new Vector3(0 ,rotSpeed * Time.deltaTime, 0));
    }
}
