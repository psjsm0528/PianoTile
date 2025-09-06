using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Rotation")]
    public float rotationSpeed = 180f;

    [Header("Effect")]
    public GameObject collectEffect; // 코인 먹었을 때 이펙트 프리팹

    private bool isCollected = false;

    void Update()
    {
        // 아직 안 먹힌 상태라면 회전 계속
        if (!isCollected)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Player가 닿으면
        if (other.CompareTag("Player"))
        {
            isCollected = true;

            // 반짝이는 이펙트 생성
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }

            // 디버그용 로그
            Debug.Log("코인 먹음!");

            // 코인 제거
            Destroy(gameObject);
        }
    }
}
