using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DailyUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> videoSprites = new List<Sprite>();
    public List<int> videoHappiness = new List<int>();
    public List<int> videoFatigue = new List<int>();
    public int videoNum;
    public bool videosLoad;
    public bool sleeping;

    private string dailyUpdate;

    [SerializeField]
    private Video videoTemplate;

    [SerializeField]
    private List<Sprite> videoSpriteFiles = new List<Sprite>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoadVideos();
        SleepChange();
    }

    public void InstantiateVideos()
    {
        videoSprites.Clear();
        videoHappiness.Clear();
        videoFatigue.Clear();

        int num = Random.Range(0, 4);
        videoNum = num;

        for (var j = 0; j < videoNum; j++)
        {
            RandomVideoSprites();
            RandomVideoHappiness();
            RandomVideoFatigue();
        }
    }

    private void RandomVideoSprites()
    {
        int randInt = Random.Range(0, 6);
        videoSprites.Add(videoSpriteFiles[randInt]);
    }

    private void RandomVideoHappiness()
    {
        int randInt = Random.Range(5, 11);
        videoHappiness.Add(randInt);
    }

    private void RandomVideoFatigue()
    {
        int randInt = Random.Range(5, 11);
        videoFatigue.Add(randInt);
    }

    private void LoadVideos()
    {
        if (SceneManager.GetActiveScene().name == "UTunnel" && videosLoad == false)
        {
            videosLoad = true;

            for (int i = 0; i < videoNum; i++)
            {
                Video video = Instantiate(videoTemplate);
                video.InstantiateVideo(videoSprites[i], videoHappiness[i], videoFatigue[i]);
                video.transform.SetParent(GameObject.Find("Content").transform);
                video.FirstRePosition();
            }
        }
    }

    private void SleepChange()
    {
        if (SceneManager.GetActiveScene().name == "Black" && sleeping == true)
        {
            sleeping = false;
            dailyUpdate = "";
            GenerateSleepEvents();
            Quests quests = GameObject.Find("Quests(Clone)").GetComponent<Quests>();
            GenerateQuestNum(quests.questNum);
            GenerateMessages(0);
            Text changes = GameObject.Find("Changes").GetComponent<Text>();
            changes.text = dailyUpdate;
        }
    }

    private void GenerateSleepEvents()
    {
        int randInt = Random.Range(0, 5);
        if (randInt == 0)
        {
            dailyUpdate += "Last Night Was Peaceful\n";
        }
        else
        {
            dailyUpdate += "A Dog Ate Your Sausage\n";
        }
    }

    public void GenerateQuestNum(int num)
    {
        dailyUpdate += "You have " + num + " job postings on Freelancer\n";
    }

    private void GenerateMessages(int num)
    {
        dailyUpdate += "You received " + num + " messages";
    }
}
