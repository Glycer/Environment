using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liftable : MonoBehaviour {

    Interactable interact;

	// Use this for initialization
	void Start () {
        interact = GetComponent<Interactable>();

        interact.Activate += Controlled;
	}

    void Controlled(bool isControlled)
    {
        if (isControlled)
            LiftControl.Lift(transform);
        else
            LiftControl.LetGo(transform);
    }
}
