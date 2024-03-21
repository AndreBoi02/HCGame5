using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton Class: GameManager
    public static GameManager Instance;

    private void Awake(){
        if (Instance == null){
            Instance = this;
        }
    }
    #endregion

    #region Vars
    private Camera cam;

    [SerializeField] private PlatformGenerator platformGenerator;
    [SerializeField] private ObjectPooling objectPooling;
    [SerializeField] private Ball ball;
    [SerializeField] private Trajectory trajectory;
    [SerializeField] float pushForce = 4f;
    [SerializeField] private GameObject panel;

    private bool isDraggin = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    #endregion

    private void Start() {
        cam = Camera.main;
        ball.desactivateRb();
    }

    private void Update() {
        if (ball.onGround) {
            if (Input.GetMouseButtonDown(0)) {
                isDraggin = true;
                onDragStart();
            }
            if (Input.GetMouseButtonUp(0)) {
                isDraggin = false;
                onDragEnd();
            }
            if (isDraggin) {
                onDrag();
            }
        }
    }

    private void onDragStart() {
        ball.desactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.show();
    }

    private void onDrag() {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        Debug.DrawLine(startPoint, endPoint);

        trajectory.uptadeDots(ball.pos, force);
    }

    private void onDragEnd() {
        ball.activateRb();
        ball.push(force);

        trajectory.hide();
    }

    public void restart() {
        objectPooling.allObjDespawn();
        panel.SetActive(false);
        ball.gameObject.transform.position = new Vector3(3.3f, -4f, 1);
        cam.transform.position = new Vector3(0, 0, -10); ;
        platformGenerator.spawnY = .5f;
        ball.gameObject.SetActive(true);
        platformGenerator.Start();
    }
}
