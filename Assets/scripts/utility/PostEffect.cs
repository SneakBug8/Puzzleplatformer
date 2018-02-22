using UnityEngine;

[ExecuteInEditMode]
public class PostEffect : MonoBehaviour
{
    public Material ShaderMaterial;

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, ShaderMaterial);
    }
}