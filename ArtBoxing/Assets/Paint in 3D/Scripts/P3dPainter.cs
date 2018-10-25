﻿using UnityEngine;

namespace PaintIn3D
{
	public static partial class P3dPainter
	{
		private static Material BuildMaterial(string shaderName)
		{
			var shader = P3dShader.Load(shaderName);

			return P3dShader.Build(shader);
		}

		private static Material[] BuildMaterialsBlendModes(string shaderName)
		{
			var shader    = P3dShader.Load(shaderName);
			var materials = new Material[P3dShader.BLEND_MODE_COUNT];
			
			for (var blend = 0; blend < P3dShader.BLEND_MODE_COUNT; blend++)
			{
				materials[blend] = P3dShader.Build(shader, 0, (P3dBlendMode)blend);
			}

			return materials;
		}

		private static bool[] BuildSwapBlendModes()
		{
			var swaps = new bool[P3dShader.BLEND_MODE_COUNT];

			swaps[(int)P3dBlendMode.AlphaBlendAdvanced] = true;
			swaps[(int)P3dBlendMode.Replace           ] = true;
			//swaps[(int)P3dBlendMode.Multiply          ] = true;

			return swaps;
		}

		private static void SetChannel(Material material, P3dChannel channel)
		{
			switch (channel)
			{
				case P3dChannel.UV:
				{
					material.SetVector(P3dShader._Channel, new Vector4(1.0f, 0.0f, 0.0f, 0.0f));
				}
				break;

				case P3dChannel.UV2:
				{
					material.SetVector(P3dShader._Channel, new Vector4(0.0f, 1.0f, 0.0f, 0.0f));
				}
				break;

				case P3dChannel.UV3:
				{
					material.SetVector(P3dShader._Channel, new Vector4(0.0f, 0.0f, 1.0f, 0.0f));
				}
				break;

				case P3dChannel.UV4:
				{
					material.SetVector(P3dShader._Channel, new Vector4(0.0f, 0.0f, 0.0f, 1.0f));
				}
				break;
			}
		}
	}
}