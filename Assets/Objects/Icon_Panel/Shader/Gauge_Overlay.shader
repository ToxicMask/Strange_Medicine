Shader "Custom/Gauge_Meter"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_AlphaTint("Alpha Tint", Range(0.5,1.0)) = 1
		_MainTint("Main Tint Color", color) = (1, 1, 1, 1)
		_Progress_Tint_Color("Progress Tint Color", color) = (1, 1, 1, 1)
		_Progress("Current Tint Progress", Range(0.0,1.0)) =0
		_MinY("Minimal step of progress", Range(0.0,0.9)) = 0
		_MaxY("Maximal step of progress", Range(0.1,1.0)) = 1
    }
    SubShader
    {
		Tags { "RenderType" = "Opaque" "Queue" = "Transparent+1"}
        LOD 100

		//ZWrite Off
		// Set up alpha blending
		ZTest Off
		Blend SrcAlpha OneMinusSrcAlpha

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

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float _AlphaTint;
			float4 _MainTint;
			float4 _Progress_Tint_Color;
			float _Progress;
			float _MinY;
			float _MaxY;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				col.a *= _AlphaTint;

				if  ( (_MaxY - (_Progress *(_MaxY - _MinY)) )> i.uv.y   &&  i.uv.y > (_MinY )) //  Fx	Progress && minimal treshold 				 (_MinX+_Fill*(_MaxX-_MinX))///((i.uv.y < _MinY) ||
					{
					col *= _Progress_Tint_Color;
					return  col;
					}

				col *= _MainTint;
				col.a;
                return col;
            }
            ENDCG
        }
    }
}
