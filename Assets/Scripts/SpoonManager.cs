using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonManager : MonoBehaviour {
    public Rigidbody spoonrb;
    private Vector3 angleVelocity;

    void RotateRB(Rigidbody rb, Vector3 vector) {
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
        var rotation = rb.rotation * deltaRotation;
        //Debug.Log(rotation);
        rb.MoveRotation(rotation);
    }

    void RotateRBTo(Rigidbody rb, Quaternion q) {
        rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, q, 10));
    }

    void RotateRBToFromVector(Rigidbody rb, Vector3 vector) {
        RotateRBTo(rb, Quaternion.Euler(vector));
    }

    // Start is called before the first frame update
    void Start() {
        Debug.Log(SystemInfo.supportsGyroscope);
        Input.gyro.enabled = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToPortrait = true;
    }

    // Update is called once per frame
    void Update() {
        /*spoonrb.velocity = Vector3.zero;
        spoonrb.angularVelocity = Vector3.zero;*/
        Debug.Log(Input.gyro.attitude);
    }
    
    void FixedUpdate() {
        Vector3 vec = Input.gyro.attitude.eulerAngles;
        RotateRBToFromVector(spoonrb, new Vector3(-vec.x, 0, -vec.y));
        if(Input.GetKey("up")) {
            RotateRB(spoonrb, new Vector3(150, 0, 0));
        } if(Input.GetKey("down")) {
            RotateRB(spoonrb, new Vector3(-150, 0, 0));
        } if(Input.GetKey("left")) {
            RotateRB(spoonrb, new Vector3(0, 0, 150));
        } if(Input.GetKey("right")) {
            RotateRB(spoonrb, new Vector3(0, 0, -150));
        } if (Input.GetKey("w")) {
            RotateRBToFromVector(spoonrb, new Vector3(10,10,0));
            //spoonrb.MoveRotation(new Quaternion(10,10,10,0).normalized);
        } 
        
    }
    
}
