using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCamBehaviour : MonoBehaviour
{
    private CinemachineVirtualCamera virCam;

    // Start is called before the first frame update
    void Start()
    {
        virCam = GetComponent<CinemachineVirtualCamera>();
        Invoke(nameof(getPlayer), 0.1f);
    }

    public void getPlayer()
    {
        virCam.Follow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
