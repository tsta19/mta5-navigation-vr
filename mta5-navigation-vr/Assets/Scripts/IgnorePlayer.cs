using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
        }
    }
}

  