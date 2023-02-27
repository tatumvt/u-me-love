using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ingredientSpawn : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public GameObject objectToSpawn;
    public GameObject spawnPos;
    public bool stopSpawning;

    // Start is called before the first frame update
    void Start()
    {
        stopSpawning = false;
    }

    public void SpawnObject()
    {
           Instantiate(objectToSpawn, spawnPos.transform.position, transform.rotation, transform);
            if (stopSpawning)
            {
                CancelInvoke("SpawnObject");
            }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        SpawnObject();
    }
    public void OnDrag(PointerEventData eventData)
    {
    }

}
