using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public bool canMove = true; // Adicione esta linha
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!canMove) return; // Adicione esta linha para impedir movimento

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = Camera.main.transform.forward * moveVertical + Camera.main.transform.right * moveHorizontal;
        direction.y = 0;

        rb.AddForce(direction.normalized * moveSpeed);
    }
}
