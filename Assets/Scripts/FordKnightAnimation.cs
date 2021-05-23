using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FordKnightAnimation : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private Stats healthStats;

    [SerializeField]
    private Stats happinessStats;

    [SerializeField]
    private Stats fatigueStats;

    [SerializeField]
    private Stats hungerStats;

    [SerializeField]
    private Button fordButton;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        healthStats = GameObject.Find("HealthStat").GetComponent<Stats>();
        happinessStats = GameObject.Find("HappniessStat").GetComponent<Stats>();
        fatigueStats = GameObject.Find("FatigueStat").GetComponent<Stats>();
        hungerStats = GameObject.Find("HungerStat").GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFordKnight()
    {
        anim.ResetTrigger("Finish");
        anim.SetTrigger("Start");
        fordButton.interactable = false;
        StartCoroutine(PlaySeconds(2));
    }

    private IEnumerator PlaySeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
        anim.SetTrigger("Finish");
        anim.ResetTrigger("Start");

        int randInt = Random.Range(1, 101);
        if (randInt <= 10)
        {
            happinessStats.ChangeValue(-10);
            Debug.Log("opps");
        }
        else
        {
            happinessStats.ChangeValue(20);
        }
        fatigueStats.ChangeValue(-10);
        fordButton.interactable = true;
    }
}
