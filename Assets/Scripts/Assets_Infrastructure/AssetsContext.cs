using System.Collections.Generic;
using UnityEngine;

// 绑定
public class AssetsContext {

    public Dictionary<string, GameObject> panels;
    public Dictionary<string, GameObject> entities;

    public AssetsContext() {
        entities = new Dictionary<string, GameObject>();
        panels = new Dictionary<string, GameObject>();
    }

    public bool Panel_TryGetPrefab(string name, out GameObject prefab) {
        // null // 那哦  不是  努哦
        // null.xxx 就会 NullReferenceException
        return panels.TryGetValue(name, out prefab);
    }

    public bool Entity_TryGetPrefab(string name, out GameObject prefab) {
        return entities.TryGetValue(name, out prefab);
    }

}