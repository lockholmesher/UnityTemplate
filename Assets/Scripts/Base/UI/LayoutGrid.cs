using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTAUnityBase.Base.UI
{
    [DisallowMultipleComponent]
    public class LayoutGrid : MonoBehaviour
    {
        public Vector2 space;

        public float top;

        public float sizey = 0;

        public float left;

        public float sizex = 0;

        [SerializeField]
        protected float MaxX = 100;
        public virtual void AddGameObject(Transform Gobject, Vector2 size)
        {
            Gobject.SetParent(this.transform);
            Gobject.localPosition = new Vector3(
                left + this.sizex + space.x,
                -top - this.sizey - space.y,
                0
                );
            Gobject.localScale = Vector3.one;
            this.sizex += size.x + space.x;
            if (this.sizex + size.x >= MaxX)
            {
                this.sizey += size.y + space.y;
                this.sizex = 0;
            }
            
        }

    }
}
