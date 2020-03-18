using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CushionController : MonoBehaviour
{
    public float force = 1.2f;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameObject target = collision.gameObject;

            Vector3 inNormal = Vector3.Normalize(transform.position - target.transform.position);
            Vector3 bounceVector = Vector3.Reflect(collision.relativeVelocity, inNormal);

            target.GetComponent<Rigidbody>().AddForce(bounceVector * force, ForceMode.VelocityChange);
            GameManager.Score += 10;
        }
    }
}
