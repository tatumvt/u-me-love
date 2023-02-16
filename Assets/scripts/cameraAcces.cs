using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAcces : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.RequestUserAuthorization(UserAuthorization.WebCam);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
