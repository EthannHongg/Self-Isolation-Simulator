using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackHomescreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoBackHome()
    {
        GameObject audio = GameObject.Find("Audio");
        if (audio != null)
        {
            DontDestroyOnLoad(audio);
        }
        if (SceneManager.GetActiveScene().name == "Memo")
        {
            GameObject inventory = GameObject.Find("Inventory(Clone)");
            DontDestroyOnLoad(inventory);
        }
        GameObject clockTime = GameObject.Find("ClockTime(Clone)");
        clockTime.GetComponent<ClockTime>().buttonSet = false;
        SceneManager.LoadScene("HomeScreen");
    }
}
