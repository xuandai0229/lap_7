using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float xLimit = 10f;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x > xLimit)
        {
            Destroy(gameObject);
        }
    }
}
