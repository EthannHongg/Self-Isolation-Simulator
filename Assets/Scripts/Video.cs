using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Video : MonoBehaviour
{
    // Start is called before the first frame update
    private int happiness;
    private int fatigue;

    void Start()
    {
        happiness = 10;
        fatigue = -10;
    }

    // Update is called once per frame
    void Update()
    {
        RePosition();
    }

    public void InstantiateVideo(Sprite spriteImage, int happy, int energy)
    {
        Image image = transform.GetChild(0).gameObject.GetComponent<Image>();
        Text statusChange = transform.GetChild(1).gameObject.GetComponent<Text>();
        image.sprite = spriteImage;
        happiness = happy;
        fatigue = energy;
        statusChange.text = "+" + happiness + " Happiness \n-" + fatigue + " Fatigue";
    }

    void RePosition()
    {
        int ind = transform.GetSiblingIndex();
        float PosY = 500 - 480 * ind;
        Transform request = this.transform;
        RectTransform requestRectTransform = request.GetComponent<RectTransform>();
        requestRectTransform.localScale = new Vector3(1, 1);
        if (requestRectTransform.localPosition.y < PosY)
        {
            requestRectTransform.localPosition = new Vector3(0, requestRectTransform.localPosition.y + 20f);
        }
    }

    public void FirstRePosition()
    {
        int ind = transform.GetSiblingIndex();
        float PosY = 500 - 480 * ind;
        Transform request = this.transform;
        RectTransform requestRectTransform = request.GetComponent<RectTransform>();
        requestRectTransform.localScale = new Vector3(1, 1);
        requestRectTransform.localPosition = new Vector3(0, PosY);
    }

    public void WatchVideo()
    {
        Stats happinessStats = GameObject.Find("HappniessStat").GetComponent<Stats>();
        Stats fatigueStats = GameObject.Find("FatigueStat").GetComponent<Stats>();
        happinessStats.ChangeValue(happiness);
        fatigueStats.ChangeValue(fatigue);
        Destroy(gameObject);
    }
}
