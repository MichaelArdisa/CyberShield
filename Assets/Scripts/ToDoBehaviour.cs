using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToDoBehaviour : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Text tmp;

    private string text;
    private GameObject[] enemies;
    private int enemyCount;
    public int enemyKilled;
    public bool allEnemyKilled;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();

        text = "Eliminate all cyber threats!";
        tmp.text = text;

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        text = "Eliminate all cyber threats! (" + enemyKilled + '/' + enemyCount + ')';
        tmp.text = text;

        //enemyKilled = enemyCount;

        if (!toggle.isOn && enemyKilled == enemyCount)
        {
            toggle.isOn = true;
            allEnemyKilled = true;
        }
            
    }
}
