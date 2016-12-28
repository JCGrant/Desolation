using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float maxSpeed;

    public float moveForce;
    public float jumpForce;
    public float thrustForce;

    public int maxThrustPoints;

    public Transform groundCheck;

    private Rigidbody2D rb;

    private int groundLayerMask;

    private bool jumping;
    private bool grounded;
    private bool thrusting;

    private int thrustPoints;

    private GameObject thrustFlame;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        groundLayerMask = 1 << LayerMask.NameToLayer("Ground");
        jumping = false;
        grounded = false;
        thrustFlame = transform.Find("Thrust Flame").gameObject;
        thrustPoints = maxThrustPoints;
        InvokeRepeating("Regenerate", 1.0f, 1.0f);
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

        thrusting = Input.GetKey(KeyCode.LeftShift) && thrustPoints > 0;
        thrustFlame.SetActive(thrusting);
    }

    private void Regenerate() {
        if (thrustPoints < maxThrustPoints) {
            thrustPoints += 1;
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

        if (thrusting) {
            rb.AddForce((Vector2.right + Vector2.up) * thrustForce);
            thrustPoints -= 1;
        }
    }
}