Shader "Custom/Bricks"
{
    Properties
    {
        //parameters for the brick texture
        _Color ("Color", Color) = (1,1,1,1)
        _BrickTex ("Brick Texture", 2D) = "white" {}
        _MainTex ("Original Texture", 2D) = "white"{}
        _BumpTex ("Normal Map", 2D) = "bump" {}
        _AgeSlider ("Aging Slider", Range(0, 1)) = 0.1
        _mySlider ("Bump Amount", Range(0, 10)) = 1
        _Radius ("Radius", Range(0, 1)) = 0.5

        //parameters for the plaster texture
        _AgedTex("Aging Texture", 2D) = "white" {}
        _NoiseSize ("Noise", Range(0,1)) = 0.1
        _NoiseTex ("Noise Texture", 2D) = "white" {}
        _centerY ("Center Y", Range(0, 1)) = 0
        _centerX ("Center X", Range(0, 1)) = 0
        _BumpTexMoss ("Normal Noise Map", 2D) = "bump" {}

        //Scale properties 
        _ScaleX ("Scale X", Range(0.1, 10)) = 1
        _ScaleY ("Scale Y", Range(0.1, 10)) = 1
        _OffsetX ("Offset X", Range(0, 1)) = 0.0
        _OffsetY ("Offset Y", Range(0, 1)) = 0.0

        //Spread Limot
        _SpreadLim ("Spread Max", Range(0.0, 1.0)) = 0.5

		_Color2("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BrickTex;
        float _AgeSlider;
        sampler2D _BumpTex;
        float _mySlider;
        float _Radius;
        float _SmoothSlider;
        float _NoiseSize;
        sampler2D _NoiseTex;
        float _centerX;
        float _centerY;
        sampler2D _BumpTexMoss;
        sampler2D _AgedTex;
        float _ScaleX;
        float _ScaleY;
        float _SpreadLim;
        float _OffsetX;
        float _OffsetY;
		fixed4 _Color2;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BrickTex;
            float2 uv_BumpTex;
            float2 uv_NoiseTex;
            float2 uv_BumpTexMoss;
            float2 uv_AgedTex;
        };

        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutput o)
        {
            float posX = IN.uv_MainTex.x;
            float posY = IN.uv_MainTex.y;
            float2 center = (0, 0);
            float dist = sqrt(pow(posX - _centerX, 2) + pow(posY - _centerY, 2));
            fixed4 noise =  tex2D (_NoiseTex, IN.uv_NoiseTex).r;
            _Radius = min(_Radius + _Time.x, _SpreadLim);

            _Radius -= noise * _NoiseSize;
            float2 offsets = float2(_ScaleX, _ScaleY);
            float2 offset2 = float2(_OffsetX, _OffsetY);

            // Albedo comes from a texture tinted by color    
            fixed4 brickTex = tex2D (_BrickTex, IN.uv_BrickTex * offsets);
            fixed4 wallTex = tex2D (_MainTex, IN.uv_MainTex * offsets) * _Color;
            fixed4 agedTex = tex2D (_AgedTex, IN.uv_AgedTex + offset2);
            o.Albedo = brickTex.rgb;

            float ageTime = min(_AgeSlider + _Time.r, 1.2);
            
			o.Albedo = dist > _Radius ? wallTex.rgb * (1 - ageTime) + ageTime * agedTex.rgb : (brickTex.g > max(lerp(0.5, 0.24, _Time.r * 0.5), 0.23) ? noise.rgb * _Color2: brickTex.rgb);
            //o.Albedo +=  _AgeSlider * agedTex.rgb ;

            o.Normal = UnpackNormal(tex2D (_BumpTex, IN.uv_BumpTex * offsets));
            o.Normal = dist > _Radius ?  UnpackNormal(tex2D (_BumpTexMoss, IN.uv_BumpTexMoss)) : o.Normal;
            o.Normal *= float3(_mySlider, _mySlider, 1);

        }
        ENDCG
    }
    FallBack "Diffuse"
}
