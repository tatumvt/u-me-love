using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour
{
    private Text displayText;
    public calculator calc;

    void Start()
    {
        displayText = GameObject.Find("DisplayText").GetComponent<Text>();
    }

    public void ClearDisplay()
    {
        displayText.text = "";
    }

    public void UpdateDisplayText(string newText)
    {
        displayText.text += newText;
    }

    public void DisplayAnswer()
    {
        string answer = calc.Calculate(displayText.text);
        displayText.text = answer;
    }
}

