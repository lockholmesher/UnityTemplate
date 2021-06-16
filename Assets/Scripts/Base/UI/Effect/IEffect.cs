using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace LTAUnityBase.Base.UI.Effect
{
    public interface IEffect
    {
        void ShowEffect(Action endEffect = null);
        void HideEffect(Action endEffect = null);

        void Hide();
    }
}
