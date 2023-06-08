using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject phoneAlarm;
    public GameObject phone;
    public AudioSource alarm;
    public GameObject app;

    [Header("Buttons")]
    float currentTime = 0f;
    float startingTime = 110f;


    //Makes sure the time is at 1
    private void Start()
    {
        currentTime = startingTime;
        Time.timeScale = 1;
    }
    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
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

    //Opens levels
    public void OpenLevelCanvas(GameObject canvas)
    {
        Time.timeScale = 1;
        canvas.SetActive(true);
        Debug.Log("TEST");
    }
    public void checkClue(GameObject clue)
    {
        Time.timeScale = 1;
      //  if(clue != isActiveAndEnabled)
        clue.SetActive(true);
    }
    public void CircleCoupon(GameObject circle)
    {
        Time.timeScale = 1;
        if (circle.activeInHierarchy)
            circle.SetActive(false);
        else
            circle.SetActive(true);
    }
    public void CheckCoupons(GameObject selected)
    {
        Time.timeScale = 1;
        if (selected.activeInHierarchy)
            SceneManager.LoadScene(12);
        else
            SceneManager.LoadScene(13);
    }

    public void StopAlarm(GameObject phoneAlarm)
    {
        Time.timeScale = 1;
        alarm.Stop();
        Destroy(GameObject.Find("phoneAlarm"));
    }
    public void BackToHome(GameObject app)
    {
        Time.timeScale = 1;
        app.SetActive(false);
        //phone.SetActive(true);
    }
    public void BackToMessages(GameObject messages)
    {
        Time.timeScale = 1;
        app.SetActive(false);
        messages.SetActive(false);
    }

}
