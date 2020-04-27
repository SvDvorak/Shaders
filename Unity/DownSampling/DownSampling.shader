Shader "Custom/DownSampling"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "" {}
		_LowResAmount("DownSampling", int) = 10
	}
	Subshader
	{
		Pass{
		ZTest Always Cull Off ZWrite Off
		CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform int _DownSampling;

			fixed4 frag(v2f_img i) : SV_Target
			{
				half2 newUV = i.uv * _ScreenParams.xy;
				float u = (floor(newUV.x / _DownSampling)*_DownSampling) / _ScreenParams.x;
				float v = (floor(newUV.y / _DownSampling)*_DownSampling) / _ScreenParams.y;
	
				return tex2D(_MainTex, float2(u,v));
			}
		ENDCG
		}
	}
	Fallback off
}