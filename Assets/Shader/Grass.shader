// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:0,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:6094,x:32920,y:32709,varname:node_6094,prsc:2|diff-585-OUT,spec-7378-OUT;n:type:ShaderForge.SFN_Lerp,id:4684,x:32556,y:32840,varname:node_4684,prsc:2|A-9820-RGB,B-4890-RGB,T-5986-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1775,x:32489,y:33090,ptovrint:False,ptlb:Intensity,ptin:_Intensity,varname:node_1775,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:5986,x:32532,y:33155,varname:node_5986,prsc:2|A-1775-OUT,B-5207-OUT;n:type:ShaderForge.SFN_Clamp01,id:5207,x:32325,y:33139,varname:node_5207,prsc:2|IN-1161-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1161,x:32163,y:33104,varname:node_1161,prsc:2|IN-578-Y,IMIN-443-OUT,IMAX-8907-OUT,OMIN-1272-OUT,OMAX-1757-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:578,x:31957,y:33104,varname:node_578,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:443,x:32042,y:33327,ptovrint:False,ptlb:node_443,ptin:_node_443,varname:node_443,prsc:2,glob:False,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:8907,x:32106,y:33391,ptovrint:False,ptlb:node_443_copy,ptin:_node_443_copy,varname:_node_443_copy,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:1272,x:32170,y:33455,ptovrint:False,ptlb:node_443_copy_copy,ptin:_node_443_copy_copy,varname:_node_443_copy_copy,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:1757,x:32234,y:33519,ptovrint:False,ptlb:node_443_copy_copy_copy,ptin:_node_443_copy_copy_copy,varname:_node_443_copy_copy_copy,prsc:2,glob:False,v1:0.5;n:type:ShaderForge.SFN_Color,id:4890,x:32114,y:32883,ptovrint:False,ptlb:node_4890,ptin:_node_4890,varname:node_4890,prsc:2,glob:False,c1:0.8455882,c2:0.4970618,c3:0.05595805,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:7378,x:32522,y:32741,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_7378,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:9820,x:32282,y:32725,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_9820,prsc:2,tex:579ec10f7c585ec49827ff2c20814196,ntxv:3,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:3371,x:32310,y:33061,ptovrint:False,ptlb:Fresnel exp,ptin:_Fresnelexp,varname:node_3371,prsc:2,glob:False,v1:2;n:type:ShaderForge.SFN_NormalVector,id:8093,x:32282,y:32905,prsc:2,pt:False;n:type:ShaderForge.SFN_Add,id:585,x:32746,y:32840,varname:node_585,prsc:2|A-5590-RGB,B-4684-OUT;n:type:ShaderForge.SFN_Color,id:5590,x:32673,y:32632,ptovrint:False,ptlb:node_5590,ptin:_node_5590,varname:node_5590,prsc:2,glob:False,c1:0.3930021,c2:0.4558824,c3:0,c4:1;proporder:1775-443-8907-1272-1757-4890-7378-9820-3371-5590;pass:END;sub:END;*/

Shader "Custom/Grass" {
    Properties {
        _Intensity ("Intensity", Float ) = 1
        _node_443 ("node_443", Float ) = 0.5
        _node_443_copy ("node_443_copy", Float ) = 1
        _node_443_copy_copy ("node_443_copy_copy", Float ) = 0
        _node_443_copy_copy_copy ("node_443_copy_copy_copy", Float ) = 0.5
        _node_4890 ("node_4890", Color) = (0.8455882,0.4970618,0.05595805,1)
        _Metallic ("Metallic", Float ) = 0
        _Texture ("Texture", 2D) = "bump" {}
        _Fresnelexp ("Fresnel exp", Float ) = 2
        _node_5590 ("node_5590", Color) = (0.3930021,0.4558824,0,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Intensity;
            uniform float _node_443;
            uniform float _node_443_copy;
            uniform float _node_443_copy_copy;
            uniform float _node_443_copy_copy_copy;
            uniform float4 _node_4890;
            uniform float _Metallic;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float4 _node_5590;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                UnityGI gi = UnityGlobalIllumination (d, 1, gloss, normalDirection);
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 diffuseColor = (_node_5590.rgb+lerp(_Texture_var.rgb,_node_4890.rgb,(_Intensity*saturate((_node_443_copy_copy + ( (i.posWorld.g - _node_443) * (_node_443_copy_copy_copy - _node_443_copy_copy) ) / (_node_443_copy - _node_443)))))); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Intensity;
            uniform float _node_443;
            uniform float _node_443_copy;
            uniform float _node_443_copy_copy;
            uniform float _node_443_copy_copy_copy;
            uniform float4 _node_4890;
            uniform float _Metallic;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float4 _node_5590;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 diffuseColor = (_node_5590.rgb+lerp(_Texture_var.rgb,_node_4890.rgb,(_Intensity*saturate((_node_443_copy_copy + ( (i.posWorld.g - _node_443) * (_node_443_copy_copy_copy - _node_443_copy_copy) ) / (_node_443_copy - _node_443)))))); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
