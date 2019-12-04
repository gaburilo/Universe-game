using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(TextureSlider))]
public class TextureSliderEditor : Editor {

	public override void OnInspectorGUI()
	{

		TextureSlider myTarget = (TextureSlider)target;

		EditorGUILayout.Space ();

		int shaderPropertyCount = ShaderUtil.GetPropertyCount (myTarget.GetComponent<Renderer>().sharedMaterial.shader);

		myTarget.stringOverride = EditorGUILayout.Toggle (new GUIContent ("String Override", "Use this to override automatic properties menu."), myTarget.stringOverride);

		if (myTarget.selectedPopupTextureIdx > shaderPropertyCount)
				myTarget.selectedPopupTextureIdx = 0;

		if(myTarget.stringOverride == false)
		{

			string[] shaderTextureProperties = new string[shaderPropertyCount];
			List<string> tempShaderPropertiesList = new List<string> ();

			for(int i=0; i<shaderPropertyCount; i++)
			{
				if(ShaderUtil.GetPropertyType(myTarget.GetComponent<Renderer>().sharedMaterial.shader, i) == ShaderUtil.ShaderPropertyType.TexEnv)
				{
					tempShaderPropertiesList.Add(ShaderUtil.GetPropertyName(myTarget.GetComponent<Renderer>().sharedMaterial.shader, i));
				}
			}

			shaderTextureProperties = tempShaderPropertiesList.ToArray ();
			EditorGUILayout.PrefixLabel ("Shader's Target Texture");
			myTarget.selectedPopupTextureIdx = EditorGUILayout.Popup (myTarget.selectedPopupTextureIdx, shaderTextureProperties);

			myTarget.targetTextureName = shaderTextureProperties [myTarget.selectedPopupTextureIdx];

		}
		else
		{
			myTarget.targetTextureName = EditorGUILayout.TextField(myTarget.targetTextureName);
		}

		myTarget.speed = EditorGUILayout.Vector2Field ("Speeds", myTarget.speed);

		if(GUI.changed)
			EditorUtility.SetDirty(myTarget);
	}

}
