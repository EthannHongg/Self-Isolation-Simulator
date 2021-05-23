using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
    public int questNum;
    public List<Sprite> sprites = new List<Sprite>();
    public List<string> users = new List<string>();
    public List<string> intros = new List<string>();
    public List<string> types = new List<string>();
    public bool sceneSetUp;

    [SerializeField]
    private Request requestTemplate;
    
    void Start()
    {
        questNum = 0;
        sceneSetUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        LoadQuests();
        UpdateNumText();
    }

    public void LoadQuests()
    {
        if (sceneSetUp == false && SceneManager.GetActiveScene().name == "Freelancer")
        {
            sceneSetUp = true;

            for (int i = 0; i < questNum; i++)
            {
                Request request = Instantiate(requestTemplate);
                request.InstantiateRequest(sprites[i], users[i], intros[i], types[i], i);
                request.transform.SetParent(GameObject.Find("Content").transform);
                request.FirstRePosition();
            }
                Debug.Log("hey");
        }
    }

    public void QuestsChanged(int ind, Request requestDeleted)
    {
        GameObject[] requests = GameObject.FindGameObjectsWithTag("Request");
        foreach (GameObject request in requests)
        {
            //Destroy(request);
            Request re = request.GetComponent<Request>();
            if (re.index > ind)
            {
                re.index -= 1;
            }
            if (re == requestDeleted)
            {
                requestDeleted.fadeOut = true;
                Destroy(request, 0.5f);
            }
        }
    }

    public void AddQuests(Sprite spriteImage, string user, string intro, string type)
    {
        if (questNum < 5)
        {
            sprites.Add(spriteImage);
            users.Add(user);
            intros.Add(intro);
            types.Add(type);
            questNum += 1;
        }
    }

    private void UpdateNumText()
    {
        if (SceneManager.GetActiveScene().name == "Freelancer")
        {
            GameObject numText = GameObject.Find("RequestNum");
            numText.GetComponent<Text>().text = questNum + "/5";
        }
    }
}
