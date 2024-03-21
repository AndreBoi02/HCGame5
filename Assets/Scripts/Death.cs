using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private ObjectPooling objectPooling;
    [SerializeField] private GameObject panel;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            print("Muerto Pa");
            collision.gameObject.SetActive(false);
            panel.SetActive(true);
        }
        if (collision.CompareTag("Floor")) {
            objectPooling.DespawnObject(collision.gameObject);
        }
    }
}
