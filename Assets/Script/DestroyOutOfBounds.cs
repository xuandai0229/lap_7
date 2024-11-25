using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float yLimit = -6f;

    void Update()
    {
        if (transform.position.y < yLimit)
        {
            Destroy(gameObject);
        }
    }
}
