using UnityEngine;

namespace Assets._Game.Scripts.MainMenuLogic
{
    public class Transition : MonoBehaviour
    {
        [SerializeField] private Material material;
        [SerializeField] private float step;
        [SerializeField] private float minValue = -0.1f;
        [SerializeField] private float maxValue = 0.5f;

        private float _maskAmount = 0f;
        private float _exponential = 0f;
        private float _targetValue = 1f;
        private bool _isAppearing;
        private bool _isDiappearing;
        public bool IsAppearing => _isAppearing;
        public bool IsDiappearing => _isDiappearing;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            material.SetFloat("_MaskAmount", minValue);
        }
        public void AppearTransition()
        {
            material.SetFloat("_MaskAmount", minValue);
            _targetValue = maxValue;
            _maskAmount = minValue;
            _isAppearing = true;
            _exponential = 0;
        }
        public void DiappearTransition()
        {
            material.SetFloat("_MaskAmount", maxValue);
            _targetValue = minValue;
            _maskAmount = maxValue;
            _isDiappearing = true;
            _exponential = 0;

        }
        private void Update()
        {
            if (!_isAppearing && !_isDiappearing)
                return;
            float maskAmountChange = _targetValue > _maskAmount ? +step : -step;
            _maskAmount += maskAmountChange + _exponential * Time.deltaTime;
            _exponential += maskAmountChange;
            if (_maskAmount > maxValue && _isAppearing)
            {
                _isAppearing = false;
                material.SetFloat("_MaskAmount", maxValue);
            }
            else if (_maskAmount < minValue && _isDiappearing)
            {
                _isDiappearing = false;
                material.SetFloat("_MaskAmount", minValue);
            }
            else
                material.SetFloat("_MaskAmount", _maskAmount);
        }
    }
}