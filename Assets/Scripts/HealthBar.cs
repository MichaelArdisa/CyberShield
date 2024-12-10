using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject[] hbObject;
    private HealthBar hb;
    public Slider HPslider;
    public TMP_Text hpNum;
    private int hpNumValue;

    // Start is called before the first frame update
    void Start()
    {
        hbObject = GameObject.FindGameObjectsWithTag("HealthBar");
        HPslider = GetComponent<Slider>();
        //hpNum = GameObject.FindGameObjectWithTag("HPnumber").GetComponent<TMP_Text>();

        if (hb != null)
            Destroy(hbObject[0]);

        else
        {
            Debug.Log(hb);
            hb = this;
            DontDestroyOnLoad(hbObject[0]);
        }

        if (hbObject.Length > 1)
            Destroy(hbObject[1]);
    }

    // Update is called once per frame
    void Update()
    {
        hpNumValue = (int)HPslider.value;
        hpNum.text = hpNumValue.ToString();
        //Debug.Log(hpNumValue);
    }

    public void setMaxHP(int hp)
    {
        HPslider.maxValue = hp;
        HPslider.value = hp;
    }

    public void setHP(int hp)
    {
        HPslider.value = hp;
        hpNum.text = hp.ToString();
    }
}