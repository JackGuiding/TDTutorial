using UnityEngine;

public static class FlagDomain {

    public static FlagEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {
        // 生成
        ctx.assetsContext.Entity_TryGetPrefab("Entity_Flag", out GameObject prefab);
        FlagEntity entity = GameObject.Instantiate(prefab).GetComponent<FlagEntity>();
        entity.Ctor();
        entity.SetPos(pos);
        entity.id = ctx.flagID++;
        // 存储
        ctx.flagRepository.Add(entity);
        return entity;
    }
}