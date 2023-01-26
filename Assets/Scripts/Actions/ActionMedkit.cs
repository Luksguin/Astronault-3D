using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectable
{
    public class ActionMedkit : MonoBehaviour
    {
        public SOInt soInt;
        public CollectableType collectableType;
        public KeyCode medkitButton;

        public void Start()
        {
            soInt = CollectableManager.instance.GetType(collectableType).soInt;
        }

        public void RecoverLife()
        {
            if(soInt.value > 0)
            {
                CollectableManager.instance.RemoveByType(collectableType);
                Player.instance.healthBase.ResetLife();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(medkitButton))
            {
                RecoverLife();
            }
        }
    }
}
