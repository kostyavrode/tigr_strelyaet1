using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float liveTIme;
    private void Start()
    {
        transform.LookAt(Target.instance.GetTargetPosition());
    }
    private void FixedUpdate()
    {
        liveTIme-= Time.fixedDeltaTime;
        if (liveTIme<0)
        {
            Destroy(gameObject);
        }
        
        transform.position += transform.forward * Time.fixedDeltaTime * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Duck")
        {
            Duck hittedDuck= other.GetComponent<Duck>();
            if (hittedDuck.isAlive)
                GameManager.instance.IncreaseScore();
            hittedDuck.Death();
            Destroy(gameObject);
            Debug.Log("UYES");
        }
        else
        {
            Debug.Log("NO");
        }
    }
}
