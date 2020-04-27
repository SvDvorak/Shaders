using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
[RequireComponent (typeof (Camera))]
public class DownSampling : ImageEffectBase
{
    public int Amount;

    [ImageEffectOpaque]
    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetInt("_DownSampling", Amount);
        Graphics.Blit(source, destination, material);
    }
}