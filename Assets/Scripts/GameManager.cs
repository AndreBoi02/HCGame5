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

    private Camera cam;

    public Ball ball;
    [SerializeField] float pushForce = 4f;

    private bool isDraggin = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    private void Start(){
        cam = Camera.main;
        ball.DesactivateRb();
    }

    private void Update(){
        if (Input.GetMouseButtonDown(0)){
            isDraggin = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0)){
            isDraggin = false;
            OnDragEnd();
        }
        if (isDraggin){
            OnDrag();
        }
    }

    private void OnDragStart(){
        ball.DesactivateRb();
    }

    private void OnDrag(){

    }

    private void OnDragEnd(){

    }
}
