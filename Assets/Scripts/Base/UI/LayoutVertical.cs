using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.Controller;
namespace LTAUnityBase.Base.UI
{
    [DisallowMultipleComponent]
    public class LayoutVertical : MonoBehaviour
    {
        public float space = 35;

        public float top;

        public float sizey = 0;
        // Start is called before the first frame update
        public virtual void AddGameObject(Transform Gobject, float sizey)
        {
            Gobject.SetParent(this.transform);
            Gobject.localPosition = new Vector3(
                0,
                -top - this.sizey - space,
                0
                );
            Gobject.localScale = Vector3.one;
            this.sizey += sizey + space;
        }
    }
}
