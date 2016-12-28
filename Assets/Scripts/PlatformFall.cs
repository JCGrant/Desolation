using UnityEngine;

public class PlatformFall : MonoBehaviour {

    public float fallDelay;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Invoke("Fall", fallDelay);
        }
    }

    void Fall() {
        rb.isKinematic = false;
    }
}