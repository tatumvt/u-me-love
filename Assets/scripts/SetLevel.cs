using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevel : MonoBehaviour
{
    public void SetLevelDone(string playerpref)
    {
        PlayerPrefs.SetInt(playerpref, 2);
    }

    public void EnableNextLevel(string playerpref)
    {
        PlayerPrefs.SetInt(playerpref, 1);
    }
}
