using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LTAUnityBase.Base.UI
{
    [DisallowMultipleComponent]
    public class LoadMutilImage : MonoBehaviour
    {
        [SerializeField]
        private RawImage[] imageThumb;

        private List<WWW> wwwloadImage = new List<WWW>();

        private int indexload = 0;

        public void SetURL(string[] arrurl)
        {
            for (int i = 0; i < arrurl.Length; i++)
            {
                if (i == imageThumb.Length) return;
                wwwloadImage.Add(new WWW(arrurl[i]));
            }
        }

        void Update()
        {
            if (wwwloadImage.Count == 0) return;
            LoadImage(wwwloadImage[0]);
        }
        void LoadImage(WWW loadImage)
        {
            if (!loadImage.isDone) return;

            if (loadImage.error == null)
            {
                imageThumb[indexload].texture = loadImage.texture;
                imageThumb[indexload].texture.mipMapBias = 0.5f;
                indexload++;
            }
            wwwloadImage.Remove(loadImage);
        }
    }
}
