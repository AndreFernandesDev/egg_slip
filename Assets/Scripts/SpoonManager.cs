using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonManager : MonoBehaviour {
    public Rigidbody spoonrb;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(Input.GetKey("up")) {
            spoonrb.velocity = Vector3.up * 3f;
        } else if(Input.GetKey("down")) {
            spoonrb.velocity = Vector3.down * 3f;
        } else {
            spoonrb.velocity = new Vector3(0, 0, 0);
        }
        Debug.Log(spoonrb.velocity);
    }
}
