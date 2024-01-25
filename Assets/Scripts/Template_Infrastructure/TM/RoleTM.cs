using System;
using UnityEngine;

// Scriptable Object(SO)
// 只存纯数据
// 不需要渲染, 不需要物理, 不需逻辑

// 配置
// 程序与策划配合使用
// 这份表更多是由策划使用
[CreateAssetMenu(fileName = "TM_Role_", menuName = "TD/TM_Role")]
public class RoleTM : ScriptableObject {

    public int typeID;

    public float moveSpeed;

    public Sprite spr; // 图片

}