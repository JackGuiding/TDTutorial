using UnityEngine;

// 技能
public class SkillSubEntity {

    public int id;
    public int typeID;
    public string typeName;

    public float cd;
    public float cdMax;

    public float mpCost; // 耗蓝

    // ==== 施放方向 ====
    // 向哪里放? 角色的面向, 鼠标选中, 键盘, 固定, 不需
    public SkillCastDirectionType type;
    public Vector2 staticDir;

    // 可施放距离
    public float castRadius;

    // ==== 技能阶段 ====
    public SkillStage stage;

    public float preMaintain;
    public float preMaintainTimer;

    public float activeMaintain;
    public float activeMaintainTimer;
    public float activeInterval;
    public float activeIntervalTimer;

    public float postMaintain;
    public float postMaintainTimer;

    // ==== 技能生效(生什么效?) ====
    // public bool hasAttachBuffToCaster; // 是否附加Buff给施法者
    // public int attachBuffTypeID; // 附加的Buff类型ID

    // public bool hasAttachBuffToTarget; // 是否附加Buff给目标
    // public int attachBuffToTargetTypeID; // 附加的Buff类型ID

    public bool hasSpawnBullet; // 是否生成子弹
    public int spawnBulletTypeID; // 子弹TypeID

}