using UnityEngine;
namespace LTAUnityBase.Base.Controller
{
    public class BaseMainComponent<T> : MonoBehaviour where T : Component
    {
        T main;

        protected T Main
        {
            get
            {
                if (main == null)
                    main = GetComponent<T>();
                return main;
            }
        }
    }
}
