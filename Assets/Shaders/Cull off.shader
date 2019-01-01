// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Cull off" 
{
	Properties
	{
		_Color("Main Color", Color) = (1,1,1,1)//Tint Color  
		_MainTex("Base (RGB)", 2D) = "white" {}
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		LOD 100

		Pass
		{
			Cull Off
			//Lighting Off
			SetTexture[_MainTex]{ combine texture }
			SetTexture[_MainTex]
			{
				ConstantColor[_Color]
				Combine Previous * Constant
			}
		}
	}
}
