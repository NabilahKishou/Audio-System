using UnityEngine;

namespace AudioSystem.Example
{
    public class SoundSettings : MonoBehaviour
    {
        [SerializeField] private VolumePreset _musicPreset;
        [SerializeField] private VolumePreset _sfxPreset;
        [SerializeField] private VolumePreset _dialogPreset;

        private SoundSettingsView _view;
        private SoundSettingsController _controller;

        private void Awake()
        {
            _view = this.GetComponent<SoundSettingsView>();
            _controller = new SoundSettingsController.Builder()
                .Build(_view, new SoundSettingsModel() { 
                    music = _musicPreset, 
                    soundEffect = _sfxPreset,
                    dialog = _dialogPreset });
        }
    }
}
