using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed;
    public float playerRotateSpeed;
    public float cameraZoom;
    [Header("Required Game Objects")]
    public Camera playerCamera;
    [Header("Debug Area")]
    public int buildType;

	void Start () {
        playerCamera.transform.position = new Vector3(transform.position.x, cameraZoom, transform.position.z);
	}
	
	void Update () {
		if(buildType == 1) {
            // PC or Mac
            if(Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * Time.deltaTime * playerSpeed;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * Time.deltaTime * playerSpeed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, Time.deltaTime * -playerRotateSpeed, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, Time.deltaTime * playerRotateSpeed, 0);
            }
        }

        if(buildType == 2)
        {
            // Controller
        }
	}
}
