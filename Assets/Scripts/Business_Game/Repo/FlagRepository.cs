using System;
using System.Collections.Generic;

public class FlagRepository {

    Dictionary<int, FlagEntity> all;

    public FlagRepository() {
        all = new Dictionary<int, FlagEntity>();
    }

    public void Add(FlagEntity entity) {
        all.Add(entity.id, entity);
        UnityEngine.Debug.Log("FlagRepository.Add: " + entity.id);
    }

}