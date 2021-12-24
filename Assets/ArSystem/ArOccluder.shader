Shader "Unlit/ArOccluder"
{
    Properties
    {

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                //o.vertex += float4(0,0.4,0,0);
                o.uv = float2(0,0);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                
                return 0;
                return fixed4(1,0.067,0.333,1);
            }
            ENDCG
        }
    }
}
