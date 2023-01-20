using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilleBase : MonoBehaviour
{
    public List<string> tags;
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
        foreach(var t in tags)
        {
            if(collision.transform.tag == t)
            {
                var damageable = collision.transform.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    Vector3 dir = collision.transform.position - transform.position;
                    dir = -dir.normalized;
                    dir.y = 0;

                    damageable.Damage(damageAmount, dir);
                    Destroy(gameObject);
                }

                break;
            }
        }
    }
}
