using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpBehaviour : MonoBehaviour
{
    [SerializeField] private string changeTo;
    //[SerializeField] private 

    private void OnTriggerEnter(Collider tp)
    {
        if (tp.gameObject.tag == "Player")
            changeScene(changeTo);
    }

    void changeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
