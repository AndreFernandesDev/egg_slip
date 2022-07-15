using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonManager : MonoBehaviour {
    public Rigidbody spoonrb;
    private Vector3 angleVelocity;

    void RotateRB(Rigidbody rb, Vector3 vector) {
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
        rb.MoveRotation(spoonrb.rotation * deltaRotation);
    }

    // Start is called before the first frame update
    void Start() {
        Debug.Log(SystemInfo.supportsGyroscope);
    }

    // Update is called once per frame
    void FixedUpdate() {
         if(Input.GetKey("up")) {
            RotateRB(spoonrb, new Vector3(50, 0, 0));
        } if(Input.GetKey("down")) {
            RotateRB(spoonrb, new Vector3(-50, 0, 0));
        } if(Input.GetKey("left")) {
            RotateRB(spoonrb, new Vector3(0, 0, 50));
        } if(Input.GetKey("right")) {
            RotateRB(spoonrb, new Vector3(0, 0, -50));
        } else {
            spoonrb.velocity = new Vector3(0, 0, 0);
        }
        Debug.Log(spoonrb.velocity);

        
    }
}
