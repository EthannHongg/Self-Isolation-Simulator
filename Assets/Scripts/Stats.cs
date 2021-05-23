using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private Text statValue;

    private Image content;
    private float currentFill;
    
    [SerializeField]
    private float myMaxValue;

    [SerializeField]
    private float currentValue;

    void Start()
    {
        content = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFill();
        CheckCurrentValue();
        statValue.text = currentValue + " / " + myMaxValue;
    }

    private void UpdateFill()
    {
        currentFill = currentValue / myMaxValue;
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }

    private void CheckCurrentValue()
    {
        if (currentValue > myMaxValue)
        {
            currentValue = myMaxValue;
        }
        else if (currentValue < 0)
        {
            currentValue = 0;
        }
    }
    

    public void ChangeValue(int value)
    {
        currentValue += value;
    }

    public float GetValue()
    {
        return currentValue;
    }
}
