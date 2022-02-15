Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        MyRange ("Range", Range(1, 500)) = 1
    }
    SubShader
    {
        Pass
        {
            //blend dstcolor zero
            //ZWrite off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag


            #include "UnityCG.cginc"
            

            fixed4 _Color;
            float MyRange;
            struct appdata //meshdata, v stuff
            {
                float4 vertex : POSITION;
                float4 normal : NORMAL;
                float4 coords : TEXCOORD1;
            };

            struct v2f //o stuff
            {
                float4 V2fvertex : SV_POSITION; // clip space position
                float4 v2fnormal : TEXCOORD1;
                float4 v2fsomething : TEXCOORD2;
            };



            v2f vert (appdata v) 
            {
                v2f o;
                o.V2fvertex = UnityObjectToClipPos(v.vertex); // local to clip space
                o.v2fnormal = v.normal;
                o.v2fsomething = v.coords * MyRange;
                return o; //returns a v2f
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float4 clobnob = i.v2fsomething;
                return clobnob.xyxx;
                
            }
            ENDCG
        }
    }
}
