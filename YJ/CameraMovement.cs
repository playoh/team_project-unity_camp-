using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [Header("Target to Follow")]
    public Transform target; // 따라갈 대상 (Player)

    [Header("Camera Offset Settings")]
    public Vector3 offset = new Vector3(0, 5, -10); // 카메라의 상대적인 위치

    [Header("Smooth Settings")]
    public float smoothSpeed = 0.125f; // 부드럽게 이동하는 속도

    void LateUpdate()
    {
        if (target != null)
        {
            // 목표 위치 계산
            Vector3 desiredPosition = target.position + offset;

            // 부드러운 이동 처리
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // 카메라 위치 업데이트
            transform.position = smoothedPosition;

            // 타겟을 항상 바라보도록 설정
            transform.LookAt(target);
        }
        else
        {
            Debug.LogWarning("Target is not assigned in the FollowCamera script.");
        }
    }
}
