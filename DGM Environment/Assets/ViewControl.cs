using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewControl : MonoBehaviour {

    float delay = .03f;

    Coroutine follow;
    bool isFollowing = false;

	// Use this for initialization
	void Start ()
    {
        //StartFollow();
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Escape) && isFollowing)
        {
            StopFollow();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !isFollowing)
        {
            StartFollow();
        }
        */
    }

    IEnumerator Follow()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
        }
    }

    void StartFollow()
    {
        follow = StartCoroutine(Follow());
        isFollowing = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void StopFollow()
    {
        StopCoroutine(follow);
        isFollowing = false;
        Cursor.lockState = CursorLockMode.None;
    }

}
