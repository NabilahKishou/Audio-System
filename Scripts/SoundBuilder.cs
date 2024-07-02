using UnityEngine;

namespace AudioSystem
{
    public class SoundBuilder
    {
        readonly SoundManager soundManager;
        Vector3 position = Vector3.zero;
        bool randomClip;
        int clipIndex = -1;

        public SoundBuilder(SoundManager soundManager)
        {
            this.soundManager = soundManager;
        }

        public SoundBuilder WithPosition(Vector3 position)
        {
            this.position = position;
            return this;
        }

        public SoundBuilder WithRandomClip()
        {
            this.clipIndex = -1;
            this.randomClip = true;
            return this;
        }

        public SoundBuilder WithCertainClip(int index)
        {
            this.clipIndex = index;
            return this;
        }

        public void Play(SoundData soundData)
        {
            if (soundData == null)
            {
                Debug.LogError("SoundData is null");
                return;
            }

            if (!soundManager.CanPlaySound(soundData)) return;

            SoundEmitter soundEmitter = soundManager.Get();
            soundEmitter.Initialize(soundData);
            soundEmitter.transform.position = position;
            soundEmitter.transform.parent = soundManager.transform;
            soundEmitter.RandomClip(clipIndex == -1 ? soundData.GetClip(randomClip) : soundData.GetClip(clipIndex));

            if (soundData.frequentSound)
            {
                soundEmitter.Node = soundManager.FrequentSoundEmitters.AddLast(soundEmitter);
            }

            soundEmitter.Play();
        }
    }
}
