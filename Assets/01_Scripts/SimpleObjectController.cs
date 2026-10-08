using UnityEngine;

public class SimpleObjectController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(
            horizontal,
            0f,
            vertical
        );

        movement = movement.normalized;

        transform.position +=
            movement * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision dengan: {collision.gameObject.name}");
    }
}