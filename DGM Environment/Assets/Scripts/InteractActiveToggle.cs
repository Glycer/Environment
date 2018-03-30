using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractActiveToggle : MonoBehaviour {

    Interactable interact;

	// Use this for initialization
	void Start () {
        interact = GetComponentInParent<Interactable>();
        interact.Activate += Toggle;

        gameObject.SetActive(false);
	}

    void Toggle(bool toActive)
    {
        gameObject.SetActive(toActive);
    }
}
