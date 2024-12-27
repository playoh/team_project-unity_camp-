// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class PlayerMove : MonoBehaviour
// {
//     public float speed;
//     public float turnSpeed;
//     public float jumpPower;
//     public int itemCount;
//     public Rigidbody rigid;
//     public GameManager GM;
//     public Animator playerAnimator;
//     public float fireCoolTime;
//     public GameObject bullet;
//     public Transform firePosition;
//     private Vector2 input;

//     private Vector3 targetDirection;
//     private Quaternion targetRotation;
//     private bool isJump;

//     void Start()
//     {
//         rigid = GetComponent<Rigidbody>();
//         StartCoroutine(Fire(fireCoolTime));
//     }

//     void Update()
//     {
//         input.x = Input.GetAxisRaw("Horizontal");
//         input.y = Input.GetAxisRaw("Vertical");

//         // 움직임
//         rigid.AddForce(new Vector3(input.x, 0, input.y) * speed, ForceMode.Impulse);

//         UpdateTargetDirection(); // 카메라를 기준으로 정면 방향 재계산

//         // 회전 처리
//         if (input.magnitude > 0.1f && targetDirection.magnitude > 0.1f) 
//         {
//             Vector3 lookDirection = targetDirection.normalized;
//             targetRotation = Quaternion.LookRotation(lookDirection, transform.up);
//             transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
//         }

//         // 애니메이션
//         playerAnimator.SetBool("isWalking", input.magnitude > 0);

//         // 점프 처리
//         if (Input.GetKeyDown(KeyCode.Space) && !isJump)
//         {
//             playerAnimator.SetTrigger("isJumping");
//             isJump = true;
//             rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
//         }
//     }

//     public void UpdateTargetDirection()
//     {
//         Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
//         forward.y = 0;
//         Vector3 right = Camera.main.transform.TransformDirection(Vector3.right);

//         targetDirection = input.x * right + input.y * forward;
//     }

//     private IEnumerator Fire(float coolTime)
//     {
//         while (true)
//         {
//             if (Input.GetMouseButtonDown(0))
//             {
//                 Instantiate(bullet, firePosition.position, firePosition.rotation);
//                 yield return new WaitForSeconds(coolTime);
//             }
//             yield return null;
//         }
//     }

//     private void OnCollisionEnter(Collision other)
//     {
//         if (other.gameObject.CompareTag("Floor"))
//         {
//             isJump = false;
//         }
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Item"))
//         {
//             GM.GetItem(++itemCount);
//             Destroy(other.gameObject);
//         }
//         else if (other.CompareTag("Finish"))
//         {
//             if (GM.totalCountText.text == GM.currentCountText.text && GM.stage != -1)
//             {
//                 SceneManager.LoadScene(GM.stage + 1);
//             }
//             else if (GM.stage == -1)
//             {
//                 GM.ExitGame();
//             }
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public float turnSpeed = 10f;
    public float jumpPower = 5f;

    [Header("References")]
    public Rigidbody rigid;
    public GameManage GM;

    [Header("Fire Settings")]
    public float fireCooldownTime = 1f;
    public GameObject bulletPrefab;
    public Transform firePosition;

    private Vector2 input;
    private Vector3 targetDirection;
    private Quaternion targetRotation;
    private bool isJump = false;
    private Coroutine fireCoroutine;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        if (GM == null)
        {
            GM = FindObjectOfType<GameManage>();
        }

        if (firePosition == null)
        {
            Debug.LogError("Fire Position is not assigned in the Inspector.");
        }

        fireCoroutine = StartCoroutine(Fire(fireCooldownTime));
    }

    void Update()
    {
        HandleMovementInput();
        HandleRotation();
        HandleJump();
        HandleFireInput();
    }

    void HandleMovementInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(input.x, 0, input.y).normalized * speed;
        rigid.AddForce(movement, ForceMode.Force);
    }

    void HandleRotation()
    {
        UpdateTargetDirection();

        if (input != Vector2.zero && targetDirection.magnitude > 0.1f)
        {
            Vector3 lookDirection = targetDirection.normalized;
            targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            float differenceRotation = targetRotation.eulerAngles.y - transform.eulerAngles.y;
            float newEulerY = transform.eulerAngles.y;

            if (Mathf.Abs(differenceRotation) > 0.1f)
            {
                newEulerY = Mathf.LerpAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, turnSpeed * Time.deltaTime);
            }

            transform.rotation = Quaternion.Euler(0, newEulerY, 0);
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            isJump = true;
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    void HandleFireInput()
    {
        // Fire is handled in the coroutine
    }

    public void UpdateTargetDirection()
    {
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = Camera.main.transform.right;
        right.y = 0;
        right.Normalize();

        targetDirection = input.x * right + input.y * forward;
    }

    private IEnumerator Fire(float coolTime)
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (bulletPrefab != null && firePosition != null)
                {
                    Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
                    yield return new WaitForSeconds(coolTime);
                }
                else
                {
                    Debug.LogError("Bullet Prefab or Fire Position is not assigned.");
                }
            }

            yield return null;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("log"))
        {
            isJump = false;
        }
        else if (other.gameObject.CompareTag("Floor"))
        {
            GM.RestartStage(); // 스테이지 재시작 메서드 호출
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Dead"))
        {
            SceneManager.LoadScene(1);
        }
        if (other.CompareTag("Finish"))
        {
            if (GM.stage != -1)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}


