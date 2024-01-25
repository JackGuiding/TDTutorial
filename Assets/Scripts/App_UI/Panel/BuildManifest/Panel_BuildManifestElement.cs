// 建造按钮
using UnityEngine;
using UnityEngine.UI;

public class Panel_BuildManifestElement : MonoBehaviour {

    [SerializeField] Button button;

    public int clickedTowerEntityID;
    public int clickedTowerTypeID;

    // 显示价格
    [SerializeField] Text priceTxt;
    // 显示图标
    [SerializeField] Image icon;

    public void Ctor(int clickedTowerEntityID, int clickedTowerTypeID, int price, Sprite icon) {

        this.clickedTowerEntityID = clickedTowerEntityID;
        this.clickedTowerTypeID = clickedTowerTypeID;

        this.priceTxt.text = price.ToString();
        this.icon.sprite = icon;

    }

}