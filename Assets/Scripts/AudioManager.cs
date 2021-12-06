using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Utility
{
    public class AudioManager : MonoSingleton<AudioManager>
    {
        // Initialized audio sources for manager
        #region
        private AudioSource musicSource1;
        private AudioSource musicSource2;
        private AudioSource sfxSource;
        private AudioSource dialogueSource;
        #endregion

        // Parameters for fading music
        #region
        private float speed = 0.5f;
        float lerpSpeed1;
        float lerpSpeed2;
        private float fadeTime = 1f;
        #endregion


        private void Awake()
        {
            musicSource1 = this.gameObject.AddComponent<AudioSource>();
            musicSource2 = this.gameObject.AddComponent<AudioSource>();
            sfxSource = this.gameObject.AddComponent<AudioSource>();
            dialogueSource = gameObject.AddComponent<AudioSource>();

            // Assigning audio mixer child to each audio source
            AudioMixer MasterMixer = Resources.Load<AudioMixer>("Master");
            string _MixerGroup1 = "Music";
            //string _MixerGroup2 = "MusicSource2";
            string _MixerGroup3 = "SFX";
            string _MixerGroup4 = "Dialogue";
            musicSource1.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(_MixerGroup1)[0];
            musicSource2.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(_MixerGroup1)[0];
            sfxSource.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(_MixerGroup3)[0];
            dialogueSource.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(_MixerGroup4)[0];
        }

        // Play voice over clips
        public void PlayDialogue(AudioClip voiceClip, float volume, float pitch)
        {
            dialogueSource.volume = volume;
            dialogueSource.pitch = pitch;
            dialogueSource.clip = voiceClip;
            dialogueSource.Play();
        }

        // Play one shot audio clips
        public void PlaySFX(AudioClip audioClip, float volume, float pitch)
        {
            sfxSource.volume = volume;
            sfxSource.pitch = pitch;
            sfxSource.PlayOneShot(audioClip);
        }

        // Play MusicSource1 with option to loop
        public void PlayMusicSource1(AudioClip audioClip, float volume, bool loop = false)
        {
            musicSource1.clip = audioClip;
            musicSource1.volume = volume;
            musicSource1.loop = loop;
            musicSource1.Play();
        }

        // Play MusicSource2 with option to loop
        public void PlayMusicSource2(AudioClip audioClip, float volume, bool loop = false)
        {
            musicSource2.clip = audioClip;
            musicSource2.volume = volume;
            musicSource2.loop = loop;
            musicSource2.Play();
        }

        // stop dialogue
        public void StopDialogue()
        {
            dialogueSource.Stop();
        }

        // Stop MusicSource1
        public void StopMusicSource1()
        {
            musicSource1.Stop();
        }

        // Stop MusicSource2
        public void StopMusicSource2()
        {
            musicSource2.Stop();
        }

        // pause dialogue
        public void PauseDialogue()
        {
            dialogueSource.Pause();
        }

        // Pause MusicSource1
        public void PauseMusicSource1()
        {
            musicSource1.Pause();
        }

        // Pause MusicSource2
        public void PauseMusicSource2()
        {
            musicSource2.Pause();
        }

        // Unpause LoopSource1
        public void UnPauseLoopSource1()
        {
            musicSource1.UnPause();
        }

        // Unpause LoopSource2
        public void UnPauseLoopSource2()
        {
            musicSource2.UnPause();
        }

        // change MusicSource1 volume
        public void MusicSource1Vol(float volume)
        {
            musicSource1.volume = volume;
        }

        // change MusicSource2 volume
        public void MusicSource2Vol(float volume)
        {
            musicSource2.volume = volume;
        }

        // Fades out first loop source
        IEnumerator FadeOutLoopSource1Vol()
        {
            yield return null;
            while (musicSource1.volume > 0)
            {
                lerpSpeed1 += Time.deltaTime;
                musicSource1.volume = Mathf.Lerp(1, 0, lerpSpeed1);
                //print(loopSource1.volume);
                yield return new WaitForSecondsRealtime(0.1f);
            }
        }

        // Fades out 2nd loop source
        IEnumerator FadeOutLoopSource2Vol()
        {
            yield return null;
            while (musicSource2.volume > 0)
            {
                lerpSpeed2 += Time.deltaTime;
                musicSource2.volume = Mathf.Lerp(1, 0, lerpSpeed1);
                //print(loopSource2.volume);
                yield return new WaitForSecondsRealtime(0.1f);
            }
        }

        // Fades in 2nd loop source
        public IEnumerator FadeInMusicSource2Vol()
        {
            yield return null;
            while (musicSource2.volume < 1.0f)
            {
                lerpSpeed2 += Time.deltaTime;
                musicSource2.volume = Mathf.Lerp(0, 1, lerpSpeed2);
                yield return new WaitForSecondsRealtime(fadeTime);
            }
        }

        // Fades in 1st loop source
        public IEnumerator FadeInMusicSource1Vol()
        {
            yield return null;
            while (musicSource1.volume < 1.0f)
            {
                lerpSpeed1 += Time.deltaTime;
                musicSource1.volume = Mathf.Lerp(0, 1, lerpSpeed2);
                yield return new WaitForSecondsRealtime(fadeTime);
            }
        }

        public void FadeInMusicSource1()
        {
            //StartCoroutine(FadeOutLoopSource2Vol());
            StartCoroutine(FadeInMusicSource1Vol());
        }

        public void FadeInMusicSource2()
        {
            //StartCoroutine(FadeOutLoopSource1Vol());
            StartCoroutine(FadeInMusicSource2Vol());
        }
    }
}