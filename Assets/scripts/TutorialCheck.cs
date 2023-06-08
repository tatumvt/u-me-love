using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialCheck : MonoBehaviour
{
    public string tutorialCheck;
    // Start is called before the first frame update
    void Start()
    {

         if (PlayerPrefs.GetInt(tutorialCheck) != 2)
            SceneManager.LoadScene("tutorial");
    }
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
