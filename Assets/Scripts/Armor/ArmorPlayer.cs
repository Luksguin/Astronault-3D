using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPlayer : MonoBehaviour
{
    public List<SkinnedMeshRenderer> meshRenderers;
    public Texture texture;
    public string textureId;

    [NaughtyAttributes.Button]
    public void ChangeArmor()
    {
        meshRenderers.ForEach(i => i.materials[0].SetTexture(textureId, texture));
    }
}
