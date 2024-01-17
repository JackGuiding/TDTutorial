using System;
using System.Linq;
using System.Collections.Generic;

public class RoleRepository {

    Dictionary<int, RoleEntity> all;

    RoleEntity[] tempArray;

    public RoleRepository() {
        all = new Dictionary<int, RoleEntity>();
        tempArray = new RoleEntity[1000];
    }

    public void Add(RoleEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(RoleEntity entity) {
        all.Remove(entity.id);
    }

    public int TakeAll(out RoleEntity[] array) {
        all.Values.CopyTo(tempArray, 0);
        array = tempArray;
        return all.Count;
    }

}