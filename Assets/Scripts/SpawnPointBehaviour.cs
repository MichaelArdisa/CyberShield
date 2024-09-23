using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointBehaviour : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform playerPos;
    private PCombat pc;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GetComponent<Transform>();
        Invoke(nameof(spawnPlayer), 0.11f);
    }

    public void spawnPlayer()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PCombat>();

        playerPos.position = spawnPoint.position;
        pc.getMousePos();
    }
} 
