using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PantherControl : MonoBehaviour {

    //public bool isMoving;
    public Transform player;
    public float speed;

    Interactable interact;
    Animator anim;
    NavMeshAgent agent;
    float delay = .3f;

    Coroutine motor;

	// Use this for initialization
	void Start () {
        interact = GetComponent<Interactable>();
        interact.Activate += Animate;

        anim = GetComponent<Animator>();
        agent = GetComponentInParent<NavMeshAgent>();
	}
    
    IEnumerator WalkCheck()
    {
        while (true)
        {
            Target();

            if (agent.remainingDistance >= agent.stoppingDistance)
                anim.SetBool("IsWalking", true);
            else
                anim.SetBool("IsWalking", false);

            yield return new WaitForSeconds(delay);
        }
    }

    public void Animate(bool isActive)
    {
        anim.SetBool("IsActive", isActive);

        if (isActive)
        {
            motor = StartCoroutine(WalkCheck());
        }
        else
            StopCoroutine(motor);
    }

    public void Target()
    {
        agent.destination = player.position;
    }
}
