Shader "Custom/TVStatic"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Speed ("Scroll Speed", Float) = 1.0
        _Intensity ("Intensity", Float) = 1.0
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

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 texcoord : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Speed;
            float _Intensity;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Scroll the texture
                float2 uv = i.texcoord;
                uv.y += _Time.y * _Speed;
                fixed4 col = tex2D(_MainTex, uv);

                // Apply intensity to simulate TV flickering
                col *= _Intensity;

                return col;
            }
            ENDCG
        }
    }
}
