using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectable
{
    public class CollectableCoin : CollectableBase
    {
        protected override void OnCollect()
        {
            base.OnCollect();
            //CollectableManager.instance.AddByType();
        }
    }
}
