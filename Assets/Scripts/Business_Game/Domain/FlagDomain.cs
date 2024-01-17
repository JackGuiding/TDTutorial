using UnityEngine;

public static class FlagDomain {

    public static FlagEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {
        // 生成
        FlagEntity prefab = ctx.assetsContext.flagEntity;
        FlagEntity entity = GameObject.Instantiate(prefab);
        entity.Ctor();
        entity.SetPos(pos);
        entity.id = ctx.flagID++;
        // 存储
        ctx.flagRepository.Add(entity);
        return entity;
    }
}