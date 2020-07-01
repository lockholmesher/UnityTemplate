using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.Controller;
namespace LTAUnityBase.Base.UI
{
    [DisallowMultipleComponent]
    public class TabBarController : MonoBehaviour
    {
        [SerializeField]
        protected TabController[] arrTabs;

        protected virtual void Start()
        {
            for (int i = 0; i < arrTabs.Length; i++)
            {
                int index = i;
                arrTabs[index].OnClick((btn) =>
                {
                    OnClickTab(index);
                });
            }
        }

        public virtual void OnClickTab(int index)
        {
            Enable(index);
        }

        protected void Enable(int index)
        {
            for (int i=0;i<arrTabs.Length;i++)
            {
                if (i == index)
                {
                    arrTabs[i].IsClicked = true;
                    continue;
                }
                arrTabs[i].IsClicked = false;
            }
            
        }
    }
}
 
