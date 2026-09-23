Shader "Custom/Shader"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _SphereCenter ("Sphere Center", Vector) = (0, 0, 0, 0)
        _SphereRadius ("Sphere Radius", Float) = 1
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float4 _Color;
            float3 _SphereCenter;
            float _SphereRadius;

            struct Attributes
            {
                float4 positionOS : POSITION;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float3 positionWS : TEXCOORD0;
            };

            Varyings vert(Attributes input)
            {
                Varyings output;

                output.positionWS =
                    mul(unity_ObjectToWorld, input.positionOS).xyz;

                output.positionCS =
                    UnityObjectToClipPos(input.positionOS);

                return output;
            }

            float4 frag(Varyings input) : SV_Target
            {
                float3 offset =
                    input.positionWS - _SphereCenter;

                float distanceSquared =
                    dot(offset, offset);
                if (distanceSquared > _SphereRadius * _SphereRadius)
                    discard;

                return _Color;
            }

            ENDHLSL
        }
    }
}