using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    [SerializeField]
    private Stats healthStats;

    [SerializeField]
    private Stats happinessStats;

    [SerializeField]
    private Stats fatigueStats;

    [SerializeField]
    private Stats hungerStats;

    [SerializeField]
    private Inventory inventory;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject obj = GameObject.Find("Inventory(Clone)");
        if (obj != null)
        {
            inventory = obj.GetComponent<Inventory>();
        }
        healthStats = GameObject.Find("HealthStat").GetComponent<Stats>();
        happinessStats = GameObject.Find("HappniessStat").GetComponent<Stats>();
        fatigueStats = GameObject.Find("FatigueStat").GetComponent<Stats>();
        hungerStats = GameObject.Find("HungerStat").GetComponent<Stats>();
    }

    public void UseCopsi()
    {
        if (inventory.copsiNum > 0)
        {
            happinessStats.ChangeValue(10);
            healthStats.ChangeValue(-2);
            inventory.copsiNum -= 1;
        }
    }

    public void UseDiet()
    {
        if (inventory.dietNum > 0)
        {
            happinessStats.ChangeValue(5);
            healthStats.ChangeValue(1);
            inventory.dietNum -= 1;
        }
    }

    public void UseEnergy()
    {
        if (inventory.energyNum > 0)
        {
            fatigueStats.ChangeValue(20);
            healthStats.ChangeValue(-2);
            inventory.energyNum -= 1;
        }
    }

    public void UseEgg()
    {
        if (inventory.eggNum > 0)
        {
            hungerStats.ChangeValue(20);
            healthStats.ChangeValue(1);
            inventory.eggNum -= 1;
        }
    }

    public void UseJunk()
    {
        if (inventory.junkNum > 0)
        {
            hungerStats.ChangeValue(30);
            healthStats.ChangeValue(-5);
            inventory.junkNum -= 1;
        }
    }

    public void UseSalad()
    {
        if (inventory.saladNum > 0)
        {
            hungerStats.ChangeValue(15);
            healthStats.ChangeValue(3);
            inventory.saladNum -= 1;
        }
    }

    public void UseSnack()
    {
        if (inventory.snackNum > 0)
        {
            hungerStats.ChangeValue(5);
            happinessStats.ChangeValue(2);
            inventory.snackNum -= 1;
        }
    }
}
