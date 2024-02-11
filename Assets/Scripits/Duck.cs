using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float speed;
    public float liveTIme;
    public bool isAlive;
    private void Awake()
    {
        isAlive = true;
    }
    public void SetDuckTarget(Transform target)
    {
        transform.LookAt(target);
    }
    private void FixedUpdate()
    {
        liveTIme -= Time.fixedDeltaTime;
        if (liveTIme < 0)
        {
            Destroy(gameObject);
        }

        transform.position += transform.forward * Time.fixedDeltaTime * speed;
    }
    public void Death()
    {
        isAlive = false;
        rigidbody.isKinematic = false;
        speed = speed/2;
        GetComponentInChildren<Animator>().SetBool("isDead", true);
    }
}
