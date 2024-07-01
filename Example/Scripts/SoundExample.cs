using UnityEngine;

namespace AudioSystem.Example
{
    public class SoundExample : MonoBehaviour
    {
        [SerializeField] private SoundData _clipData;
        private SoundBuilder _soundB;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SpaceKeyDown();
        }

        private void SpaceKeyDown()
        {
            _soundB ??= SoundManager.Instance.CreateSoundBuilder();
            _soundB.WithRandomClip().Play(_clipData);
        }
    }

}
