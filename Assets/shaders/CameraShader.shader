﻿Shader "Camera/CameraShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_NoiseTex("Noise Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _NoiseTex;			

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				// i.uv[0]**2 + i.uv[1]**2 = 1
				float2 coordfromcenter = i.uv - float2(0.5, 0.5);
				float addblack = abs(pow(coordfromcenter[0], 2) + pow(coordfromcenter[1], 2));			

				col -= float4(addblack, addblack, addblack, 0);
				float blacknwhite = (col.r + col.b + col.g) / 3;
				col = fixed4(blacknwhite, blacknwhite, blacknwhite, col.a);
				col -= tex2D(_NoiseTex, i.uv) / 10;
				return col;
			}
			ENDCG
		}
	}
}
