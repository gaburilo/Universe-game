using UnityEngine;
using System.Collections;

public class TextureSlider : MonoBehaviour {

	public string targetTextureName = "";

	public Vector2 speed = Vector2.one;

	[HideInInspector]
	public bool stringOverride = false;
	[HideInInspector]
	public int selectedPopupTextureIdx = 0;

	Material mat;

	void Start () {
		mat = GetComponent<Renderer>().material;
	}

	void Update () {
		Vector2 offset = mat.GetTextureOffset (targetTextureName);
		mat.SetTextureOffset (targetTextureName, offset + speed * Time.deltaTime);
	}
}
