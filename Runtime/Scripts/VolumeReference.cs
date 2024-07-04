using System;
using UnityEngine;

namespace AudioSystem
{
    [Serializable]
    public class VolumeReference
    {
        [SerializeField] bool _useConstant = true;
        [SerializeField] float _constantValue = 1;
        [SerializeField] VolumePreset _preset;

        public VolumeReference() { }
        public VolumeReference(float value)
        {
            _useConstant = true;
            _constantValue = value;
        }
        public float Value => _useConstant ? _constantValue : _preset.GetVolume();
    }
}
