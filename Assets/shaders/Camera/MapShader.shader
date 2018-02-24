Shader "Camera/MapShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
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

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				// i.uv[0]**2 + i.uv[1]**2 = 1
				float2 coordfromcenter = i.uv - float2(0.5, 0.5);

                float pixelWidth = 1 / _ScreenParams.x;
                float pixelHeight = 1 / _ScreenParams.y;

                float4 deltacolor =
                    (tex2D(_MainTex, i.uv + float2(pixelWidth,0)) +
                    tex2D(_MainTex, i.uv + float2(-pixelWidth,0)) +
                    tex2D(_MainTex, i.uv + float2(0,pixelHeight)) +
                    tex2D(_MainTex, i.uv + float2(0,-pixelHeight))) / 4 - col;
                if (deltacolor.r + deltacolor.g + deltacolor.b > 0.04) {
                    return float4(0,1,0,1);
                }
                else {
                    return float4(0,0,0,1);
                }

			}
			ENDCG
		}
	}
}
