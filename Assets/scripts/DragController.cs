﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public GameObject objectToSpawn;
    private bool spawned = false;

    Bowl bowl;

    private void Awake()
    {
        canvas = GameObject.Find("kitchenActive").GetComponent<Canvas>();
        bowl = Object.FindObjectOfType<Bowl>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        bowl.currentGameObject = this.gameObject;
        if (!spawned)
        {
            GameObject temp = Instantiate(objectToSpawn, transform.position, transform.rotation, transform.parent);
            temp.GetComponent<DragController>().objectToSpawn = objectToSpawn;
            spawned = true;
        }
        //throw new System.NotImplementedException();
        bowl.OnBeginDrag();
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; 
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        bowl.currentGameObject = this.gameObject;
        bowl.OnDrop();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
    }
    public void OnDrop(PointerEventData eventData)
    {

    }
}
