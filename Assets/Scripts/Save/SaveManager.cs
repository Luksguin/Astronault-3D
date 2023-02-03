using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Collectable;

public class SaveManager : Singleton<SaveManager>
{
    private SaveSetup _saveSetup;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 1;
    }

    [NaughtyAttributes.Button]
    public void Save()
    {        
        string setupToJson = JsonUtility.ToJson(_saveSetup, true);

        SaveFile(setupToJson);
        Debug.Log(setupToJson);
    }

    public void SaveFile(string json)
    {
        string path = Application.dataPath + "/Save.txt";

        File.WriteAllText(path, json);
    }

    public void SaveLastLevel(int level)
    {
        _saveSetup.lastLevel = level;
        SaveCollectables();
        Save();
    }

    public void SaveCollectables()
    {
        _saveSetup.coins = CollectableManager.instance.GetType(CollectableType.COIN).soInt.value;
        _saveSetup.medKits = CollectableManager.instance.GetType(CollectableType.MEDKIT).soInt.value;
    }
}

[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public int coins;
    public int medKits;
}