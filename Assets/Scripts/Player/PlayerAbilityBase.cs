using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityBase : MonoBehaviour
{
    protected Player player;

    private void OnValidate()
    {
        if (player == null) player = GetComponent<Player>();
    }

    private void Start()
    {
        OnValidate();
    }

    private void OnDestroy()
    {
        Remove();
    }

    protected void Init() { }
    protected void Register() { }
    protected void Remove() { }
}
