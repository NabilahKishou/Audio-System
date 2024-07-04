# Audio System

Solution for sound or audio system you might need. Take care of your average sounds problem with pooling approach.
You also could play some sound effect(sfx) with multiple clips. And also you could play it with randomize pitch so it could make 
variant SFX results.

## Example

First thing first, you need to create a prefab with [SoundEmitter.cs]() as its component. 
It will automatically add AudioSource component with it.

![Sound Emitter Image](https://github.com/NabilahKishou/Audio-System/assets/33479013/a52a203b-da58-4f48-9d30-2d949fe760ac)


Next step you create an object with [SoundManager.cs]() on it. 
Insert the Sound Emitter prefab above to the Sound Emitter Prefab field on the SoundManager object via inspector.

![Sound Manager Image](https://github.com/NabilahKishou/Audio-System/assets/33479013/614f7044-6f0b-4bd2-bf9d-c7b0aa69a17b)


Create your SoundData SO to store your clips. You could create it via Right Click > Create > Audio Settings > Sound Data.
Don't forget to add the clips and setup the sound settings as your preference.

![Sound Data Image](https://github.com/NabilahKishou/Audio-System/assets/33479013/9d1d8534-d92b-4e52-a8ca-ae0306432346)


Last you just need to reference the SoundData SO and call it via [SoundBuilder.cs]() to play the audio.

```csharp
private SoundData _clipData;
private SoundBuilder _soundB;

_soundB ??= SoundManager.Instance.CreateSoundBuilder();
_soundB.WithRandomClip().Play(_clipData);
```

## How-to-Install

You can easily install this audio system by downloading the package library into your Unity project or you could install this by import it in Unity via the Unity Package Manager using this URL:

```
https://github.com/NabilahKishou/Audio-System.git
```

## Thank-you Notes

This audio system was all inspired from [Adam Mhyre's Video](https://youtu.be/BgpqoRFCNOs) and kindly visit his [Audio System Repo](https://github.com/adammyhre/Unity-Audio-Pooling).

Lastly thanks for visiting this page. And I will gladly accept any kind of feedback. You can contact me through here <nabilahkishou@gmail.com>.
