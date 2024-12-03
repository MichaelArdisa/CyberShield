using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdWallBehaviour : MonoBehaviour
{
    [Header("Refs")]
    public GameObject enemy;
    public Transform enemyPos;
    public Transform playerPos;
    public HealthBar healthBar;
    public Animator anim;
    public Material dissolveMaterial;
    public ToDoBehaviour toDo;
    //public Collider coll;

    [Header("Enemy Values")]
    public int maxHP;
    private int currHP;
    public float speed;
    public int dirDeg;
    public float rotSpeed;
    private float blinkDuration = 0.15f;

    [Header("Validations")]
    public bool isHit;
    public bool isMalware;
    public bool isAdware;
    public bool isPopUp;

    private Color hitColor = new Color(1.0f, 0f, 0f, 0.1f);

    // Start is called before the first frame update
    void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        //coll = GetComponent<Collider>();

        enemyPos = GetComponent<Transform>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if (!isMalware)
            anim = GetComponent<Animator>();

        currHP = maxHP;

        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.setMaxHP(maxHP);
        Debug.Log(healthBar.HPslider.maxValue);

        toDo = GameObject.FindGameObjectWithTag("Toggle").GetComponent<ToDoBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        //enemyPos.position = Vector3.MoveTowards(enemyPos.position, playerPos.position, speed);

        //Quaternion targetRot = Quaternion.LookRotation(playerPos.position, Vector3.up);
        //enemyPos.rotation = Quaternion.Slerp(enemyPos.rotation, targetRot, rotSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        // Enemy Movement
        Vector3 dirToPlayer = playerPos.position - enemyPos.position;
        dirToPlayer.y = 0f;

        if (dirToPlayer != Vector3.zero && !isPopUp)
        {
            // kalau perlu rotation tambahan, value Quaternion.Euler tinggal di otak atik sumbu Y ny
            Vector3 isoDir = Quaternion.Euler(0, dirDeg, 0) * dirToPlayer;

            if (!isMalware)
                anim.SetTrigger("moveE");
            transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed);

            Quaternion targetRotation = Quaternion.LookRotation(isoDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
        }
    }

    public void ETakeDamage(int damage)
    {
        currHP = currHP - damage;
        healthBar.setHP(currHP);

        Debug.Log(damage);

        // play hurt anim for enemy
        foreach (MeshRenderer mr in enemyPos.GetComponentsInChildren<MeshRenderer>())
        {
            Color orColor = mr.material.color;
            mr.material.color = hitColor * 1.5f;
            StartCoroutine(hitReset(mr, blinkDuration, orColor));
        }

        if (currHP <= 0)
        {
            // play dead anim for enemy
            foreach (MeshRenderer mr in enemyPos.GetComponentsInChildren<MeshRenderer>())
            {
                mr.material = dissolveMaterial;
                StartCoroutine(dissolve(mr.material));
            }

            Debug.Log("enemy dead!");
            enemy.layer = 0;
            Invoke(nameof(disableEnemy), 1f);
        }
    }

    IEnumerator hitReset(MeshRenderer mr, float dur, Color color)
    {
        yield return new WaitForSeconds(dur);
        mr.material.color = color;
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

    void disableEnemy()
    {
        enemy.SetActive(false);
        toDo.enemyKilled++;
    }
}
