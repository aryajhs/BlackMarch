Shader "Custom/RimLight"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        _RimColor ("Rim Color", Color) = (0,0,0,1)
        _RimPower ("Rim Power", Range(0.1, 8)) = 3
    }
 
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
 
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
 
        struct Input
        {
            float3 worldPos;
            float3 worldNormal;
        };
 
        half _RimPower;
        fixed4 _Color;
        fixed4 _RimColor;
 
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Calculate view direction
            float3 viewDir = normalize(_WorldSpaceCameraPos - IN.worldPos);

            // Calculate rim lighting
            half rim = 1.0 - saturate(dot(normalize(IN.worldNormal), viewDir));
            rim = pow(rim, _RimPower);
 
            // Combine main color and rim color
            o.Albedo = _Color.rgb;
            o.Emission = _RimColor.rgb * rim;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
