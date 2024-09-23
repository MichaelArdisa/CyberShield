using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuPanelMove : MonoBehaviour
{
    public RectTransform panelPos;
    public float moveAwayPos;
    private float orPos;

    // Start is called before the first frame update
    void Start()
    {
        panelPos = GetComponent<RectTransform>();
        orPos = panelPos.localScale.x;

        //movePanelAway();
        //Invoke(nameof(movePanelBack), 1);
    }

    public void movePanelAway()
    {
        panelPos.DOScaleX(moveAwayPos, 1);
    }

    public void movePanelBack()
    {
        panelPos.DOScale(orPos, 1);
    }
}
