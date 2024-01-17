using System;
using System.Collections.Generic;

public class FlagRepository {

    Dictionary<int, FlagEntity> all;

    FlagEntity[] tempArray;

    public FlagRepository() {
        all = new Dictionary<int, FlagEntity>();
        tempArray = new FlagEntity[10];
    }

    public void Add(FlagEntity entity) {
        all.Add(entity.id, entity);
    }

    public FlagEntity Find(Predicate<FlagEntity> predicate) {
        foreach (FlagEntity flag in all.Values) {
            bool isMatch = predicate(flag);
            if (isMatch) {
                return flag;
            }
        }
        return null;
    }

    public int TakeAll(out FlagEntity[] array) {
        all.Values.CopyTo(tempArray, 0);
        array = tempArray;
        return all.Count;
    }

}