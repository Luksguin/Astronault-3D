using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class CheckPointManager : Singleton<CheckPointManager>
{
    public List<CheckPointBase> checkPoints;

    private int _lastCheckPointKey = 0;

    public bool HasCheckPoint()
    {
        return _lastCheckPointKey > 0;
    }

    public void CheckCheckPoint(int i)
    {
        if(i > _lastCheckPointKey)
        {
            _lastCheckPointKey = i;
        }
    }

    public Vector3 GetPosition()
    {
        var checkPoint = checkPoints.Find(i => i.key == _lastCheckPointKey);
        return checkPoint.transform.position;
    }
}
