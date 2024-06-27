﻿using UnityEngine;
using UnityEngine.Audio;

namespace AudioSystem
{
    [CreateAssetMenu(fileName = "SoundClip", menuName = "Audio Settings/Sound Clip", order = 1)]
    public class SoundData : ScriptableObject
    {
        public AudioClip[] clips;
        public AudioMixerGroup mixerGroup;
        public bool loop;
        public bool playOnAwake;
        public bool frequentSound;

        public bool mute;
        public bool bypassEffects;
        public bool bypassListenerEffects;
        public bool bypassReverbZones;

        public int priority = 128;
        public float volume = 1f;
        public float pitch = 1f;
        public float minPitch = .5f;
        public float maxPitch = 1f;
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

        public float GetPitch(bool isRandom = false)
        {
            return isRandom ? Random.Range(minPitch, maxPitch) : pitch;
        }
    }
}