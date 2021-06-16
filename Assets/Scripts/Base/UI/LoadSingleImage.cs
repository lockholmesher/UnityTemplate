using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LTAUnityBase.Base.UI
{
    [DisallowMultipleComponent]
    public class LoadSingleImage : MonoBehaviour
    {
        private WWW wwwloadImage;

        [SerializeField]
        private RawImage imageThumb;

        public void SetURL(string url)
        {
            //Debug.Log("SetURL" + url);
            wwwloadImage = new WWW(url);
        }
        // Update is called once per frame
        void Update()
        {
            if (wwwloadImage == null) return;
            if (!wwwloadImage.isDone) return;

            if (wwwloadImage.error == null)
            {
                imageThumb.texture = wwwloadImage.texture;
                Texture2D tex = wwwloadImage.texture;
                imageThumb.texture.mipMapBias = 0.5f;
            }
            wwwloadImage = null;
        }
    }
}
