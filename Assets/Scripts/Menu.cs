using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject menu;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void startGame()
    {
        Time.timeScale = 1.0f;
        level.SetActive(true);
        menu.SetActive(false);
    }
}
