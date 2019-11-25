
using UnityEngine;

public class MachineCollision : MonoBehaviour
{


    public GameObject cube;
    public GameObject spawner;


   void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Electric")
        {
            spawn();
        }
    }

    void spawn()
    {
        Instantiate(cube, spawner.transform.position, spawner.transform.rotation);
    }
}
