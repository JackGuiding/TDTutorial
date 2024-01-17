using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Login : MonoBehaviour {

    [SerializeField] Button startBtn; // class null

    public Action OnStartClickHandle;

    public void Ctor() {
        
        // 如果绑定了 startBtn 就不用 new 了
        // startBtn.onClick.AddListener(OnStartClick);

        // 匿名函数
        startBtn.onClick.AddListener(() => {
            // OnStartClickHandle();
            OnStartClickHandle.Invoke();
        });

    }

    public void Show() {
        gameObject.SetActive(true); // 显示
    }

    public void Close() {
        gameObject.SetActive(false); // 隐藏
    }

    void OnStartClick() {
        Debug.Log("Yo1111;");
    }

}