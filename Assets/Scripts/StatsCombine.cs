using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsCombine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StatsCombine status = this;
        //status.transform.SetParent(GameObject.Find("Canvas").GetComponent<Canvas>().transform);
        Vector3 newPos = new Vector3(0, 0);
        status.transform.localScale = new Vector3(0.00703f, 0.00703f);
        status.transform.position = newPos;
        RectTransform rt;
        rt = status.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(800, 1422.222f);
    }
}
