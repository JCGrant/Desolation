using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveForce;
    public float maxSpeed;
    public float jumpForce;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private int groundLayerMask;
    private bool jumping;
    private bool grounded;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        groundLayerMask = 1 << LayerMask.NameToLayer("Ground");
        jumping = false;
        grounded = false;
    }

    void Update() {
        grounded = Physics2D.Linecast(
            transform.position,
            groundCheck.position,
            groundLayerMask
        );

        if (Input.GetButtonDown("Jump") && grounded) {
            jumping = true;
        }
    }

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");

        if (Mathf.Abs(rb.velocity.x) < maxSpeed) {
            rb.AddForce(Vector2.right * h * moveForce);
        }

        if (jumping) {
            rb.AddForce(Vector2.up * jumpForce);
            jumping = false;
        }
    }
}