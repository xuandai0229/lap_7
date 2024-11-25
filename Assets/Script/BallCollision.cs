using UnityEngine;
using System.Collections;

public class BallCollision : MonoBehaviour
{
    public GameObject explosionEffect; // Prefab hiệu ứng vụ nổ
    public float explosionDuration = 0.1f; // Thời gian hiệu ứng vụ nổ tồn tại (giảm xuống nhanh hơn, ví dụ 0.1 giây)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow")) // Kiểm tra nếu va chạm với mũi tên
        {
            // Tạo hiệu ứng vụ nổ tại vị trí của bóng
            if (explosionEffect != null)
            {
                GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                // Gọi Coroutine để hủy hiệu ứng vụ nổ sau một khoảng thời gian ngắn
                StartCoroutine(DestroyExplosionAfterTime(explosion, explosionDuration));
            }

            // Hủy mũi tên và bóng ngay lập tức
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    // Coroutine để hủy hiệu ứng vụ nổ sau thời gian chờ
    private IEnumerator DestroyExplosionAfterTime(GameObject explosion, float delay)
    {
        yield return new WaitForSeconds(delay); // Đợi thời gian `delay` trước khi hủy
        Destroy(explosion); // Hủy hiệu ứng vụ nổ
    }
}
