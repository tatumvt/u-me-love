using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerBlockTimer : MonoBehaviour
{
    public GameObject btn;

    // Update is called once per frame
    void Start()
    {
        WaitForAnswer();
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
}
