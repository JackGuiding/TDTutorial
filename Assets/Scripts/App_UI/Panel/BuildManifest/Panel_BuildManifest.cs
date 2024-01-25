// 建造页
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_BuildManifest : MonoBehaviour {

    [SerializeField] Transform btnGroup;
    [SerializeField] Panel_BuildManifestElement elePrefab;
    List<Panel_BuildManifestElement> elements;

    public Action<int, int> OnBuildHandle;

    public void Ctor() {
        elements = new List<Panel_BuildManifestElement>();
    }

    public void Init(Vector3 worldPos) {
        SetWorldPos(worldPos);
        Show();
    }

    public void TearDown() {
        GameObject.Destroy(gameObject);
        for (int i = 0; i < elements.Count; i++) {
            GameObject.Destroy(elements[i].gameObject);
        }
    }

    public void AddOption(int clickedTowerEntityID, int clickedTowerTypeID, int price, Sprite icon) {
        Panel_BuildManifestElement ele = GameObject.Instantiate(elePrefab, btnGroup);
        ele.Ctor(clickedTowerEntityID, clickedTowerTypeID, price, icon);
        // 绑定
        ele.OnBuildHandle = ElementClick;
        elements.Add(ele);
    }

    void ElementClick(int clickedTowerEntityID, int clickedTowerTypeID) {
        OnBuildHandle.Invoke(clickedTowerEntityID, clickedTowerTypeID);
    }

    void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void Add() {

    }

    // 显示在哪个位置 WorldPos
    public void SetWorldPos(Vector3 worldPos) {
        transform.position = worldPos;
    }

}