using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public int copsiNum;
    public int dietNum;
    public int energyNum;
    public int eggNum;
    public int junkNum;
    public int saladNum;
    public int snackNum;

    [SerializeField]
    private Text copsi;

    [SerializeField]
    private Text diet;

    [SerializeField]
    private Text energy;

    [SerializeField]
    private Text egg;

    [SerializeField]
    private Text junk;

    [SerializeField]
    private Text salad;

    [SerializeField]
    private Text snack;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        //Debug.Log(currentScene);
        if (currentScene == "Memo")
        {
            //SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
            ResetText();
        }
        else if (currentScene == "HomeScreen")
        {
            //SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
        }
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        if (copsi != null)
        {
            copsi.text = "- Copsi (" + copsiNum + ")";
            diet.text = "- Diet Water (" + dietNum + ")";
            energy.text = "- Engergy Drink (" + energyNum + ")";
            egg.text = "- Egg Sandwich (" + eggNum + ")";
            junk.text = "- Junk Food (" + junkNum + ")";
            snack.text = "- Snack (" + snackNum + ")";
            salad.text = "- Salad (" + saladNum + ")";
        }
    }

    private void ResetText()
    {
        copsi = GameObject.Find("Copsi").GetComponent<Text>();
        diet = GameObject.Find("Diet Water").GetComponent<Text>();
        energy = GameObject.Find("Energy Drink").GetComponent<Text>();
        egg = GameObject.Find("Egg Sandwich").GetComponent<Text>();
        junk = GameObject.Find("Junk Food").GetComponent<Text>();
        salad = GameObject.Find("Salad").GetComponent<Text>();
        snack = GameObject.Find("Snacks").GetComponent<Text>();
    }

    public void ChangeInventory(string item, int num)
    {
        if (item == "copsi")
        {
            copsiNum += num;
        }
        else if (item == "diet")
        {
            dietNum += num;
        }
        else if (item == "energy")
        {
            energyNum += num;
        }
        else if (item == "egg")
        {
            eggNum += num;
        }
        else if (item == "junk")
        {
            junkNum += num;
        }
        else if (item == "salad")
        {
            saladNum += num;
        }
        else if (item == "snack")
        {
            snackNum += num;
        }
    }
}
