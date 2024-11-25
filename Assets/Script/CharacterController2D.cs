using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform shootPoint;

    void Update()
    {
        // Di chuyển nhân vật
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * vertical * moveSpeed * Time.deltaTime);

        // Bắn mũi tên
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootArrow();
        }
    }

    void ShootArrow()
    {
        Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);
    }
}
