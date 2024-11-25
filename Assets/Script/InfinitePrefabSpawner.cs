using System.Collections;
using UnityEngine;

public class InfinitePrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] ballPrefabs; // Mảng các Prefab bóng
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;
    [SerializeField] private float fixedY = 5f;
    [SerializeField] private float minGravity = -0.5f;
    [SerializeField] private float maxGravity = -1f;

    void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        while (true)
        {
            SpawnBall();
            yield return new WaitForSeconds(Random.Range(1f, 3f)); // Delay ngẫu nhiên
        }
    }

    void SpawnBall()
    {
        // Tạo quả bóng ngẫu nhiên từ Prefab
        GameObject ball = Instantiate(ballPrefabs[Random.Range(0, ballPrefabs.Length)]);
        ball.transform.position = new Vector3(Random.Range(minX, maxX), fixedY, 0);

        // Cập nhật Rigidbody2D và gravity ngẫu nhiên
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = Random.Range(minGravity, maxGravity);
        }

        // Lấy Animator và kích hoạt animation (nếu có)
        Animator animator = ball.GetComponent<Animator>();
        if (animator != null)
        {
            // Bắt đầu animation (ví dụ: animation bounce)
            animator.SetTrigger("Bounce");  // Chỉ định một trigger để bắt đầu animation
        }
    }
}
