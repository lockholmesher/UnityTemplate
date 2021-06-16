using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LTAUnityBase.Base.Controller;
namespace LTAUnityBase.Base.UI
{
    [DisallowMultipleComponent]
    public class LayoutHorizontal : MonoBehaviour
    {
        public float space = 35;

        public float left;

        public float sizex = 0;
        // Start is called before the first frame update
        public virtual void AddGameObject(Transform Gobject,Vector2 size)
        {
                    Gobject.SetParent(this.transform);
                    Gobject.localPosition = new Vector3(
                        left + this.sizex + space,
                        size.y / 2,
                        0
                        );
                    Gobject.localScale = Vector3.one;
                    this.sizex += size.x + space;
        }
    }
}

