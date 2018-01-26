using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewControl : MonoBehaviour {

    public static Action<float> Turn;

    public Transform player;

    public float xSense;
    public float ySense;

    float delay = .03f;

    PlayerControl control;

    Coroutine follow;
    Coroutine playerLook;
    bool isFollowing = false;

	// Use this for initialization
	void Start ()
    {
        Turn += TurnAround;

        StartFollow();
        control = player.GetComponent<PlayerControl>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isFollowing)
        {
            StopFollow();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !isFollowing)
        {
            StartFollow();
        }
    }

    IEnumerator Follow()
    {
        while (true)
        {
            transform.Rotate(player.transform.right, -Input.GetAxis("Mouse Y") * ySense);
            Turn(Input.GetAxis("Mouse X") * xSense);

            yield return new WaitForSeconds(delay);
        }
    }

    void StartFollow()
    {
        follow = StartCoroutine(Follow());
        //playerLook = StartCoroutine(control.Look());
        isFollowing = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void StopFollow()
    {
        StopCoroutine(follow);
        isFollowing = false;
        Cursor.lockState = CursorLockMode.None;
    }

    void TurnAround(float speed)
    {
        transform.Rotate(player.transform.up, speed);
    }
}
