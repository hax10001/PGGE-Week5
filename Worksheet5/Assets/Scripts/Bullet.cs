using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        // Destroy the bullet after 10 seconds if it does not hit any object.
        StartCoroutine(Coroutine_Destroy(10.0f));
    }

    // Refactor #3

    //void Update()
    //{
    //}

    IEnumerator Coroutine_Destroy(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable obj = collision.gameObject.GetComponent<IDamageable>();

        // Refactor #1
        
        // New Code

        if (obj != null) obj.TakeDamage();

        StartCoroutine(Coroutine_Destroy(0.1f)); 

        // Old Code

        //if (obj != null)
        //{
        //    obj.TakeDamage();
        //}

        //StartCoroutine(Coroutine_Destroy(0.1f));
    }
}
