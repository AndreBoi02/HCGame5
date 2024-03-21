using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMov : MonoBehaviour
{
    public Transform playerTransform;
    public Camera cam;
    private Vector3 offset;
    [SerializeField]private float offsetY;

    void Start() {
        offset = transform.position - playerTransform.position;
    }

    void Update() {
        if (playerTransform.position.y > cam.transform.position.y + offsetY) {
            movCam();
        }
        
    }

    void movCam() {
        Vector3 newPosition = new Vector3(transform.position.x, playerTransform.position.y + offset.y, transform.position.z);
        transform.position = newPosition;
    }
}
