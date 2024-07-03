namespace AudioSystem.Example
{
    public class SoundSettingsController
    {
        private SoundSettingsModel _model;
        private SoundSettingsView _view;

        private SoundSettingsController(SoundSettingsView view, SoundSettingsModel model)
        {
            _view = view;
            _model = model;
            ConnectView();
        }

        private void ConnectView()
        {
            _view.SetMusic(_model.music.IsMuted(), _model.music.GetVolume());
            _view.SetSfx(_model.soundEffect.IsMuted(), _model.soundEffect.GetVolume());
            _view.SetDialog(_model.dialog.IsMuted(), _model.dialog.GetVolume());

            _view.AddMusicMutedListener(_model.music.MuteVolume);
            _view.AddSfxMutedListener(_model.soundEffect.MuteVolume);
            _view.AddDialogMutedListener(_model.dialog.MuteVolume);

            _view.AddMusicAdjustedListener(_model.music.SetVolume);
            _view.AddSfxAdjustedListener(_model.soundEffect.SetVolume);
            _view.AddDialogAdjustedListener(_model.dialog.SetVolume);
        }

        public class Builder
        {
            public SoundSettingsController Build(SoundSettingsView view, SoundSettingsModel model)
            {
                return new SoundSettingsController(view, model);
            }
        }
    }
}
