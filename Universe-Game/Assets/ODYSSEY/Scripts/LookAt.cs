using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {
    
    [SerializeField]
    Transform target;

    enum DIRECTION { FORWARD, RIGHT, UP };
    [SerializeField]
    DIRECTION MapTo = DIRECTION.FORWARD;

    [SerializeField]
    bool invert;

	//void Start () {
		
	//}
	
	void Update () {
        Vector3 dP = target.position - transform.position;
        if (invert)
            dP = -dP;
        if (MapTo == DIRECTION.FORWARD)
            transform.forward = dP.normalized;
        else if(MapTo == DIRECTION.RIGHT)
            transform.right = dP.normalized;
        else if (MapTo == DIRECTION.UP)
            transform.up = dP.normalized;
    }
}
