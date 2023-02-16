using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckLevelDone : MonoBehaviour
{
    public string levelToCheck;
    public bool levelDone;
    public GameObject done;
    public Image circle;

    void Update()
    {
        //Active
        if (PlayerPrefs.GetInt(levelToCheck) == 1)
        {
            circle.gameObject.SetActive(true);
            done.gameObject.SetActive(false);
            this.GetComponent<Button>().enabled = true;
        }
        //Done
        else if (PlayerPrefs.GetInt(levelToCheck) == 2)
        {
            circle.gameObject.SetActive(false);
            done.gameObject.SetActive(true);
            this.GetComponent<Button>().enabled = false;
        }
        //Inactive
        else if (PlayerPrefs.GetInt(levelToCheck) == 0)
        {
            circle.gameObject.SetActive(false);
            done.gameObject.SetActive(false);
            this.GetComponent<Button>().enabled = false;
        }
    }
}
