Shader "Odissey/Odissey A" {
	Properties{
		_Color("Color", color) = (1, 1, 1, 1)
		_MainTex("Texture", 2D) = "white" {}
		_FresnelFactor("Fresnel Factor", Range(-10, 1)) = 0.5
			_EmissionFactor("White Emission", Range(0, 10)) = 0.0
	}
	SubShader{
			Tags{ "Queue" = "Transparent" "RenderType" = "Diffuse" }

			Lighting Off
			Fog{ Mode Off }
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
#pragma surface surf Lambert vertex:vert alpha:blend

			//		uniform float fresnelFactor;
			//		uniform float emitFactor;

			sampler2D _MainTex;
			fixed4 _Color;
			float _FresnelFactor;
			float _EmissionFactor;

			struct Input {
				float2 uv_MainTex;
				float fresnelValue;
				float emitValue;
			};

			void vert(inout appdata_full v, out Input o) {

				UNITY_INITIALIZE_OUTPUT(Input, o);

				float3 viewDirection = normalize(ObjSpaceViewDir(v.vertex));
					float3 lightDirection = normalize(ObjSpaceLightDir(v.vertex));
					//float3 vcoords = v.vertex.xyz;
					o.fresnelValue = (1 - saturate(-dot(v.normal, viewDirection) * _FresnelFactor))
					* saturate(dot(v.normal, lightDirection));
				o.emitValue = _EmissionFactor;
			}

			void surf(Input IN, inout SurfaceOutput o) {
				half4 c = tex2D(_MainTex, IN.uv_MainTex);
					o.Albedo = c * _Color;
				o.Alpha = sqrt(IN.fresnelValue) * c.a * _Color.a;
				o.Emission = c * IN.emitValue * IN.fresnelValue;
			}
			ENDCG
		}
		FallBack "Diffuse"
}
