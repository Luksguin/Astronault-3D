using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

namespace Collectable
{
    public enum ItenType
    {
        COIN,
        MEDKIT
    }

    public class CollectableManager : Singleton<CollectableManager>
    {
        public List<ItenSetup> itenSetups;

        private void Start()
        {
            Reset();
        }

        private void Reset()
        {
            foreach(var i in itenSetups)
            {
                i.soInt.value = 0;
            }
        }

        public void AddByType(ItenType type, int amount = 1)
        {
            itenSetups.Find(i => i.itenType == type).soInt.value += amount;
        }

        public void RemoveByType(ItenType type, int amount = 1)
        {
            var iten = itenSetups.Find(i => i.itenType == type);
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
    public class ItenSetup
    {
        public ItenType itenType;
        public SOInt soInt;
    }
}
