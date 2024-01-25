using UnityEngine;

public static class UserInterfaceDomain {

    public static void PreTick(GameContext ctx, float dt) {

        InputEntity input = ctx.inputEntity;

        // Tower
        if (input.isMouseLeftDown) {
            int towerLen = ctx.towerRepository.TakeAll(out TowerEntity[] towers);
            for (int i = 0; i < towerLen; i++) {
                TowerEntity tower = towers[i];
                if (PFPhysics.IsPointInsideRectangle(input.mouseWorldPos, tower.transform.position, tower.shapeSize)) {

                    UIApp.P_BuildManifest_Close(ctx.uiContext);

                    // 打开建造面板: 添加可建造的按钮
                    bool has = ctx.templateContext.towers.TryGetValue(tower.typeID, out TowerTM tm);
                    Debug.Assert(has);

                    if (tm.allowBuildTowerTypeIDs != null && tm.allowBuildTowerTypeIDs.Length > 0) {
                        UIApp.P_BuildManifest_Open(ctx.uiContext, input.mouseWorldPos);
                        for (int j = 0; j < tm.allowBuildTowerTypeIDs.Length; j++) {
                            // 可建造的 TypeID
                            int allowBuildTowerTypeID = tm.allowBuildTowerTypeIDs[j];
                            UIApp.P_BuildManifest_AddOption(ctx.uiContext, tower.id, allowBuildTowerTypeID);
                        }
                    }
                    
                    input.isMouseLeftDown = false;

                    break;
                }
            }
        }

    }

}