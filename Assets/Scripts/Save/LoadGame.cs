using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collectable;

public class LoadGame : MonoBehaviour
{
    public void Load()
    {
        CollectableManager.instance.ReadCollectables();
        HealthBase.instance.ReadLife();
    }
}
