using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Armor
{
    public class ArmorPlayer : MonoBehaviour
    {
        public List<SkinnedMeshRenderer> meshRenderers;
        public Texture texture;
        public string textureId;

        private Texture _defaultTexture;

        private void Awake()
        {
            _defaultTexture = meshRenderers[0].materials[0].GetTexture(textureId);
        }

        public void ChangeArmor(ArmorSetup setup)
        {
            meshRenderers.ForEach(i => i.materials[0].SetTexture(textureId, setup.texture));
        }

        public void ResetArmor()
        {
            meshRenderers.ForEach(i => i.materials[0].SetTexture(textureId, _defaultTexture));
        }
    }
}
