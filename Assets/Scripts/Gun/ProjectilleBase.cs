using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilleBase : MonoBehaviour
{
    public int damageAmount;
    public float speed;
    public float timeToDestroy;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damageable = collision.transform.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.Damage(damageAmount);
            Destroy(gameObject);
        }
    }
}
