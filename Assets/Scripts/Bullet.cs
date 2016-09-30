using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public CircleCollider2D destructionCircle;
    // Use this for initialization
    void Awake()
    {
        destructionCircle = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Ground")
        {
            Debug.Log(coll.gameObject);
            coll.gameObject.GetComponent<DestructableTerrain>().GroundUpdate(destructionCircle);
            Destroy(gameObject);
        }
    }
}
