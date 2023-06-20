using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerBlockTimer : MonoBehaviour
{
    public GameObject btn;
    public GameObject popup;
    public Canvas map;
    public bool isLvlTen;
    public bool isTutorial;

    // Update is called once per frame
    void Start()
    {
        WaitForAnswer();
    }
    private void Update()
    {
        if (isLvlTen && map)
            WaitForWifi();
        if (isTutorial)
            WaitForWifi();
    }
    public void WaitForAnswer()
    {
        Time.timeScale = 1;
        StartCoroutine(IEWaitForAnswer());
    }
    private IEnumerator IEWaitForAnswer()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(29f);
         btn.SetActive(true);
    }

    public void WaitForWifi()
    {
        Time.timeScale = 1;
        StartCoroutine(IEWaitForWifi());
    }
    private IEnumerator IEWaitForWifi()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(1f);
        popup.SetActive(true);
    }

    public void WaitForAnswerTut()
    {
        Time.timeScale = 1;
        StartCoroutine(IEWaitForAnswerTut());
    }
    private IEnumerator IEWaitForAnswerTut()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(8f);
        btn.SetActive(true);
    }

}
