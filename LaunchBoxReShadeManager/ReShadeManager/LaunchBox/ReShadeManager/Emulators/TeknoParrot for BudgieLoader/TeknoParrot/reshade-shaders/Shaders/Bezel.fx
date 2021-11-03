/*
	Original code by Marty McFly
	Concept by TrophiHunter 
*/

#include "ReShade.fxh"

texture HudTex	< string source = "Bezel.png"; > {Width = 1920; Height = 1080; Format = RGBA8;};
sampler	HudColor 	{ Texture = HudTex; };

float4 PS_Hud(float4 vpos : SV_Position, float2 texcoord : TEXCOORD) : SV_Target
{
	float4 hud = tex2D(HudColor, texcoord);
	return lerp(tex2D(ReShade::BackBuffer, texcoord),hud,hud.a);
}

technique Hud_Tech
{
	pass HudPass
	{
		VertexShader = PostProcessVS;
		PixelShader = PS_Hud;
	}
}