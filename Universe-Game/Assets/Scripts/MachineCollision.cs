
using UnityEngine;

public class MachineCollision : MonoBehaviour
{


    //public GameObject cube;
    //public GameObject spawner;
    public GameObject container;
    public GameObject trigger;

    void start()
    {
        //cube.SetActive(false);
    }


   void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == trigger.tag)
        {
            //spawn();
            //setVisble();
            Destroy(container);
        }
    }

    /*void spawn()
    {
        Instantiate(cube, spawner.transform.position, spawner.transform.rotation);
    }

    void setVisble()
    {
        cube.SetActive(true);
    }*/


}
