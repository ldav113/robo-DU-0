using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform myTarget;
    public float cameraDistance;

    void Awake ()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }


    // Update is called once per frame
    void Update()
    {
        if(myTarget != null)
        {
            Vector3 targPos = myTarget.position;
            targPos.z = transform.position.z;
           
            transform.position = targPos;
        }
    }
}
