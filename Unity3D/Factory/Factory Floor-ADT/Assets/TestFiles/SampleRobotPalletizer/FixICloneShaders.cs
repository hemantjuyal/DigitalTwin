using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixIcloneShaders : MonoBehaviour
{
    public List<SkinnedMeshRenderer> ShadersToSkip;

    private void Start()
    {
        List<SkinnedMeshRenderer> allRenderers = new List<SkinnedMeshRenderer>(gameObject.GetComponentsInChildren<SkinnedMeshRenderer>());

        foreach (SkinnedMeshRenderer smr in allRenderers)
        {
            if (!ShadersToSkip.Contains(smr))
            {
                foreach (Material m in smr.materials)
                {
                    FixMaterial(m);
                }
            }
        }
    }

    private void FixMaterial(Material m)
    {
        m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        m.SetInt("_ZWrite", 1);
        m.DisableKeyword("_ALPHATEST_ON");
        m.DisableKeyword("_ALPHABLEND_ON");
        m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        m.renderQueue = -1;
    }
}
