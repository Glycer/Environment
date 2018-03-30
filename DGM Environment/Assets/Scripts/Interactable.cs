using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public Action<bool> Activate;

    public bool isActive;

	// Use this for initialization
	void Start () {
        Activate += SetState;
	}

    private void OnMouseDown()
    {
        Activate(isActive ? false : true);
    }

    void SetState(bool state)
    {
        isActive = state;
    }
}
