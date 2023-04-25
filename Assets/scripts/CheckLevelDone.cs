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
    public GameObject play;
    public GameObject locked;

    void Update()
    {
        //Active
        if (PlayerPrefs.GetInt(levelToCheck) == 1)
        {
            play.gameObject.SetActive(true);
            done.gameObject.SetActive(false);
            locked.gameObject.SetActive(false);
            this.GetComponent<Button>().enabled = true;
        }
        //Done
        else if (PlayerPrefs.GetInt(levelToCheck) == 2)
        {
            play.gameObject.SetActive(false);
            done.gameObject.SetActive(true);
            locked.gameObject.SetActive(false);
            this.GetComponent<Button>().enabled = false;
        }
        //Inactive
        else if (PlayerPrefs.GetInt(levelToCheck) == 0)
        {
            play.gameObject.SetActive(false);
            done.gameObject.SetActive(false);
            locked.gameObject.SetActive(true);
            this.GetComponent<Button>().enabled = false;
        }
    }
}
