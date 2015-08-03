using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof (Camera))]
public class DownScaling : MonoBehaviour
{
    public Shader shader;

    [Range(1, 15)]
    public int Amount;

    private Material _material;

    public void Start()
    {
        // Disable if we don't support image effects
        if (!SystemInfo.supportsImageEffects)
        {
            enabled = false;
            return;
        }

        // Disable the image effect if the shader can't
        // run on the users graphics card
        if (!shader || !shader.isSupported)
            enabled = false;
    }

    [ImageEffectOpaque]
    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetInt("_DownScaling", Amount);
        Graphics.Blit(source, destination, _material);
    }

    private Material material
    {
        get
        {
            if (_material == null)
            {
                _material = new Material(shader);
                _material.hideFlags = HideFlags.HideAndDontSave;
            }
            return _material;
        }
    }

    private void OnDisable()
    {
        if (_material)
        {
            DestroyImmediate(_material);
        }
    }
}