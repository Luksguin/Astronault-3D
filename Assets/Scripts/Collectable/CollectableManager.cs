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
            Reset();
        }

        private void Reset()
        {
            foreach(var i in collectableSetups)
            {
                i.soInt.value = 0;
            }
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

        #region DEBUG
        //[NaughtyAttributes.Button]
        //public void AddCoin()
        //{
        //    AddByType(ItenType.COIN);
        //}

        //[NaughtyAttributes.Button]
        //public void RemoveCoin()
        //{
        //    RemoveByType(ItenType.COIN);
        //}

        //[NaughtyAttributes.Button]
        //public void AddMedkit()
        //{
        //    AddByType(ItenType.MEDKIT);
        //}

        //[NaughtyAttributes.Button]
        //public void RemoveMedkit()
        //{
        //    RemoveByType(ItenType.MEDKIT);
        //}
    }
    #endregion

    [System.Serializable]
    public class CollectableSetup
    {
        public CollectableType collectableType;
        public SOInt soInt;
        public Sprite iconImage;
    }
}
