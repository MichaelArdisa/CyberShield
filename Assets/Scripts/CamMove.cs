using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamMove : MonoBehaviour
{
    public Transform camPoint;
    private Vector3 orPos;
    private PMove pm;

    // Start is called before the first frame update
    void Start()
    {
        camPoint = GetComponent<Transform>();
        orPos = camPoint.position;

        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PMove>();
        pm.enabled = false;

        //moveCamMid();
        //Invoke(nameof(moveCamBack), 1);
    }

    public void moveCamMid()
    {
        transform.DOMove(new Vector3(5.5f, 2.5f, 4f), 1);
        pm.enabled = true;
    }

    public void moveCamBack()
    {
        transform.DOMove(orPos, 1);
        pm.enabled = false;
    }
}
