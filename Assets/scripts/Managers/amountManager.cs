using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class amountManager : MonoBehaviour
{
    //0 = flour || 1 = choco || 2 = sugar || 3 = milk || 4 = egg 
    public GameObject[] amounts = new GameObject[5];
    public List<int> theScores;

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

    public void removeScore(int score, int ingredient)
    {
        theScores[ingredient] = theScores[ingredient] - score;
    }
    private void Update()
    {
        for (int i = 0; i < amounts.Length; i++)
        {
            amounts[i].GetComponent<TextMeshProUGUI>().text = "" + theScores[i];
        }
    }
    public void answerCheck()
    {
        if (theScores != null)
        {
            if (theScores[0] == 11 && theScores[1] == 5 && theScores[2] == 6 && theScores[3] == 3 && theScores[4] == 0)
                LoadSceneScript("lvl06RIGHT");
            else
                LoadSceneScript("lvl06WRONG");
        }
    }
    public void LoadSceneScript(string name)
    {
        Time.timeScale = 1;
        StartCoroutine(LoadSceneScriptIE(name));
    }
    private IEnumerator LoadSceneScriptIE(string name)
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(name);
    }
}
