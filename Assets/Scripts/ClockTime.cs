using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClockTime : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentDay;
    private bool gameOver;
    public bool buttonSet;
    public bool sleeping;

    [SerializeField]
    private Sprite imageBlue;

    [SerializeField]
    private Sprite imageOrange;

    [SerializeField]
    private Sprite imagePink;

    [SerializeField]
    private Sprite imageWhite;

    [SerializeField]
    private Request requestTemplate;

    void Start()
    {
        currentDay = 1;
        gameOver = false;
        buttonSet = false;
        sleeping = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateClock();
        ResetButton();
        BlackCover();
    }

    private void BlackCover()
    {
        if (SceneManager.GetActiveScene().name == "HomeScreen" && sleeping == true)
        {
            GameObject.Find("SleepBlackCover").GetComponent<Image>().raycastTarget = true;
            float fadeAmount = GameObject.Find("SleepBlackCover").GetComponent<Image>().color.a + Time.deltaTime;
            GameObject.Find("SleepBlackCover").GetComponent<Image>().color = new Color(0, 0, 0, fadeAmount);

            GameObject statsCombine = GameObject.Find("Stats(Clone)");
            statsCombine.transform.GetChild(6).GetComponent<Image>().color = new Color(0, 0, 0, fadeAmount);

            if (fadeAmount >= 1)
            {
                SceneManager.LoadScene("Black");
                GameObject.Find("HomepageBackground").GetComponent<Homepage>().DontDestroy();
            }
        }
        if (SceneManager.GetActiveScene().name == "HomeScreen" && sleeping == false)
        {
            GameObject.Find("SleepBlackCover").GetComponent<Image>().color = new Color(1, 1, 1, 0);
            GameObject.Find("SleepBlackCover").GetComponent<Image>().raycastTarget = false;
        }
    }

    private void UpdateClock()
    {
        if (SceneManager.GetActiveScene().name != "Black")
        {
            Text clock = GameObject.Find("Clock").GetComponent<Text>();
            clock.text = "Day " + currentDay;
        }
        
    }

    private void ResetButton()
    {
        if (SceneManager.GetActiveScene().name == "HomeScreen" && buttonSet == false)
        {
            buttonSet = true;
            Button sleep = GameObject.Find("Sleep").GetComponent<Button>();
            sleep.onClick.AddListener(Sleep);
        }
    }

    public void Sleep()
    {
        currentDay += 1;
        Stats healthStats = GameObject.Find("HealthStat").GetComponent<Stats>();
        Stats happinessStats = GameObject.Find("HappniessStat").GetComponent<Stats>();
        Stats fatigueStats = GameObject.Find("FatigueStat").GetComponent<Stats>();
        Stats hungerStats = GameObject.Find("HungerStat").GetComponent<Stats>();
        Diagnosis(healthStats, happinessStats, fatigueStats, hungerStats);
        
        if (gameOver == false)
        {
            sleeping = true;
            fatigueStats.ChangeValue(80);
            hungerStats.ChangeValue(-30);
            GenerateQuests();
            DailyUpdate dailyUpdate = GameObject.Find("DailyUpdate(Clone)").GetComponent<DailyUpdate>();
            dailyUpdate.InstantiateVideos();
            dailyUpdate.sleeping = true;
        }
    }

    private void GenerateQuests()
    {
        Quests quests = GameObject.Find("Quests(Clone)").GetComponent<Quests>();
        int generateQuestNum = Random.Range(1, 4);
        for (int i = 1; i <= generateQuestNum; i++)
        {
            GenerateRandomQuest();
        }
    }

    private void GenerateRandomQuest()
    {
        Sprite sprite;
        sprite = imageBlue;
        string user;
        string intro;
        string type;
        type = "Basic";

        int randInt = Random.Range(0, 4);
        if (randInt == 1)
        {
            sprite = imageBlue;
        }
        if (randInt == 2)
        {
            sprite = imageOrange;
        }
        if (randInt == 3)
        {
            sprite = imagePink;
        }
        if (randInt == 4)
        {
            sprite = imageWhite;
        }

        user = RandomNameGenerator();

        intro = "";

        int randInt1 = Random.Range(1, 101);
        if (randInt1 <= 60)
        {
            type = "Basic";
        }
        if (randInt1 > 60 && randInt1 <= 90)
        {
            type = "Standard";
        }
        if (randInt1 > 90)
        {
            type = "Premium";
        }

        Quests quests = GameObject.Find("Quests(Clone)").GetComponent<Quests>();
        quests.AddQuests(sprite, user, intro, type);
    }

    private void Diagnosis(Stats healthStats, Stats happinessStats, Stats fatigueStats, Stats hungerStats)
    {
        if (hungerStats.GetValue() < 15)
        {
            healthStats.ChangeValue(-10);
        }
        if (fatigueStats.GetValue() < 10)
        {
            healthStats.ChangeValue(-2);
        }
        if (healthStats.GetValue() == 0)
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
        else if (happinessStats.GetValue() == 0)
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
    }

    private string RandomNameGenerator()
    {
        string name;
        string[] names = new string[] { "Tessa", "Emilee", "Curtis", "Dean", "Eleanor", "Ella", "Keyon", "Deja", "Emery", "Lina", "Joseph", "Braiden", "Kane", "Nathalie", "Esteban", "Ace", "Asa", "Ansley", "Alexa", "Landin", "Angeline", "Camden", "Trinity", "Melanie", "Kamora", "Blake", "Adonis", "Jamari", "Kelly", "Megan", "Bronson", "Jasper", "Roberto", "Reese", "Alyssa", "Elisabeth", "Jaylan", "Mikayla", "Braedon", "Briley", "Yaritza", "Rashad", "Sebastian", "Clare", "Amiah", "Isla", "Haven", "Kenzie", "Justus", "Nico", "Jaylen", "Coby", "Thomas", "Joyce", "Fabian", "Jaylen", "Terrence", "Avah", "Sammy", "Belen", "Frida", "Kristina", "Antwan", "Mira", "Jaslene", "Dylan", "Phoebe", "Amara", "Roland", "William", "Jennifer", "Alec", "Donald", "Daniel", "Edith", "Jon", "Maria", "Noe", "Tomas", "Hezekiah", "Andrea", "Mike", "Tripp", "Heather", "Tyrese", "Alexis", "Kylee", "Brenna", "Julissa", "Sloane", "Azul", "Dana", "Jamison", "Demarcus", "Jeremy", "Amaris", "Anya", "Mya", "Trevin", "Jair"};
        name = names[Random.Range(0, names.Length)];
        return name;
    }
}
