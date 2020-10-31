using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using AVFoundation;
using Foundation;
using Xamarin.Forms;

using FearlessFlight.XForms.Interfaces;
using FearlessFlight.XForms.iOS.Services;

[assembly: Dependency(typeof(AudioPlayerService))] 
namespace FearlessFlight.XForms.iOS.Services
{
    public class AudioPlayerService : IAudioPlayerService
    {
        private AVAudioPlayer _audioPlayer = null;
        public Action OnFinishedPlaying { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioPlayerService"/> class.
        /// </summary>
        public AudioPlayerService()
        {
            var avSession = AVAudioSession.SharedInstance();
            avSession.SetCategory(AVAudioSessionCategory.Playback);

            NSError activationError = null;
            avSession.SetActive(true, out activationError);

            if (activationError != null)
            {
                Console.WriteLine("Could not activate audio session {0}", activationError.LocalizedDescription);
            }
        }

        /// <summary>
        /// Plays the specified path to audio file.
        /// </summary>
        /// <param name="pathToAudioFile">The path to audio file.</param>
        public void Play(string pathToAudioFile)
        {
            // Check if _audioPlayer is currently playing
            if (_audioPlayer != null)
            {
                _audioPlayer.FinishedPlaying -= Player_FinishedPlaying;
                _audioPlayer.Stop();
            }

            string localUrl = pathToAudioFile;
            _audioPlayer = AVAudioPlayer.FromUrl(NSUrl.FromFilename(localUrl));
            _audioPlayer.FinishedPlaying += Player_FinishedPlaying;
            _audioPlayer.Play();
        }

        /// <summary>
        /// Handles the FinishedPlaying event of the Player control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="AVStatusEventArgs"/> instance containing the event data.</param>
        private void Player_FinishedPlaying(object sender, AVStatusEventArgs e)
        {
            OnFinishedPlaying?.Invoke();
        }

        /// <summary>
        /// Pauses this instance.
        /// </summary>
        public void Pause()
        {
            _audioPlayer?.Pause();
        }

        /// <summary>
        /// Plays this instance.
        /// </summary>
        public void Play()
        {
            _audioPlayer?.Play();
        }
    }
}
