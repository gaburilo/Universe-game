Shader "Odissey/Odissey B" {
	Properties{
		_Color("Color", color) = (1, 1, 1, 1)
		_CoronaFactor("Corona Dumping", Range(0.01, 10)) = 1
		//_InnerSoftnessFactor ("Inner Softness Factor", Range(0,10)) = 1
		_HardnessFactor("Hardness", Range(1, 10)) = 1
		//		_EmissionFactor ("White Emission", Range(0,10)) = 0.0
	}
	SubShader{
			Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }

			Lighting Off
			Fog{ Mode Off }
			ZWrite On
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
#pragma surface surf Lambert vertex:vert finalcolor:finalColor alpha:blend

			//		uniform float fresnelFactor;
			//		uniform float emitFactor;

			sampler2D _MainTex;
			fixed4 _Color;
			float _CoronaFactor;
			//float _InnerSoftnessFactor;
			float _HardnessFactor;
			//		float _EmissionFactor;

			struct Input {
				float2 uv_MainTex;
				float fresnelValue;
				//			float emitValue;
				float coronaValue;
				float hardnessValue;
				//float outerSoftnessValue;
				float normalVSView;
			};

			void vert(inout appdata_full v, out Input o) {

				UNITY_INITIALIZE_OUTPUT(Input, o);

				float3 viewDirection = normalize(ObjSpaceViewDir(v.vertex));
					float normalDotView = dot(v.normal, viewDirection);

				o.fresnelValue = pow(1 - normalDotView, 2);
				o.coronaValue = pow(abs(1 - normalDotView), _CoronaFactor);
				o.hardnessValue = 1 - (pow(abs(1 - normalDotView), _HardnessFactor * 4));

				o.normalVSView = normalDotView;
			}

			void surf(Input IN, inout SurfaceOutput o) {
				//			o.Emission = IN.emitValue;
				//o.Albedo = _Color.rgb;

				float alphaPower = pow(IN.hardnessValue, 16) * sqrt(IN.fresnelValue) * IN.coronaValue;
				if (IN.normalVSView <= 0.05)
					alphaPower = 0.0;

				o.Alpha = alphaPower * _Color.a;
			}

			void finalColor(Input IN, SurfaceOutput o, inout fixed4 color) {
				color.rgb = _Color * IN.coronaValue;
			}
			ENDCG
		}
		FallBack "Diffuse"
}
