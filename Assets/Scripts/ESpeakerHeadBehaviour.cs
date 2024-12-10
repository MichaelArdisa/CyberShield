using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESpeakerHeadBehaviour : MonoBehaviour
{
    public GameObject soundWaveObject;
    public Animator anim;
    public float timeBeforeAnim;
    public float resetTime;
    [Range(0, 1)] public float scale;
    public Vector2 startEnd;
    [Range(0, 0.1f)] public float rate;
    public bool isIncreasing;
    private bool runOnce;
    private bool hasInvoked;

    // Start is called before the first frame update
    void Start()
    {
        scale = Mathf.Clamp(scale, startEnd.x, startEnd.y);
        anim = GetComponent<Animator>();
        soundWaveObject.SetActive(false);
        runOnce = true;
        hasInvoked = false;
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("atkE1"))
        {
            if (!hasInvoked)
            {
                Invoke(nameof(setSoundWaveTrue), timeBeforeAnim);
                hasInvoked = true;
            }
        }
        else
        {
            soundWaveObject.SetActive(false);
            hasInvoked = false;
        }
    }

    private void FixedUpdate()
    {
        soundWaveObject.transform.localScale = new Vector3(scale, soundWaveObject.transform.localScale.y, scale);

        if (isIncreasing)
        {
            scale = scale + rate;

            if (scale >= startEnd.y)
                isIncreasing = false;

        } else if (!isIncreasing)
        {
            scale = scale - rate;

            if (scale <= startEnd.x)
                isIncreasing = true;
        }
    }

    void setSoundWaveTrue()
    {
        soundWaveObject.SetActive(true);
        Invoke(nameof(setSoundWaveFalse), resetTime);
    }

    void setSoundWaveFalse()
    {
        soundWaveObject.SetActive(false);
        //runOnce = true;
    }
}
