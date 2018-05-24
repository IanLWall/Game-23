using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool isHidden;


	// Use this for initialization
	void Start () {
        isHidden = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "safespace")
        {
            Debug.Log("Hidden");
            isHidden = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "safespace")
        {
            isHidden = false;
        }
    }
}
