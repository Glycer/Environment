using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public Transform cam;
    public float speed;

    float delay = .03f;
    CharacterController controller;

	// Use this for initialization
	void Start () {
        //ViewControl.Turn += Turn;

        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        controller.SimpleMove(Input.GetAxis("Vertical") * transform.forward * speed);

        transform.Rotate(0, Input.GetAxis("Horizontal") * 2, 0);
    }

    /*
    void Turn(float speed)
    {
        transform.Rotate(transform.up, speed);
    }
    */

    /*
    public IEnumerator Look()
    {
        while (true)
        {
            Quaternion currentRot = transform.localRotation;
            float tempRot = cam.rotation.y;
            currentRot.y = tempRot;

            transform.localRotation = currentRot;

            yield return new WaitForSeconds(delay);
        }
    }
    */

}
