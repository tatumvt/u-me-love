using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Android;

public class Gamemanager : MonoBehaviour
{
    bool gameEnded = false;
    bool EndGame = false;
    public bool ignore;
    public GameObject replaycanvas;
    public GameObject phoneCanvas;
    public GameObject dialogueCanvas;
    public GameObject continueButton;

    [SerializeField]
    private bool isTutorial;

    public static Gamemanager Instance
    {
        get;
        private set;
    }
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            continueButton.SetActive(true);
            //dialogueCanvas.SetActive(true);
            Destroy(GameObject.Find("sleep"));
            phoneCanvas.SetActive(true);
        }
    }

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        if (isTutorial)
        {
            StartCoroutine(WaitAndPrint(2.3f));
        }

    }
    void Endgame()
    {
        if (!EndGame)
        {
            replaycanvas.SetActive(true);
            EndGame = true;
        }
    }
}
