using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Collectable;
using Armor;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private SaveSetup _saveSetup;
    private string _path;

    public int _myLastLevel;

    public Action<SaveSetup> FileLoaded;

    public SaveSetup Setup
    {
        get { return _saveSetup; }
    }

    protected override void Awake()
    {
        base.Awake();

        _path = Application.dataPath + "/Save.txt";

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Invoke(nameof(ReadFile), .1f);
    }

    [NaughtyAttributes.Button]
    public void Save()
    {        
        string setupToJson = JsonUtility.ToJson(_saveSetup, true);

        WriteFile(setupToJson);
        Debug.Log(setupToJson);
    }

    public void WriteFile(string json)
    {
        File.WriteAllText(_path, json);
    }

    public void ReadFile()
    {
        string loadedFile = "";

        if (File.Exists(_path))
        {
            loadedFile = File.ReadAllText(_path);
            _saveSetup = JsonUtility.FromJson<SaveSetup>(loadedFile);
            _myLastLevel = _saveSetup.lastLevel;
        }
        else
        {
            CreateFile();
            Save();
        }

        FileLoaded?.Invoke(_saveSetup);
    }

    public void CreateFile()
    {
        _saveSetup = new SaveSetup();
        _saveSetup.lifePlayer = 10;
        _saveSetup.lastLevel = 0;
        _saveSetup.coins = 0;
        _saveSetup.medKits = 0;
        _saveSetup.armorSetup = ArmorManager.instance.GetByType(ArmorType.DEFAULT);
    }

    public void SaveLastLevel(int level)
    {
        _saveSetup.lastLevel = level;
        WriteCollectables();
        WriteLife();
        WriteArmor();
        Save();
    }

    public void WriteCollectables()
    {
        _saveSetup.coins = CollectableManager.instance.GetType(CollectableType.COIN).soInt.value;
        _saveSetup.medKits = CollectableManager.instance.GetType(CollectableType.MEDKIT).soInt.value;
    }

    public void WriteLife()
    {
        _saveSetup.lifePlayer = LifePlayerController.instance.lifePlayer;
    }

    public void WriteArmor()
    {
        _saveSetup.armorSetup = ArmorManager.instance.GetByType(ArmorBase.lastType);
    }
}

[Serializable]
public class SaveSetup
{
    public float lifePlayer;
    public int lastLevel;
    public int coins;
    public int medKits;
    public ArmorSetup armorSetup;
}