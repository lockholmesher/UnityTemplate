using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.Controller;
public class PopUpScrollView : BasePopUp
{
    [SerializeField]
    Transform content;
    
    public T AddObject<T>(T _object) where T : MonoBehaviour
    {
        _object.transform.SetParent(content);
        Vector3 oriPos = _object.transform.localPosition;
        _object.transform.localPosition = new Vector3
        (
            oriPos.x,
            oriPos.y,
            0
        );
        _object.transform.localScale = Vector3.one;
        return _object;

    }
    
}
