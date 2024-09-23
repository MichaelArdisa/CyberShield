using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class ShopButtonBehaviour : MonoBehaviour
{
    public GameObject shopButton;
    public Animator anim;
    public GameObject npc;
    public GameObject lappy;

    private void Start()
    {
        npc = GameObject.FindGameObjectWithTag("NpcIrl");
        lappy = GameObject.FindGameObjectWithTag("Interactable");

        lappy.SetActive(false);
        npc.SetActive(false);
        shopButton.SetActive(false);
    }

    private void Update()
    {
        if (shopButton.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("hore");
            anim.SetTrigger("press");

            npc.SetActive(true);
            npc.transform.DOMoveX(8.7f, 1);
            Invoke(nameof(activateLaptop), 1);
        }
    }

    public void activateLaptop()
    {
        lappy.SetActive(true);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
            shopButton.SetActive(true);
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
            shopButton.SetActive(false);
    }
}
