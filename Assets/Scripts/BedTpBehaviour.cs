using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BedTpBehaviour : MonoBehaviour
{
    public JobPanelMove pm;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("kena");
            pm.movePanelIn();
        }
    }
}