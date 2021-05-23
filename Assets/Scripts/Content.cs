using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Content : MonoBehaviour
{
    // Start is called before the first frame update
    int childNum;
    Transform panel;
    void Start()
    {
        CountChild();
        ReSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CountChild()
    {
        childNum = 0;
        foreach (Transform child in transform)
        {
            childNum += 1;
        }
    }

    void ReSize()
    {
        panel = this.transform;
        int height;
        //if (childNum > 1)
        //{
        //    height = childNum * 900;
        //}
        //else
        //{
        //    height = 1300;
        //}

        height = 400 + childNum * 900;

        float posY = -(height - 1300) / 2;
        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();
        panelRectTransform.sizeDelta = new Vector2(800, height);
        panelRectTransform.localPosition = new Vector3(0, posY);
    }
}
