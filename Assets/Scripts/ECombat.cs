using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ECombat : MonoBehaviour
{
    [Header("Refs")]
    public Animator anim;
    public Transform playerPos;
    public Transform pos;
    public Transform atkPos;
    public EBehaviour eb;
    public PBehaviour pb;

    [Header("Position Values")]
    [SerializeField] private Vector3 difference;
    [SerializeField] private float distance;
    private float activateDistance = 20f;

    [Header("Atk Values")]
    public int atkType;
    public float[] atkRangeE;
    public int[] atkDamageE;
    public float[] atkRateE;
    public float atkRadE;
    public float[] atkDelayE;
    public float[] speedResetDelayE;

    [Header("Validations")]
    public bool isBoss;
    public bool isAttacking;

    public LayerMask playerLayer;

    private float nextAtkTime = 0f;
    private float orSpeed;
    private float orRotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        pos = GetComponent<Transform>();
        eb = GetComponent<EBehaviour>();
        pb = GameObject.FindGameObjectWithTag("Player").GetComponent<PBehaviour>();

        if (!eb.isMalware)
            anim = GetComponent<Animator>();

        orSpeed = eb.speed;
        orRotSpeed = eb.rotSpeed;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        difference = playerPos.position - pos.position;
        distance = difference.magnitude;

        if (distance < activateDistance)
            eb.enabled = true;
        else
            eb.enabled = false;

        if (Time.time >= nextAtkTime && !isBoss && !isAttacking)
        {
            if (distance < atkRadE)
            {
                attack();
                nextAtkTime = Time.time + 1f / atkRateE[0];
            }
        }
        else if (Time.time >= nextAtkTime && isBoss && !isAttacking)
        {
            if (distance < atkRadE && !eb.isAdware)
            {
                atkType = 0;
                attackBoss(); // short range
                nextAtkTime = Time.time + 1f / atkRateE[atkType];
            }
            else if (distance > atkRadE && !eb.isAdware)
            {
                atkType = 1;
                attackBoss(); // long range
                nextAtkTime = Time.time + 1f / atkRateE[atkType];
            }
            else if (distance < atkRadE && eb.isAdware)
            {
                atkType = 0;
                attackBoss(); // short range
                nextAtkTime = Time.time + 1f / atkRateE[atkType];
            }
        }
    }

    public void attack()
    {
        isAttacking = true;

        anim.SetTrigger("atkE");
        Invoke("attackHit", atkDelayE[atkType]);

        eb.speed = eb.speed * 0.05f;
        eb.rotSpeed = eb.rotSpeed * 0.05f;
        Invoke("resetSpeed", atkDelayE[atkType] + speedResetDelayE[atkType]);
    }

    public void attackBoss()
    {
        isAttacking = true;

        // hrs ny ini ga perlu lg
        if (atkType == 0)
            changeToShortAtk();
        else if (atkType == 1)
            changeToLongAtk();

        anim.SetTrigger("atkE" + atkType.ToString());
        Invoke("attackHit", atkDelayE[atkType]);

        eb.speed = eb.speed * 0.05f;
        eb.rotSpeed = eb.rotSpeed * 0.05f;
        Invoke("resetSpeed", atkDelayE[atkType] + speedResetDelayE[atkType]);
    }

    public void attackHit()
    {
        Collider[] hitPlayer;
        hitPlayer = Physics.OverlapSphere(atkPos.position, atkRangeE[atkType], playerLayer);

        foreach (Collider player in hitPlayer)
        {
            Debug.Log(player.name + " hit ");
            pb = player.GetComponent<PBehaviour>();
            pb.PTakeDamage(atkDamageE[atkType]);
            //Debug.Log(++count);
        }
    }

    public void resetSpeed()
    {
        eb.speed = orSpeed;
        eb.rotSpeed = orRotSpeed;
        isAttacking = false;
    }

    public void changeToLongAtk()
    {
        // ganti stat utk long range atk (AOE), kecuali atkrade
        // klo long range, atk rate hrs kecil
    }

    public void changeToShortAtk()
    {
        // ganti stat utk short range atk, kecuali atkrade
    }

    private void OnDrawGizmosSelected()
    {
        if (atkPos == null)
            return;

        Gizmos.DrawWireSphere(atkPos.position, atkRangeE[atkType]);
    }
}
