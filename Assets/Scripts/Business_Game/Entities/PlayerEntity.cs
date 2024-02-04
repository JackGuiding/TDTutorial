public class PlayerEntity {

    public SkillSubEntity skill; // 当鼠标按下右键时, 施放技能

    public int hp;
    public int hpMax;

    public PlayerEntity() {

        skill = new SkillSubEntity();
        skill.id = 1;
        skill.typeID = 100;
        skill.typeName = "上帝之爪";

        skill.cd = 2;
        skill.cdMax = 2;

        skill.type = SkillCastDirectionType.Static;
        skill.staticDir = UnityEngine.Vector2.up;

        skill.castRadius = 10;

        skill.preMaintain = 0.5f;

        skill.activeMaintain = 0.1f;

        skill.postMaintain = 0.1f;

        skill.hasSpawnBullet = true;
        skill.spawnBulletTypeID = 100;

    }

}