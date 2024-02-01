using System;
using System.Collections;
using general;
using general.win;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ui
{
    public class CrossLine : MonoBehaviour
    {
        private RectTransform _rtf;
        private Image _img;
        private IGameManager _gameManager;
        private RectTransform _imgRtf;

        // Start is called before the first frame update
        [Inject]
        private void Construct(IGameManager gameManager)
        {
            _rtf = GetComponent<RectTransform>();
            _img = GetComponentInChildren<Image>();
            _imgRtf = _img.rectTransform;
            _gameManager = gameManager;
            _gameManager.OnGameEndCross += Cross;
            _gameManager.OnRestart += Hide;

            Hide();
        }

        private void Enable(bool b)
        {
            _img.color = b ? Color.white : Color.clear;
        }

        private void Hide() => Enable(false);


        public void Cross(CrossLineType crossType, int2 coord, Action<bool> handler)
        {
            switch (crossType)
            {
                case CrossLineType.None:
                    break;
                case CrossLineType.Hor:
                    _rtf.localEulerAngles = Vector3.zero;
                    _rtf.localPosition = new Vector3(-160, -120 * (coord.y - 1), 0);
                    Extend(340, handler);
                    break;
                case CrossLineType.Vert:
                    _rtf.localEulerAngles = Vector3.forward * 270;
                    _rtf.localPosition = new Vector3(-120 * (1 - coord.x), 160, 0);
                    Extend(340, handler);
                    break;
                case CrossLineType.Diag:
                    _rtf.localEulerAngles = Vector3.forward * 315;
                    _rtf.localPosition = new Vector3(-160, 160, 0);
                    Extend(466, handler);
                    break;
                case CrossLineType.InvDiag:
                    _rtf.localEulerAngles = Vector3.forward * 225;
                    _rtf.localPosition = new Vector3(160, 160, 0);
                    Extend(466, handler);
                    break;
                default:
                    handler?.Invoke(false);
                    break;
            }
        }

        private void Extend(int length, Action<bool> handler)
        {
            Enable(true);
            StartCoroutine(Extend_C(length, handler));
        }

        private IEnumerator Extend_C(int length, Action<bool> handler)
        {
            float value = 0;
            float speed = 0.025f;
            handler?.Invoke(true);
            while (value < 1)
            {
                value = Mathf.Clamp01(value + speed);
                _imgRtf.sizeDelta = new Vector2(Mathf.Lerp(20, length, value), 100);

                yield return null;
            }

            handler?.Invoke(false);
        }

        private void OnDestroy()
        {
            _gameManager.OnGameEndCross -= Cross;
            _gameManager.OnRestart -= Hide;
        }
    }
}