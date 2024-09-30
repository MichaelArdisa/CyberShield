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
    public Animator npcAnim;
    public GameObject lappy;
    public JobPanelMove pm;
    private float npcOrPos;

    private void Start()
    {
        npc = GameObject.FindGameObjectWithTag("NpcIrl");
        lappy = GameObject.FindGameObjectWithTag("Interactable");
        npcAnim = npc.GetComponent<Animator>();

        lappy.SetActive(false);
        npc.SetActive(false);
        shopButton.SetActive(false);

        npcOrPos = npc.transform.position.x;
    }

    private void Update()
    {
        if (shopButton.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("hore");
            anim.SetTrigger("press");

            pm.movePanelIn();

            //npc.SetActive(true);
            //npc.transform.DOMoveX(8.7f, 1);
            //Invoke(nameof(activateLaptop), 1);
        }
    }

    public void activateLaptop()
    {
        lappy.SetActive(true);
    }

    public void npcIdle()
    {
        npcAnim.SetTrigger("npcIdle");
    }

    public void loadLvl()
    {
        // ini ntar di modif jd lebih dinamis pake
        // scriptable object utk ngubah npc mana yg masuk & ngubah deskripsi npc jg

        pm.movePanelBack();
        npc.SetActive(true);
        npcAnim.SetTrigger("npcWalk");

        npc.transform.DOMoveX(npcOrPos, 0.01f);
        npc.transform.DOMoveX(8.7f, 1);

        Invoke(nameof(npcIdle), 1);
        Invoke(nameof(activateLaptop), 1);
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
