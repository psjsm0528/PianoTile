using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Rotation")]
    public float rotationSpeed = 180f;

    [Header("Effect")]
    public GameObject collectEffect; // ���� �Ծ��� �� ����Ʈ ������

    private bool isCollected = false;

    void Update()
    {
        // ���� �� ���� ���¶�� ȸ�� ���
        if (!isCollected)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Player�� ������
        if (other.CompareTag("Player"))
        {
            isCollected = true;

            // ��¦�̴� ����Ʈ ����
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }

            // ����׿� �α�
            Debug.Log("���� ����!");

            // ���� ����
            Destroy(gameObject);
        }
    }
}
