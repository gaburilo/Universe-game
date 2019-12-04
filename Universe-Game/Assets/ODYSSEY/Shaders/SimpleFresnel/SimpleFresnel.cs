using UnityEngine;
using System.Collections;

public class SimpleFresnel : MonoBehaviour {
	
	public float fresnelFactor = 1f;
	public bool realTimeUpdate = true;
	
	// Use this for initialization
	void Start () {
		setUniforms();
	}
	
	// Update is called once per frame
	void Update () {
		if(realTimeUpdate)
			setUniforms();
	}
	
	void setUniforms() {
		transform.GetComponent<Renderer>().material.SetFloat("fresnelFactor", fresnelFactor);
	}
}
