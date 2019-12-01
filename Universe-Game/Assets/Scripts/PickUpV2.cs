using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpV2 : MonoBehaviour
{
    bool pickedUp = false;
    public GameObject tempParent;
    public Transform guide;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                if (hit.collider.tag == "Electric" || hit.collider.tag == "Heat")
                {


                    if (pickedUp == false)
                    {
                        print(hit.transform.gameObject);
                        //hit.GetComponent<Rigidbody>().isKinematic = true;
                        hit.transform.position = guide.transform.position;
                        hit.transform.rotation = guide.transform.rotation;
                        hit.transform.parent = tempParent.transform;


                    }
                }
            }
        }
    }

    /*void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
                if (hit.collider.tag == "Electric" || hit.collider.tag == "Heat")
                {
                    print(hit.transform.gameObject);                 
                }    
        }
    }*/

    
}





