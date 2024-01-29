﻿using System;
using general;
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

        /*public BtnViewer(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }*/

        public void Update((Sprite sprite, Color clr) obj)
        {
            Debug.Log("Viewer updated");
            if (!_img)
                return;

            _img.color = obj.clr;
            _img.sprite = obj.sprite;
        }

        public void Init(Transform transform)
        {
            _tf = transform;
            var imgGo = Object.Instantiate(new GameObject("ViewImage"), _tf.position, _tf.rotation,
                _tf);
            _img = imgGo.AddComponent<Image>();
            _img.raycastTarget = false;
            _img.color = Color.clear;
        }
    }
}