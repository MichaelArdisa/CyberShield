using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public Scene activeScene;
    public GameObject[] hbObject;
    private GameObject hb0;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        hbObject = GameObject.FindGameObjectsWithTag("HealthBar");
        hb0 = hbObject[0];
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if (menu.activeSelf == false && activeScene.name != "MenuScene" && Input.GetKeyDown(KeyCode.Escape) && fin.isFinish == false)
        //    Pause();

        //else if (menu.activeSelf && activeScene.name != "MenuScene" && Input.GetKeyDown(KeyCode.Escape) && fin.isFinish == false)
        //    Resume();

        if (menu.activeSelf == false && activeScene.name != "MainMenu & Shop" && activeScene.name != "Bedroom" && Input.GetKeyDown(KeyCode.Escape))
            Pause();

        else if (menu.activeSelf && activeScene.name != "MainMenu & Shop" && activeScene.name != "Bedroom" && Input.GetKeyDown(KeyCode.Escape))
            Resume();
    }

    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
        //AudioManager.instance.playSfx("Click");
    }

    public void QuitApp()
    {
        //AudioManager.instance.playSfx("Click");
        Application.Quit();
    }

    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        //AudioManager.instance.playSfx("Click");
    }

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        //AudioManager.instance.playSfx("Click");
    }

    public void RestartLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        //menu.SetActive(false);
        Time.timeScale = 1f;

        // AudioManager.instance.playSfx("Click");
    }

    public void destroyObject(GameObject obj)
    {
        Destroy(obj);
    }

    public void destroyHB()
    {
        Destroy(hb0);
    }

    public void destroyPlayer()
    {
        Destroy(player);
    }
}
