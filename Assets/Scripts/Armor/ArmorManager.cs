using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

namespace Armor
{
    public enum ArmorType
    {
        SPEED,
        RESISTANCE,
        COSMESTIC
    }

    public class ArmorManager : Singleton<ArmorManager>
    {
        public List<ArmorSetup> armorSetups;

        public ArmorSetup GetByType(ArmorType type)
        {
            return armorSetups.Find(i => i.armorType == type);
        }
    }

    [System.Serializable]
    public class ArmorSetup
    {
        public ArmorType armorType;
        public Texture texture;
    }
}