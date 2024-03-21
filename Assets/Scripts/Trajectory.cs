using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsNumbers;
    [SerializeField] GameObject dotsParent;
    [SerializeField] GameObject dotsPrefab;
    [SerializeField] float dotSpacing;

    Transform[] dotsList;

    Vector2 pos;
    float timeStamp;

    private void Start() {
        hide();
        prepareDots();
    }

    void prepareDots() {
        dotsList = new Transform[dotsNumbers];

        for (int i = 0; i < dotsNumbers; i++) {
            dotsList[i] = Instantiate(dotsPrefab, null).transform;
            dotsList[i].parent = dotsParent.transform;
        }
    }

    public void uptadeDots(Vector3 ballPos, Vector2 forceApplied) {
        timeStamp = dotSpacing;
        for (int i = 0; i < dotsNumbers; i++) {
            pos.x = (ballPos.x + forceApplied.x * timeStamp);
            pos.y = (ballPos.y + forceApplied.y * timeStamp)-(Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2f;

            dotsList[i].position = pos;
            timeStamp += dotSpacing;
        }
    }

    public void show() {
        dotsParent.SetActive(true);
    }
    
    public void hide() {
        dotsParent.SetActive(false);
    }
}
