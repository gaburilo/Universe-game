Shader "Custom/DiffuseEmitWithAlphaMask" {
	Properties{
		_Color("Main Color", Color) = (1,1,1,1)
		_MainTex("Base (RGB)", 2D) = "white" {}
	_AlphaMask("Alpha (Greyscale RGB)", 2D) = "white" {}
	}
		SubShader{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		LOD 200
		Cull off

		CGPROGRAM
#pragma surface surf Lambert alpha:blend

		fixed4 _Color;
	sampler2D _MainTex;
	sampler2D _AlphaMask;

	struct Input {
		float2 uv_MainTex;
		float2 uv_AlphaMask;
	};

	void surf(Input IN, inout SurfaceOutput o) {
		half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		half4 ca = tex2D(_AlphaMask, IN.uv_AlphaMask);
		o.Albedo = c.rgb;
		o.Emission = half3(c.r, c.g, c.b);
		o.Alpha = c.a * ca.r;
	}
	ENDCG
	}
		FallBack "Diffuse"
}