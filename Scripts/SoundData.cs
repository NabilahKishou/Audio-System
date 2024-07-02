using UnityEngine;
using UnityEngine.Audio;

namespace AudioSystem
{
    [CreateAssetMenu(fileName = "SoundData", menuName = "Audio Settings/Sound Data", order = 1)]
    public class SoundData : ScriptableObject
    {
        public AudioClip[] clips;
        public AudioMixerGroup mixerGroup;
        [Tooltip("Uncheck to use volume preset")]
        public VolumeReference volume;
        [Tooltip("Uncheck to use random range pitch")]
        public PitchReference pitch;
        public bool loop;
        public bool playOnAwake;
        public bool frequentSound;

        public bool mute;
        public bool bypassEffects;
        public bool bypassListenerEffects;
        public bool bypassReverbZones;

        public int priority = 128;
        public float panStereo;
        public float spatialBlend;
        public float reverbZoneMix = 1f;
        public float dopplerLevel = 1f;
        public float spread;

        public float minDistance = 1f;
        public float maxDistance = 500f;

        public bool ignoreListenerVolume;
        public bool ignoreListenerPause;

        public AudioRolloffMode rolloffMode = AudioRolloffMode.Logarithmic;

        public AudioClip GetClip(bool isRandom = false)
        {
            if (clips.Length <= 1) return clips[0];
            return isRandom ? clips[Random.Range(0, clips.Length - 1)] : clips[0];
        }

        public AudioClip GetClip(int index)
        {
            return clips[index];
        }
    }
}
