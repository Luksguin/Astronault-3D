using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ebac.Core.Singleton;

namespace Collectable
{
    public enum CollectableType
    {
        COIN,
        MEDKIT
    }

    public class CollectableManager : Singleton<CollectableManager>
    {
        public List<CollectableSetup> collectableSetups;

        private void Start()
        {
            ReadCollectables();
        }

        //private void Reset()
        //{
        //    foreach(var i in collectableSetups)
        //    {
        //        i.soInt.value = 0;
        //    }
        //}

        public void ReadCollectables()
        {
            AddByType(CollectableType.COIN, SaveManager.instance.Setup.coins);
            AddByType(CollectableType.MEDKIT, SaveManager.instance.Setup.medKits);
        }

        public CollectableSetup GetType(CollectableType type)
        {
            return collectableSetups.Find(i => i.collectableType == type);
        }

        public void AddByType(CollectableType type, int amount = 1)
        {
            collectableSetups.Find(i => i.collectableType == type).soInt.value += amount;
        }

        public void RemoveByType(CollectableType type, int amount = 1)
        {
            var iten = collectableSetups.Find(i => i.collectableType == type);
            iten.soInt.value -= amount;

            if (iten.soInt.value < 0) iten.soInt.value = 0;
        }
    }

    [System.Serializable]
    public class CollectableSetup
    {
        public CollectableType collectableType;
        public SOInt soInt;
        public Sprite iconImage;
    }
}
