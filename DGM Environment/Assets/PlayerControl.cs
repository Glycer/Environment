using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed;

    CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        controller.SimpleMove(Input.GetAxis("Vertical") * transform.forward * speed);

        transform.Rotate(0, Input.GetAxis("Horizontal") * 2, 0);
    }
}
