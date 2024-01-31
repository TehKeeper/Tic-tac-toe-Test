using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace ui.button
{
    public class BtnViewer
    {

        private Image _img;
        private int2 _coords;

        public void Init(Transform transform, int2 coords)
        {
            var imgGo = new GameObject("ViewImage");
            var imgTf = imgGo.transform;
            imgTf.parent = transform;
            imgTf.localScale = Vector3.one;
            imgTf.localPosition = Vector3.zero;
            _img = imgGo.AddComponent<Image>();
            _img.raycastTarget = false;
            _img.color = Color.clear;

            _coords = coords;
        }
        
        public void Update((Sprite sprite, Color clr) obj, int2 coord)
        {
            if (!_img || !coord.Equals(_coords))
                return;

            _img.color = obj.clr;
            _img.sprite = obj.sprite;
        }

        public void Reset() => Update((null, Color.clear), _coords);
    }
}