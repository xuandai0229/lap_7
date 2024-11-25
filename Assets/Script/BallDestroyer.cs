using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Hủy bất kỳ đối tượng nào va chạm với vật cản
        Destroy(collision.gameObject);
    }
}
