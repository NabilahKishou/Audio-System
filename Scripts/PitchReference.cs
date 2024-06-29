using System;
using UnityEngine;

namespace AudioSystem
{
    [Serializable]
    public class PitchReference
    {
        [SerializeField] bool _useConstant = true;
        [SerializeField] float _constantValue = 1f;
        [SerializeField] float _minLimit = -3f, _maxLimit = 3f;
        [SerializeField] float _minValue = -.5f, _maxValue = .5f;

        public PitchReference() { }
        public PitchReference(float value)
        {
            _useConstant = true;
            _constantValue = value;
        }
        public float Value => _useConstant ? _constantValue : UnityEngine.Random.Range(_minValue, _maxValue);
    }
}
