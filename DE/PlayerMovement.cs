using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{   
    public float jump;
    public float speed = 0.1f;
    public Rigidbody rigid;

    public ButtonEvent_end button;
    public GameManager GM;
    bool isJump;
    
    // Start is called before the first frame update
    void Start()
    {   
        isJump = false;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h= Input.GetAxisRaw("Horizontal"); //좌우방향값이 h에 저장
        float v = Input.GetAxisRaw("Vertical"); //수직 값 저장
        
        rigid.AddForce(new Vector3(h,0,v) * speed, ForceMode.Impulse);

        if(Input.GetKeyDown(KeyCode.Space) && !isJump){
            isJump = true;
            rigid.AddForce(new Vector3(0, jump,0), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other){ //play물체가 다른(other) 물체와 부딪혔을떄 실행됨(이미 rigidbody가 추가되었기에에)
        if(other.gameObject.name == "Floor"){ //other, 즉 다른 물체의 이름이 Floor라면
            isJump = false;
        }   
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "restart"){
            SceneManager.LoadScene(2);
        }
        if(other.tag == "finish"){
            print("끝");
            //button.isNext();
            SceneManager.LoadScene(3);
        }
    }
}
