using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class ArScreenRenderTextureSetter : MonoBehaviour
{
    public VolumeProfile screenAdderVolumeProfile;
    public Camera arCamera;
    private Vector2Int _resolution;
    private int resolutionDivisor = 4;
    void Start()
    {
        _resolution = new Vector2Int(Screen.width, Screen.height);
        SetRenderTexture();
    }

    RenderTexture CreateRenderTexture(int x, int y)
    {
        RenderTexture rt = new RenderTexture(x, y, 0);
        
        rt.dimension = TextureDimension.Tex2D;
        rt.antiAliasing = 1;
        rt.format = RenderTextureFormat.ARGBHalf;
        //rt.graphicsFormat = GraphicsFormat.R8G8B8A8_UNorm;
        rt.graphicsFormat = GraphicsFormat.R16G16B16A16_SFloat;
        rt.depth = 0;
        rt.useMipMap = false;
        rt.useDynamicScale = false;
        rt.wrapMode = TextureWrapMode.Clamp;
        rt.filterMode = FilterMode.Point;
        rt.anisoLevel = 0;

        return rt;
    }

    void SetRenderTexture()
    {
        RenderTexture rt = CreateRenderTexture(Screen.width/resolutionDivisor, Screen.height/resolutionDivisor);
        arCamera.targetTexture = rt;
        ScreenAdderVolume.SetTextureToAdd(rt);
    }

    void Update()
    {
        if (_resolution.x != Screen.width || _resolution.y != Screen.height)
        {
            _resolution.x = Screen.width;
            _resolution.y = Screen.height;

            SetRenderTexture();
        }
    }
}
