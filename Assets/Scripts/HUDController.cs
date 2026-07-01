using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HUDController : MonoBehaviour
{

    public Slider healthSlider;
    public GameObject gameOverScreen;
    public TMP_Text ammoDisplay;
    public GameObject pistolImg;
    public GameObject ShotgunImg;
    public GameObject MachinegunImg;
    private int ammoCount;
    public playerController playerControllerScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void ToggleGameOver()
    {
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetPistolHUD()
    {
        pistolImg.SetActive(true);
        ShotgunImg.SetActive(false);
        MachinegunImg.SetActive(false);
        ammoDisplay.SetText("-");
    }
    public void SetShotgunHUD()
    {
        pistolImg.SetActive(false);
        ShotgunImg.SetActive(true);
        MachinegunImg.SetActive(false);
        ammoCount = 30;
        ammoDisplay.SetText("30");
    }
    public void SetMachinegunHUD()
    {
        pistolImg.SetActive(false);
        ShotgunImg.SetActive(false);
        MachinegunImg.SetActive(true);
        ammoCount = 100;
        ammoDisplay.SetText("100");
    }

    public void UseAmmo()
    {
        ammoCount -= 1;
        ammoDisplay.SetText(""+ammoCount);

        if (ammoCount <= 0)
        {
            playerControllerScript.NoAmmo();
        }

        
    }
}
