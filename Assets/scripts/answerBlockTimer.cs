using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerBlockTimer : MonoBehaviour
{
    public GameObject btn;
    public GameObject popup;
    public Canvas map;
    public bool isLvlTen;

    // Update is called once per frame
    void Start()
    {
        WaitForAnswer();
    }
    private void Update()
    {
        if (isLvlTen && map)
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
        yield return new WaitForSeconds(12f);
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
        yield return new WaitForSeconds(2f);
        popup.SetActive(true);
    }


}
