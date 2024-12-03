using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PBehaviour : MonoBehaviour
{
    [Header("Refs")]
    public HealthBar healthBar;
    public GameObject player;
    public Material dissolveMaterial;
    private PBehaviour pb;
    private Scene currScene;
    private GameObject[] players;

    [Header("Values")]
    public int maxHP;
    public float blinkDuration;
    private int currHP;

    private Color hitColor = new Color(1.0f, 0f, 0f, 0.1f);

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        //currScene = 

        //if (currScene.name == "Lv1-1")
        //    currHP = maxHP;

        //PlayerPrefs.SetInt("HP", currHP);

        healthBar = GameObject.FindGameObjectWithTag("PHB").GetComponent<HealthBar>();
        currHP = maxHP;

        players = GameObject.FindGameObjectsWithTag("Player");
        players = players.OrderBy(player => player.transform.GetSiblingIndex()).ToArray();

        if (players.Length > 1 )
            for (int i = 1; i < players.Length; i++)
                Destroy(players[i]);

        if (pb != null)
            Destroy(player);

        else
        {
            pb = this;
            DontDestroyOnLoad(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PTakeDamage(int damage)
    {
        currHP = currHP - damage;
        healthBar.setHP(currHP);
        PlayerPrefs.SetInt("HP", currHP);

        foreach (SkinnedMeshRenderer smr in player.GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            Color orColor = smr.material.color;
            smr.material.color = hitColor * 1.5f;
            StartCoroutine(hitReset(smr, blinkDuration, orColor));
        }

        Debug.Log(damage);

        if (currHP <= 0)
        {
            foreach (SkinnedMeshRenderer smr in player.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                smr.material = dissolveMaterial;
                StartCoroutine(dissolve(smr.material));
            }

            Invoke(nameof(disablePlayer), 1f);
        }
    }

    IEnumerator dissolve(Material mat)
    {
        float i = 0f;

        while (i < 1f)
        {
            mat.SetFloat("_Dissolve", i);
            i = i + 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        mat.SetFloat("_Dissolve", 1f);
    }

    IEnumerator hitReset(SkinnedMeshRenderer smr, float dur, Color color)
    {
        yield return new WaitForSeconds(dur);
        smr.material.color = color;
    }
    void disablePlayer()
    {
        player.SetActive(false);
    }
}
