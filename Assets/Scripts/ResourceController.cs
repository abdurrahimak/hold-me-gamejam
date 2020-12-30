using System.Collections.Generic;
using UnityEngine;

public class ResourceController
{
    private Dictionary<string, UnityEngine.Object> _resources;
    public int LastLevel;

    public ResourceController()
    {
        _resources = new Dictionary<string, Object>();
        LastLevel = Resources.LoadAll("Game/Levels").Length;
        var objects = Resources.LoadAll("Game");
        foreach (var o in objects)
        {
            _resources.Add(o.name, o);
        }
    }

    public UnityEngine.Object GetResource(string name)
    {
        return _resources[name];
    }
}
