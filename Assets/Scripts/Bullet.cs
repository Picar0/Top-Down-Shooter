using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [SerializeField] private float lifeTime = 3f;

    private new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        //? Remove the bullet after its lifeTime
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        //? Keep the bullet goind forward
        rigidbody.velocity = transform.forward * speed;
    }
}
