using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    BulletSpawner bulletSpawner;
    public float force;

    private void Update()
    {
        //bulletSpawner.GetComponent<Rigidbody2D>().AddForce(Vector2.left.normalized * force);
    }
}
