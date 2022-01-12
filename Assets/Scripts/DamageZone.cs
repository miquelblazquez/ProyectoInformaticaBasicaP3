using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        JohnMovement controller = other.GetComponent<JohnMovement>();

        if (controller != null)
        {
            controller.ChangeHealth(-2);
        }
    }
}