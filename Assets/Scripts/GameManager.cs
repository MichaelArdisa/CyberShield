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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
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
}
