using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    public GameObject ResetPosition;
    public GameObject Ship;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Heat" || collisionInfo.collider.tag == "Water" || collisionInfo.collider.tag == "Electric")
        {

        }
        else
        {
            Invoke("Restart", 1);
        }
        

    }

    void Restart()
    {
        Ship.transform.position = ResetPosition.transform.position;
        Ship.transform.rotation = ResetPosition.transform.rotation;

        Ship.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ship.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
