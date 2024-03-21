using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Vars
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    public bool onGround;

    [HideInInspector] public Vector3 pos { get { return transform.position; } }
    #endregion

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    public void push(Vector2 force) {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void activateRb() {
        rb.isKinematic = false;
    }

    public void desactivateRb() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Floor")) {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Floor")) {
            onGround = false;
        }
    }
}
