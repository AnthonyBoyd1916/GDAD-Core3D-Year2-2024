using UnityEngine;

public class PlayerControllerRoller : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jppower = 5f;
    [SerializeField] private float jpfalloff = 0.5f;
    [SerializeField] private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jppower, rb.velocity.z);
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * jpfalloff, rb.velocity.z);
        }
    }
}
