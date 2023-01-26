using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectable
{
    public class CollectableUIManager : MonoBehaviour
    {
        public CollectableUIBase collectableContainer;
        public Transform container;

        private void Start()
        {
            CreateIcon();
        }

        public void CreateIcon()
        {
            foreach (var setup in CollectableManager.instance.collectableSetups)
            {
                var item = Instantiate(collectableContainer, container);
                item.Load(setup);
            }
        }
    }
}
