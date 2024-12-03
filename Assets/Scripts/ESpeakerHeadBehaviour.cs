using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESpeakerHeadBehaviour : MonoBehaviour
{
    public Transform soundWaveObject;
    [Range(0, 1)] public float scale;
    public Vector2 startEnd;
    [Range(0, 0.1f)] public float rate;
    public bool isIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        scale = Mathf.Clamp(scale, startEnd.x, startEnd.y);
    }

    private void FixedUpdate()
    {
        soundWaveObject.localScale = new Vector3(scale, soundWaveObject.localScale.y, scale);

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
}
