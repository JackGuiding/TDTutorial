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
                    Debug.Log("Tower Clicked" + tower.name);

                    UIApp.P_BuildManifest_Close(ctx.uiContext);

                    // 打开建造面板: 添加可建造的按钮
                    UIApp.P_BuildManifest_Open(ctx.uiContext, input.mouseWorldPos);
                    UIApp.P_BuildManifest_AddOption(ctx.uiContext, tower.id, tower.typeID);
                    UIApp.P_BuildManifest_AddOption(ctx.uiContext, tower.id, tower.typeID);

                    input.isMouseLeftDown = false;

                    break;
                }
            }
        }

    }

}