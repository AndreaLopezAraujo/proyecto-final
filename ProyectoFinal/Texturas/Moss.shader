Shader "Custom/MossOverlay"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _MossBump ("Normal Bump Tex", 2D) = "bump" {}
        _BumpScale ("Bump Amount", Range(1, 10)) = 0

        _Radius ("Radius", Range(0, 1)) = 0.5
        _NoiseSize ("Noise", Range(0,1)) = 0.1
        _NoiseTex ("Noise Texture", 2D) = "white" {}
        _centerY ("Center Y", Range(0, 1)) = 0
        _centerX ("Center X", Range(0, 1)) = 0
        _TimeFactor ("Time Multiplier", Range(0.1, 2)) = 1

        _RandSlider ("Some Slider", Range(0, 1)) = 0

        //Scale properties 
        _ScaleX ("Scale X", Range(0.1, 10)) = 1
        _ScaleY ("Scale Y", Range(0.1, 10)) = 1
        _OffsetX ("Offset X", Range(0, 1)) = 0.0
        _OffsetY ("Offset Y", Range(0, 1)) = 0.0
        
    }
    SubShader
    {
        Tags { "Queue"="Transparent" }
 

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types  
        #pragma surface surf Lambert alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _MossBump;
        float _BumpScale;
        float _NoiseSize;
        sampler2D _NoiseTex;
        float _centerX;
        float _centerY;
        float _Radius;
        float _SmoothSlider;
        float _TimeFactor;
        float _RandSlider;
        float _ScaleX;
        float _ScaleY;
        float _OffsetX;
        float _OffsetY;


        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MossBump;
            float2 uv_NoiseTex;
        };

        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutput o)
        {

            float posX = IN.uv_MainTex.x;
            float posY = IN.uv_MainTex.y;
            float2 center = (0, 0);
            //float dist = sqrt(pow(posX - _centerX, 2) + pow(posY - _centerY, 2)); 
            float dist = sqrt(pow(posX - 0.5, 2) + pow(posY - 0.5, 2));
            float2 offset2 = float2(_OffsetX, _OffsetY);

            // Albedo comes from a texture tinted by color    
            float noise =  tex2D (_NoiseTex, IN.uv_NoiseTex + offset2).r;
            _Radius -= noise * _NoiseSize;
            float2 offsets = float2(_ScaleX, _ScaleY);


            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex * offsets) * _Color;
            o.Albedo = c.rgb;
            o.Normal = UnpackNormal(tex2D (_MossBump, IN.uv_MossBump));
            o.Normal *= float3(_BumpScale, _BumpScale, 1);
            float smooth = min(_SmoothSlider, _Radius);

            float inRadius = smoothstep(_Radius - smooth, _Radius, dist);
            o.Alpha = noise > _Time.r * _TimeFactor ? 0 : 1;
            o.Alpha = dist > _Radius ? 0 : o.Alpha;


            //o.Alpha = dist < _Radius ? 1 : lerp(1, 0, inRadius);
            o.Alpha *= pow(noise, 1/2) + _RandSlider;
            

        }
        ENDCG
    }
    FallBack "Diffuse"
}
