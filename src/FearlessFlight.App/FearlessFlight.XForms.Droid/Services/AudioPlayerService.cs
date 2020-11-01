using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Media;
//using AudioPlayer.Droid.Services;
//using AudioPlayer.Services;

using Xamarin.Forms;

using FearlessFlight.XForms.Droid.Services;
using FearlessFlight.XForms.Interfaces;

[assembly: Dependency(typeof(AudioPlayerService))]
namespace FearlessFlight.XForms.Droid.Services
{
    public class AudioPlayerService : IAudioPlayerService
    {
        private MediaPlayer _mediaPlayer;
        public Action OnFinishedPlaying { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioPlayerService"/> class.
        /// </summary>
        public AudioPlayerService()
        {
        }

        /// <summary>
        /// Plays the specified path to sound name.
        /// </summary>
        /// <param name="pathToSoundName">Name of the path to sound.</param>
        public void Play(string pathToSoundName)
        {
            if (_mediaPlayer != null)
            {
                _mediaPlayer.Completion -= MediaPlayer_Completion;
                _mediaPlayer.Stop();
            }

            var fullPath = pathToSoundName;

            Android.Content.Res.AssetFileDescriptor afd = null;

            try
            {
                afd = Forms.Context.Assets.OpenFd(fullPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error openfd: " + ex);
            }

            if (afd != null)
            {
                System.Diagnostics.Debug.WriteLine("Length " + afd.Length);
                if (_mediaPlayer == null)
                {
                    _mediaPlayer = new MediaPlayer();
                    _mediaPlayer.Prepared += (sender, args) =>
                    {
                        _mediaPlayer.Start();
                        _mediaPlayer.Completion += MediaPlayer_Completion;
                    };
                }

                _mediaPlayer.Reset();
                _mediaPlayer.SetVolume(1.0f, 1.0f);

                _mediaPlayer.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length);
                _mediaPlayer.PrepareAsync();
            }
        }

        /// <summary>
        /// Handles the Completion event of the MediaPlayer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void MediaPlayer_Completion(object sender, EventArgs e)
        {
            OnFinishedPlaying?.Invoke();
        }

        /// <summary>
        /// Pauses this instance.
        /// </summary>
        public void Pause()
        {
            _mediaPlayer?.Pause();
        }

        /// <summary>
        /// Plays this instance.
        /// </summary>
        public void Play()
        {
            _mediaPlayer?.Start();
        }
    }
}