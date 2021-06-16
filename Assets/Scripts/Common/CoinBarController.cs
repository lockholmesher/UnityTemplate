using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.UI;
using LTAUnityBase.Base.DesignPattern;
[RequireComponent(typeof(TextMoney))]
[DisallowMultipleComponent]
public abstract class CoinBarController : MonoBehaviour
{
    TextMoney txtMoney;

    private void Awake()
    {
        txtMoney = GetComponent<TextMoney>();
        Observer.Instance.AddObserver(ObserverKey.UpdateUserInfo, UpdateCoin);
    }

    protected abstract float Coin
    {
        get;
    }

    void UpdateCoin(object data)
    {
        txtMoney.UpdateMoney(Coin);
    }


}
