using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
