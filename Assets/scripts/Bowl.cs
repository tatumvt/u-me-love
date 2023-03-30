using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bowl : MonoBehaviour
{
    public amountManager ss;
    public GameObject currentGameObject;

    public float minDistance = 1;

    [Header("Amounts")]
    public int theScoreTen;
    public int theScoreFive;

    void Start()
    {
        ss.Init();
    }


    void Drop() {
        if (currentGameObject != null)
        {
            Debug.Log(Vector3.Distance(transform.position, currentGameObject.transform.position) < minDistance);
            if (Vector3.Distance(transform.position, currentGameObject.transform.position) < minDistance)
            {
                if (currentGameObject.tag == "flourTen")
                    ss.addScore(theScoreTen, 0);
                else if (currentGameObject.tag == "FlourFive")
                    ss.addScore(theScoreFive, 0);
                else if (currentGameObject.tag == "chocoTen")
                    ss.addScore(theScoreTen, 1);
                else if (currentGameObject.tag == "chocoFive")
                    ss.addScore(theScoreFive, 1);
                else if (currentGameObject.tag == "sugarTen")
                    ss.addScore(theScoreTen, 2);
                else if (currentGameObject.tag == "sugarFive")
                    ss.addScore(theScoreFive, 2);
                else if (currentGameObject.tag == "milkTen")
                    ss.addScore(theScoreTen, 4);
                else if (currentGameObject.tag == "milkFive")
                    ss.addScore(theScoreFive, 4);
                else if (currentGameObject.tag == "egg")
                    ss.addScore(theScoreTen, 3);
                currentGameObject = null;
            }       
        }
    }

    void PickUp()
    {
        if (currentGameObject != null)
        {
            if (Vector3.Distance(transform.position, currentGameObject.transform.position) < minDistance)
            {
                if (currentGameObject.tag == "flourTen")
                    ss.removeScore(theScoreTen, 0);
                else if (currentGameObject.tag == "FlourFive")
                    ss.removeScore(theScoreFive, 0);
                else if (currentGameObject.tag == "chocoTen")
                    ss.removeScore(theScoreTen, 1);
                else if (currentGameObject.tag == "chocoFive")
                    ss.removeScore(theScoreFive, 1);
                else if (currentGameObject.tag == "sugarTen")
                    ss.removeScore(theScoreTen, 2);
                else if (currentGameObject.tag == "sugarFive")
                    ss.removeScore(theScoreFive, 2);
                else if (currentGameObject.tag == "milkTen")
                    ss.removeScore(theScoreTen, 4);
                else if (currentGameObject.tag == "milkFive")
                    ss.removeScore(theScoreFive, 4);
                else if (currentGameObject.tag == "egg")
                    ss.removeScore(theScoreTen, 3);
                currentGameObject = null;
            }
        }
    }

    public void OnDrop()
    {
        Drop();
    }

    public void OnBeginDrag()
    {
        PickUp();
    }
}
