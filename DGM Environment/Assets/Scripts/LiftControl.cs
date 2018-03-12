using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftControl : MonoBehaviour {

    public static Action<Transform> Lift;
    public static Action<Transform> LetGo;
    public Transform effect;

    Transform storedParent;

	// Use this for initialization
	void Start () {
        Lift += Pull;
        LetGo += Drop;
	}

    void Pull(Transform obj)
    {
        //effect.gameObject.SetActive(true);

        storedParent = obj.parent;

        obj.position = transform.position;
        obj.parent = transform;
        LockPosition(obj, true);
    }

    void Drop(Transform obj)
    {
        //effect.gameObject.SetActive(false);

        obj.parent = storedParent;
        LockPosition(obj, false);
    }

    void LockPosition(Transform obj, bool isLock)
    {
        Rigidbody rigid = obj.GetComponent<Rigidbody>();
        rigid.constraints = isLock ? RigidbodyConstraints.FreezeAll : RigidbodyConstraints.None;
    }
}
