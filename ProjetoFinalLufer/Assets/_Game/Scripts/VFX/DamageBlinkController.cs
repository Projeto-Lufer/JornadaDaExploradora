using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBlinkController : MonoBehaviour
{
    [SerializeField] private Transform modelToBlink;
    [SerializeField] private Material[] damageBlinkMaterials;
    [SerializeField] private float blinkDuration;

    private SkinnedMeshRendererToMaterial[] originalMaterials;
    private Coroutine damageBlinkCoroutine;
    private WaitForSeconds blinkDurationWFS;

    void Start()
    {
        blinkDurationWFS = new WaitForSeconds(blinkDuration);
        SkinnedMeshRenderer[] renderers = modelToBlink.GetComponentsInChildren<SkinnedMeshRenderer>();
        originalMaterials = new SkinnedMeshRendererToMaterial[renderers.Length];

        for (int i = 0 ; i < renderers.Length ; i++)
        {
            originalMaterials[i].renderer = renderers[i];
            originalMaterials[i].materials = new Material[renderers[i].materials.Length];

            for (int j = 0; j < renderers[i].materials.Length; j++)
            {
                originalMaterials[i].materials[j] = renderers[i].materials[j];
            }
        }
    }

    public void PlayBlinkingAnimation()
    {
        if (damageBlinkCoroutine != null)
        {
            StopCoroutine(damageBlinkCoroutine);
        }

        damageBlinkCoroutine = StartCoroutine(DamageBlinkCoroutine());
    }

    public void ResetToNormalMaterials()
    {
        if (damageBlinkCoroutine != null)
        {
            StopCoroutine(damageBlinkCoroutine);
            damageBlinkCoroutine = null;
        }

        for (int i = 0; i < originalMaterials.Length; i++)
        {
            Material[] objectMaterials = originalMaterials[i].renderer.materials;
            int materialsInObj = originalMaterials[i].renderer.materials.Length;
            for (int j = 0; j < materialsInObj; j++)
            {
                objectMaterials[j] = originalMaterials[i].materials[j];
            }

            originalMaterials[i].renderer.materials = objectMaterials;
        }
    }

    private IEnumerator DamageBlinkCoroutine()
    {
        for (int i = 0 ; i < originalMaterials.Length ; i++) // Objects with texture
        {
            Material[] objectMaterials = originalMaterials[i].renderer.materials;
            int materialsInObj = objectMaterials.Length;
            for (int j = 0; j < materialsInObj; j++) // Materials in the object
            {
                foreach (var damageMat in damageBlinkMaterials) // All damage materials
                {
                    if (damageMat.mainTexture == originalMaterials[i].materials[j].mainTexture)
                    {
                        objectMaterials[j] = damageMat;
                    }
                }
            }
            originalMaterials[i].renderer.materials = objectMaterials;
        }

        yield return blinkDurationWFS;

        ResetToNormalMaterials();
    }
}

public struct SkinnedMeshRendererToMaterial
{
    public SkinnedMeshRenderer renderer;
    public Material[] materials;
}