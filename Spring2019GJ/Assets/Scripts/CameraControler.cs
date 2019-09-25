using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {
  
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(0, Input.GetAxisRaw("Mouse X") * 5f, 0); //Rotates the x axis
        
    }

    void CursorLock()
    {
        Cursor.visible = false;
    }
}
