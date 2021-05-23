using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Request : MonoBehaviour
{
    public string requestType;
    public int index;
    public bool fadeOut;
    void Start()
    {
        fadeOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        RePosition();
        FadeOut();
    }

    void FadeOut()
    {
        Debug.Log(this.transform.GetChild(0).GetComponent<Image>().color.a);
        if (fadeOut)
        {
            Color objectColor = this.transform.GetChild(0).GetComponent<Image>().color;
            float fadeAmount = objectColor.a - Time.deltaTime * 2;

            objectColor = new Color(1, 1, 1, fadeAmount);
            this.transform.GetChild(0).GetComponent<Image>().color = objectColor;
            this.transform.GetChild(3).GetComponent<Text>().color = objectColor;
            this.transform.GetChild(4).GetComponent<Text>().color = objectColor;

            if (objectColor.a <= 0)
            {
                fadeOut = false;
            }
        }
    }

    void RePosition()
    {
        int ind = transform.GetSiblingIndex();
        float PosY = 370 - 400 * ind;
        Transform request = this.transform;
        RectTransform requestRectTransform = request.GetComponent<RectTransform>();
        requestRectTransform.localScale = new Vector3(1.3f, 1.3f);
        if (requestRectTransform.localPosition.y < PosY)
        {
            requestRectTransform.localPosition = new Vector3(0, requestRectTransform.localPosition.y + 20f);
        }
    }

    public void FirstRePosition()
    {
        int ind = transform.GetSiblingIndex();
        float PosY = 370 - 400 * ind;
        Transform request = this.transform;
        RectTransform requestRectTransform = request.GetComponent<RectTransform>();
        requestRectTransform.localScale = new Vector3(1.3f, 1.3f);
        requestRectTransform.localPosition = new Vector3(0, PosY);
    }

    public void InstantiateRequest(Sprite spriteImage, string user, string intro, string type, int ind)
    {
        Image image = transform.GetChild(0).gameObject.GetComponent<Image>();
        Text userName = transform.GetChild(3).gameObject.GetComponent<Text>();
        Text description = transform.GetChild(4).gameObject.GetComponent<Text>();
        image.sprite = spriteImage;
        userName.text = user;
        //description.text = intro;

        if (type == "Basic")
        {
            description.text = "Basic: +$8\n-5 happiness\n-10 energy";
        }
        if (type == "Standard")
        {
            description.text = "Standard: +$29\n-20 happiness\n-30 energy";
        }
        if (type == "Premium")
        {
            description.text = "Premium: +$72\n-50 happiness\n-60 energy";
        }

        requestType = type;
        index = ind;
    }

    public void Accept()
    {
        Stats healthStats = GameObject.Find("HealthStat").GetComponent<Stats>();
        Stats happinessStats = GameObject.Find("HappniessStat").GetComponent<Stats>();
        Stats fatigueStats = GameObject.Find("FatigueStat").GetComponent<Stats>();
        Stats hungerStats = GameObject.Find("HungerStat").GetComponent<Stats>();
        if (requestType == "Basic")
        {
            happinessStats.ChangeValue(-15);
            fatigueStats.ChangeValue(-10);
        }
        if (requestType == "Standard")
        {
            happinessStats.ChangeValue(-25);
            fatigueStats.ChangeValue(-30);
        }
        if (requestType == "Premium")
        {
            happinessStats.ChangeValue(-60);
            fatigueStats.ChangeValue(-60);
        }
        
        Remove();
        
    }

    public void Decline()
    {
        Remove();
    }

    private void Remove()
    {
        Debug.Log(index);

        Quests quests = GameObject.Find("Quests(Clone)").GetComponent<Quests>();
        quests.sprites.RemoveAt(index);
        quests.users.RemoveAt(index);
        quests.intros.RemoveAt(index);
        quests.types.RemoveAt(index);

        quests.questNum -= 1;
        quests.QuestsChanged(index, this);
    }
}
