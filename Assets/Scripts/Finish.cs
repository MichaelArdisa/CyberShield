using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    public ToDoBehaviour toDo;
    public PMove pm;
    public PBehaviour pb;
    public Scene activeScene;
    public string finSceneName;

    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (toDo.allEnemyKilled == true && activeScene.name == finSceneName)
        {
            winScreen.SetActive(true);
            pm.enabled = false;

        } else if (pb.isDead == true)
            loseScreen.SetActive(true);
    }
}
