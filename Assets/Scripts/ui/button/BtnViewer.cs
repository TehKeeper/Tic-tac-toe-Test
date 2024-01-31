using System;
using general;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace ui.button
{
    public class BtnViewer
    {
        //private readonly IGameManager _gameManager;
        private Transform _tf;
        private Image _img;
        private int2 _coords;

        /*public BtnViewer(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }*/

        public void Update((Sprite sprite, Color clr, int2 coord) obj)
        {
            Debug.Log("Viewer updated");
            if (!_img || !obj.coord.Equals(_coords))
                return;

            _img.color = obj.clr;
            _img.sprite = obj.sprite;
        }

        public void Init(Transform transform, int2 coords)
        {
            _tf = transform;
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

        public void Reset() => Update((null, Color.clear, _coords));
    }
}