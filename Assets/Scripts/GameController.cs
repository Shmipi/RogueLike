using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int health = 3;

    public bool isPaused;
    public bool levelComplete;

    [SerializeField] GameObject gameOverPanel;

    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject ak;
    [SerializeField] private GameObject shotgun;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        isPaused = false;
        health = 3;
        Time.timeScale = 1;
        levelComplete = false;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
            isPaused = true;
            Cursor.visible = true;
            gameOverPanel.SetActive(true);
        }
    }

    public void TakeDamage()
    {
        health -= 1;
    }

    public void PickUpPistol()
    {
        pistol.SetActive(false);
        ak.SetActive(true);
        shotgun.SetActive(true);
    }

    public void PickUpAK()
    {
        pistol.SetActive(true);
        ak.SetActive(false);
        shotgun.SetActive(true);
    }

    public void PickUpShotgun()
    {
        pistol.SetActive(true);
        ak.SetActive(true);
        shotgun.SetActive(false);
    }
}
