using UnityEngine;

namespace AudioSystem
{
    [CreateAssetMenu(fileName = "VolumePreset", menuName = "Audio Settings/Volume Preset", order = 2)]
    public class VolumePreset : ScriptableObject
    {
        [SerializeField] private bool _isMute;
        [SerializeField, Range(0, 1)] private float _volume = 1f;

        public void MuteVolume(bool mute)
        {
            this._isMute = mute;
        }

        public void SetVolume(float value)
        {
            this._volume = value;
        }

        public bool IsMuted()
        {
            return _isMute;
        }
        public float GetVolume()
        {
            return _isMute ? 0f : _volume;
        }
    }
}
