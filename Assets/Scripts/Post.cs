using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Post : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InPosition();
        RePosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InPosition()
    {
        int ind = transform.GetSiblingIndex();
        float initialPosY = 200 - 900 * ind;
        Transform post = this.transform;
        RectTransform postRectTransform = post.GetComponent<RectTransform>();
        postRectTransform.localPosition = new Vector3(0, initialPosY);
    }

    void RePosition()
    {
        Transform post = this.transform;
        GameObject content = post.parent.gameObject;

        int childNum = 0;
        foreach (Transform child in content.transform)
        {
            childNum += 1;
        }

        RectTransform postRectTransform = post.GetComponent<RectTransform>();
        float posY = postRectTransform.localPosition.y + 450 * (childNum - 1);
        postRectTransform.localPosition = new Vector3(0, posY);
    }
}
