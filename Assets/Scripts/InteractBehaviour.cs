using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : MonoBehaviour
{
    public GameObject iKey;
    public GameObject jobMenu;

    // Start is called before the first frame update
    void Start()
    {
        iKey = GameObject.FindGameObjectWithTag("InteractKey");
        iKey.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && iKey.activeSelf)
            jobMenu.SetActive(true);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Interactable")
        {
            iKey.SetActive(true);
        }
            
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Interactable")
            iKey.SetActive(false);
    }
}
