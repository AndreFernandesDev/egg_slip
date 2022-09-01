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

    Quaternion referenceRotation;

    // Start is called before the first frame update
    void Start() {
        Debug.Log(SystemInfo.supportsGyroscope);
        Input.gyro.enabled = true;
        referenceRotation = Quaternion.Inverse( Input.gyro.attitude );
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToPortrait = true;
    }

    // Update is called once per frame
    void FixedUpdate() {
        /*spoonrb.velocity = Vector3.zero;
        spoonrb.angularVelocity = Vector3.zero;*/

    }

    void Calibrate() {
        referenceRotation = Quaternion.Inverse( Input.gyro.attitude );
    }
    
    void Update() {

        if (referenceRotation.x == 0 &&
            referenceRotation.x == 0 &&
            referenceRotation.x == 0 &&
            referenceRotation.x == 0) {
            Calibrate();

        }

        var raw = Input.gyro.attitude;
        var rot = referenceRotation * raw;
        var euler = rot.eulerAngles;

        var zRot = Quaternion.AngleAxis( euler.z, Vector3.forward );

        // reverse the rotation about the z-axis
        rot = Quaternion.Inverse( zRot ) * rot;

        Vector3 target = rot.eulerAngles;

        RotateRBToFromVector(spoonrb, new Vector3(-target.x, target.z, -target.y));
        //transform.rotation = rot;


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
