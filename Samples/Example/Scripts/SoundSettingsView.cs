using System;
using UnityEngine;
using UnityEngine.UI;

namespace AudioSystem.Example
{
    public class SoundSettingsView : MonoBehaviour
    {
        [SerializeField] private Slider _musicVolume;
        [SerializeField] private Toggle _musicMute;
        [SerializeField] private Slider _sfxVolume;
        [SerializeField] private Toggle _sfxMute;
        [SerializeField] private Slider _dialogVolume;
        [SerializeField] private Toggle _dialogMute;

        private event Action<bool> _onMusicMuted = delegate { };
        private event Action<bool> _onSfxMuted = delegate { };
        private event Action<bool> _onDialogMuted = delegate { };

        private event Action<float> _onMusicAdjusted = delegate { };
        private event Action<float> _onSfxAdjusted = delegate { };
        private event Action<float> _onDialogAdjusted = delegate { };

        private void Awake()
        {
            _musicMute.onValueChanged.AddListener((val) => _onMusicMuted(val));
            _sfxMute.onValueChanged.AddListener((val) => _onSfxMuted(val));
            _dialogMute.onValueChanged.AddListener((val) => _onDialogMuted(val));

            _musicVolume.onValueChanged.AddListener((val) => _onMusicAdjusted(val));
            _sfxVolume.onValueChanged.AddListener((val) => _onSfxAdjusted(val));
            _dialogVolume.onValueChanged.AddListener((val) => _onDialogAdjusted(val));
        }

        public void SetMusic(bool isMute, float value)
        {
            _musicMute.isOn = isMute;
            _musicVolume.value = value;
        }
        public void SetSfx(bool isMute, float value)
        {
            _sfxMute.isOn = isMute;
            _sfxVolume.value = value;
        }
        public void SetDialog(bool isMute, float value)
        {
            _dialogMute.isOn = isMute;
            _dialogVolume.value = value;
        }

        public void AddMusicMutedListener(Action<bool> listener) => _onMusicMuted += listener;
        public void AddSfxMutedListener(Action<bool> listener) => _onSfxMuted += listener;
        public void AddDialogMutedListener(Action<bool> listener) => _onDialogMuted += listener;
        public void AddMusicAdjustedListener(Action<float> listener) => _onMusicAdjusted += listener;
        public void AddSfxAdjustedListener(Action<float> listener) => _onSfxAdjusted += listener;
        public void AddDialogAdjustedListener(Action<float> listener) => _onDialogAdjusted += listener;
    }
}
