using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class amountManager : MonoBehaviour
{
    //0 = flour || 1 = choco || 2 = sugar || 3 = milk || 4 = egg 
    public GameObject[] amounts = new GameObject[5];
    //
    private List<int> theScores;

    public void Init()
    {
        theScores = new List<int>();
        for(int i = 0; i < 5; i++)
        {
            theScores.Add(0);
        }
    }
    public void addScore(int score, int ingredient)
    {
        theScores[ingredient] = theScores[ingredient] + score;
    }
    private void Update()
    {
        for (int i = 0; i < amounts.Length; i++)
        {
            amounts[i].GetComponent<TextMeshProUGUI>().text = "" + theScores[i];
        }
    }
}
