using System;
using UnityEngine.Rendering;

namespace UnityEngine.Experimental.Rendering.HDPipeline
{
    public partial class Decal
    {
        // Main structure that store the user data (i.e user input of master node in material graph)
        [GenerateHLSL(PackingRules.Exact, false)]
        public struct DecalSurfaceData
        {
            [SurfaceDataAttributes("Base Color", false, true)]
            public Vector4 baseColor;
            [SurfaceDataAttributes("Normal", true)]
            public Vector4 normalWS;
            [SurfaceDataAttributes("Mask", true)]            
            public Vector4 mask; // Metal, AmbientOcclusion, Smoothness, smoothness opacity
            [SurfaceDataAttributes("Emissive")]
            public Vector3 emissive;
            [SurfaceDataAttributes("AOSBlend", true)]
            public Vector2 MAOSBlend; // Metal opacity and Ambient occlusion opacity
            [SurfaceDataAttributes("HTileMask")]
            public uint HTileMask;

        };

        [GenerateHLSL(PackingRules.Exact)]
        public enum DBufferMaterial
        {           
            Count = 4
        };

        [GenerateHLSL(PackingRules.Exact)]
        public enum DBufferHTileBit
        {
            Diffuse = 1,
            Normal = 2,
            Mask = 4
        };

        //-----------------------------------------------------------------------------
        // DBuffer management
        //-----------------------------------------------------------------------------

        // should this be combined into common class shared with Lit.cs???
        static public int GetMaterialDBufferCount() { return (int)DBufferMaterial.Count; }

        static GraphicsFormat[] m_RTFormat = { GraphicsFormat.R8G8B8A8_SRGB, GraphicsFormat.R8G8B8A8_UNorm, GraphicsFormat.R8G8B8A8_UNorm, GraphicsFormat.R8G8_UNorm};

        static public void GetMaterialDBufferDescription(out GraphicsFormat[] RTFormat)
        {
            RTFormat = m_RTFormat;
        }

        // relies on the order shader passes are declared in decal.shader
        [Flags]
        public enum MaskBlendFlags
        {
            Metal = 1 << 0,
            AO = 1 << 1,
            Smoothness = 1 << 2,
        }

    }

    // normal to world only uses 3x3 for actual matrix so some data is packed in the unused space
    // blend:
    // float decalBlend = decalData.normalToWorld[0][3];
    // albedo contribution on/off:
    // float albedoContribution = decalData.normalToWorld[1][3];
    // tiling:
    // float2 uvScale = float2(decalData.normalToWorld[3][0], decalData.normalToWorld[3][1]);
    // float2 uvBias = float2(decalData.normalToWorld[3][2], decalData.normalToWorld[3][3]);
    [GenerateHLSL(PackingRules.Exact, false)]
    public struct DecalData
    {
        public Matrix4x4 worldToDecal;
        public Matrix4x4 normalToWorld;
        public Vector4 diffuseScaleBias;
        public Vector4 normalScaleBias;
        public Vector4 maskScaleBias;
        public Vector4 baseColor;
        public Vector4 remappingAOS;
        public Vector4 scalingMAB; // metalness, alpha basemap, blue mask map
        public Vector3 blendParams; // x normal blend source, y mask blend source, z mask blend mode
    };
}
