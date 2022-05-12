using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : Singleton<PlayerGroundCheck>
{
    public bool isGround => Physics2D.OverlapCircleNonAlloc(transform.position, checkRadius, colliders, checkLayerMask) != 0;
    public float checkRadius;
    public LayerMask checkLayerMask;
    Collider2D[] colliders = new Collider2D[1];

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
