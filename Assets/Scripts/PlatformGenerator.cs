using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private ObjectPooling objectPooling;
    [SerializeField] private Transform playerTransform;
    public float spawnY = 0.5f;
    
    [SerializeField] private float distanceBetweenPlatforms = 5.0f;
    [SerializeField] private float playerProximity = 2.0f;

    public void Start() {
        spawnPlatform(new Vector3 (0, .5f, 0));
    }

    void Update() {
        if (playerTransform.position.y > (spawnY - playerProximity)) {
            spawnPlatform();
        }
    }

    void spawnPlatform() {
        float spawnX = Random.Range(-2.0f, 2.0f);
        spawnY += distanceBetweenPlatforms;
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
        GameObject tempObj = objectPooling.RequestObject();
        tempObj.transform.position = spawnPosition;
    }
    
    void spawnPlatform(Vector3 firstPos) {
        float spawnX = Random.Range(-2.0f, 2.0f);
        Vector3 spawnPosition = new Vector3(spawnX, firstPos.y, 0);
        GameObject tempObj = objectPooling.RequestObject();
        tempObj.transform.position = spawnPosition;
    }
}
