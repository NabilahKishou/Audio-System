# Audio System

Solution for sound or audio system you might need. Take care of your average sounds problem with pooling approach.
You also could play some sound effect(sfx) with multiple clips. And also you could play it with randomize pitch so it could make 
variant SFX results.

## Example

First thing first, you need to create a prefab with [SoundEmitter.cs]() as its component. 
It will automatically add AudioSource component with it.

![Sound Emitter Image]()

Next step you create an object with [SoundManager.cs]() on it. 
Insert the Sound Emitter prefab above to the Sound Emitter Prefab field on the SoundManager object via inspector.

![Sound Manager Image]()

Create your SoundData SO to store your clips. You could create it via Right Click > Create > Audio Settings > Sound Data.
Don't forget to add the clips and setup the sound settings as your preference.

![Sound Data Image]()

Last you just need to reference the SoundData SO and call it via [SoundBuilder.cs]() to play the audio.

```csharp
private SoundData _clipData;
private SoundBuilder _soundB;

_soundB ??= SoundManager.Instance.CreateSoundBuilder();
_soundB.WithRandomClip().Play(_clipData);
```

## Thank-you Notes

This audio system was all inspired from [Adam Mhyre's Video](https://youtu.be/BgpqoRFCNOs) and kindly visit his [Audio System Repo](https://github.com/adammyhre/Unity-Audio-Pooling).

Lastly thanks for visiting this page. And I will gladly accept any kind of feedback. You can contact me through here <nabilahkishou@gmail.com>.
