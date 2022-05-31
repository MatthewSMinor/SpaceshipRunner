using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public int cameraOffset = 10;

    public int horizontalCameraOffset = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(
            player.transform.position.x + horizontalCameraOffset,
            0,
            -cameraOffset);
    }
}
