using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Homepage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Inventory inventoryTemplate;

    [SerializeField]
    private GameObject statsTemplate;

    [SerializeField]
    private ClockTime clockTimeTemplate;

    [SerializeField]
    private Quests questsTemplate;

    [SerializeField]
    private DailyUpdate dailyUpdateTemplate;

    [SerializeField]
    private MusicContent backgroundMusicTemplate;

    void Start()
    {
        FirstInstantiate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FirstInstantiate()
    {
        if (GameObject.Find("Inventory(Clone)") == null)
        {
            Instantiate(inventoryTemplate);
        }
        if (GameObject.Find("Stats(Clone)") == null)
        {
            Instantiate(statsTemplate);
        }
        if (GameObject.Find("ClockTime(Clone)") == null)
        {
            Instantiate(clockTimeTemplate);
        }
        if (GameObject.Find("Quests(Clone)") == null)
        {
            Instantiate(questsTemplate);
        }
        if (GameObject.Find("DailyUpdate(Clone)") == null)
        {
            Instantiate(dailyUpdateTemplate);
        }
        if (GameObject.Find("BackgroundMusic(Clone)") == null)
        {
            Instantiate(backgroundMusicTemplate);
        }
    }

    public void Freelancer()
    {
        SceneManager.LoadScene(sceneName: "Freelancer");
        GameObject quests = GameObject.Find("Quests(Clone)");
        quests.GetComponent<Quests>().sceneSetUp = false;
        DontDestroy();
    }

    public void Music()
    {
        SceneManager.LoadScene(sceneName: "Music");
        GameObject backgroundMusic = GameObject.Find("BackgroundMusic(Clone)");
        backgroundMusic.GetComponent<MusicContent>().buttonsSet = false;
        DontDestroy();
    }

    public void Memo()
    {
        SceneManager.LoadScene(sceneName: "Memo");
        DontDestroy();
    }

    public void Tinsagram()
    {
        SceneManager.LoadScene(sceneName: "Tinsagram");
        DontDestroy();
    }

    public void FordKnight()
    {
        SceneManager.LoadScene(sceneName: "FordKnight");
        DontDestroy();
    }

    public void UTunnel()
    {
        SceneManager.LoadScene(sceneName: "UTunnel");
        DontDestroy();
        GameObject DailyUpdate = GameObject.Find("DailyUpdate(Clone)");
        DailyUpdate.GetComponent<DailyUpdate>().videosLoad = false;
    }

    public void DontDestroy()
    {
        GameObject inventory = GameObject.Find("Inventory(Clone)");
        GameObject status = GameObject.Find("Stats(Clone)");
        GameObject clockTime = GameObject.Find("ClockTime(Clone)");
        GameObject quests = GameObject.Find("Quests(Clone)");
        GameObject dailyUpdate = GameObject.Find("DailyUpdate(Clone)");
        GameObject backgroundMusic = GameObject.Find("BackgroundMusic(Clone)");
        DontDestroyOnLoad(inventory);
        DontDestroyOnLoad(status);
        DontDestroyOnLoad(clockTime);
        DontDestroyOnLoad(quests);
        DontDestroyOnLoad(dailyUpdate);
        DontDestroyOnLoad(backgroundMusic);
    }

    
}
