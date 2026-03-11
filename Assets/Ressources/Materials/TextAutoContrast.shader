Shader "Custom/TextAutoContrast"
{
    Properties
    {
        _MainTex ("Font Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "Queue"="Transparent" }

        Pass
        {
            HLSLPROGRAM

            #include "UnityCG.cginc"

            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            sampler2D _CameraOpaqueTexture;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float2 screenUV : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;

                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;

                o.screenUV = o.pos.xy / o.pos.w;
                o.screenUV = o.screenUV * 0.5 + 0.5;

                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float3 bg = tex2D(_CameraOpaqueTexture, i.screenUV).rgb;

                float luminance =
                    0.299 * bg.r +
                    0.587 * bg.g +
                    0.114 * bg.b;

                float textColor = luminance > 0.5 ? 0.0 : 1.0;

                return float4(textColor, textColor, textColor, 1);
            }

            ENDHLSL
        }
    }
}
