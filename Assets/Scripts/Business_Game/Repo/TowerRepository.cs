using System;
using System.Linq;
using System.Collections.Generic;

public class TowerRepository {

    Dictionary<int, TowerEntity> all;

    TowerEntity[] tempArray;

    public TowerRepository() {
        all = new Dictionary<int, TowerEntity>();
        tempArray = new TowerEntity[1000];
    }

    public void Add(TowerEntity entity) {
        all.Add(entity.id, entity);
        UnityEngine.Debug.Log("TowerRepository.Add: " + entity.id);
    }

    public bool TryGet(int entityID, out TowerEntity entity) {
        return all.TryGetValue(entityID, out entity);
    }

    public void Remove(TowerEntity tower) {
        all.Remove(tower.id);
    }

    public int TakeAll(out TowerEntity[] array) {
        all.Values.CopyTo(tempArray, 0);
        array = tempArray;
        return all.Count;
    }

}