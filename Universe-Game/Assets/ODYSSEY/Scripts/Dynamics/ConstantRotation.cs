using UnityEngine;
using System.Collections;

public class ConstantRotation : MonoBehaviour {
	
	Quaternion initialRotation;
	
	public Vector3 eulerSpeeds = Vector3.one.normalized;
	
	void Start () {

	}
	
	void Update () {
        transform.rotation *= Quaternion.Euler(eulerSpeeds * Time.deltaTime);
	}
}
