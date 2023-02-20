using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    public int debug1;
    public int debug2;

    private void Start()
    {
        debug1 = PlayerPrefs.GetInt("Lvl01");
        if(debug1 == 0)
        {
            PlayerPrefs.SetInt("Lvl01", 1);
        }
    }
    private void Update()
    {
        debug1 = PlayerPrefs.GetInt("Lvl01");
        debug2 = PlayerPrefs.GetInt("Lvl02");
        Debug.Log(debug1);
    }

    //Actual load on play button
    public void LoadSceneScript(string name)
    {
        Time.timeScale = 1;
        //bc.buttonClick();
        StartCoroutine(LoadSceneScriptIE(name));
    }
    private IEnumerator LoadSceneScriptIE(string name)
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(name);
    }
}
