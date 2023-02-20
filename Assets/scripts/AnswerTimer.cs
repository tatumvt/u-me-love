using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerTimer : MonoBehaviour
{
    public GameObject blockAnsBTN;
    float currentTime = 0f;
    float startingTime = 110f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        Time.timeScale = 1;
        blockAnsBTN.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        BlockAns();
    }

    public void BlockAns()
    {
        if (currentTime <= 0)
        {
            blockAnsBTN.SetActive(true);
        }
    }
}
