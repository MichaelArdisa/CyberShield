using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JobPanelMove : MonoBehaviour
{
    public RectTransform jobPanelPos;
    public GameObject panel;
    public float moveInPos;
    private float orPos;

    // Start is called before the first frame update
    void Start()
    {
        jobPanelPos = GetComponent<RectTransform>();
        orPos = jobPanelPos.localPosition.y;
    }

    public void movePanelIn()
    {
        //panelPos.DOScaleX(moveAwayPos, 1);
        //jobPanelPos.DOMoveY(moveInPos, 0.5f);
        panel.SetActive(true);
        jobPanelPos.DOLocalMoveY(moveInPos, 0.5f);
    }

    public void movePanelBack()
    {
        //panelPos.DOScale(orPos, 1);
        //jobPanelPos.DOMoveY(orPos, 0.5f);
        jobPanelPos.DOLocalMoveY(orPos, 0.5f);
        Invoke(nameof(dissablePanel), 0.5f);
    }

    public void dissablePanel()
    {
        panel.SetActive(false);
    }
}