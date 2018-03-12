using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour {

    public Transform playerCam;
    public float range;

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

        StartCoroutine(InteractableCheck());
	}

    IEnumerator InteractableCheck()
    {
        while (true)
        {
            RaycastHit hit;

            if (Physics.Raycast(playerCam.transform.position, playerCam.forward, out hit, range))
            {
                print(hit.transform.name);
                anim.SetBool("isActive", (hit.collider.transform.GetComponent<Interactable>() != null ? true : false));
            }
            else
            {
                anim.SetBool("isActive", false);
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
}
