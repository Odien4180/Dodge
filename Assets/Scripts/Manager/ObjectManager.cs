using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : SingletonClass<ObjectManager>
{
    private Dictionary<string, GameObject> prefabDic;

    private void Start()
    {
        MakePrefabDictionary();
    }

    public Dictionary<string, GameObject> MakePrefabDictionary()
    {
        if (prefabDic == null)
        {
            prefabDic = new Dictionary<string, GameObject>();
        }

        prefabDic.Clear();

        foreach (GameObject go in Resources.LoadAll<GameObject>("Prefabs"))
        {
            prefabDic.Add(go.name, go);
        }

        return prefabDic;
    }
    public Dictionary<string, GameObject> GetPrefabDictionary()
    {
        return prefabDic;
    }

    public GameObject GetPrefab(string name)
    {
        if (prefabDic == null)
        {
            return MakePrefabDictionary()[name];
        }

        return prefabDic[name];
    }
}
