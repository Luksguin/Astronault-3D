using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Collectable
{
    public class CollectableUIBase : MonoBehaviour
    {
        public Image icon;
        public TextMeshProUGUI iconCount;

        private CollectableSetup _currSetup;

        public void Load(CollectableSetup setup)
        {
            _currSetup = setup;
            UpdateImage();
        }

        public void UpdateImage()
        {
            icon.sprite = _currSetup.iconImage;
        }

        private void Update()
        {
            iconCount.text = _currSetup.soInt.value.ToString();
        }
    }
}
