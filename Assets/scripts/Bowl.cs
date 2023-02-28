using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bowl : MonoBehaviour, IDropHandler //IEndDragHandler
{
    public amountManager ss;
    public GameObject currentGameObject;

    [Header("Amounts")]
    public int theScoreTen;
    public int theScoreFive;

    void Start()
    {
        ss.Init();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            Drop();
    }

    void Drop() {
        if (currentGameObject != null)
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

    public void OnDrop(PointerEventData eventData)
    {
        Drop();
    }
}
