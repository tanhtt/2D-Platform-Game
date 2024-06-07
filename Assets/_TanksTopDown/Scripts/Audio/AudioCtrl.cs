using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tank_top_down
{
    public class AudioCtrl : Singleton<AudioCtrl>
    {
        [SerializeField] AudioSource _audioChildPrefab;
        [SerializeField] List<AudioClip> _audioClips = new List<AudioClip>();

        [SerializeField] List<AudioSource> audioSources = new List<AudioSource>();

        private bool isSound = true, isSFX = true;

        private void Start()
        {
            isSound = PlayerPrefs.GetInt("SOUND", 1) == 1 ? true : false;
        }

        public void SetSound(bool isSound)
        {
            this.isSound = isSound;

            PlayerPrefs.SetInt("SOUND", isSound ? 1 : 0);

            if(this.isSound)
            {
                foreach(AudioSource source in audioSources)
                {
                    source.Stop();
                }
            }
        }

        public void PlaySound(string nameSound)
        {
            if (!isSound) return;

            AudioClip audioClip = null;
            foreach(AudioClip clip in _audioClips)
            {
                if(clip.name.ToLower().Equals(nameSound.ToLower()))
                {
                    audioClip = clip;
                    break;
                }
            }

            if(audioClip == null)
            {
                Debug.LogError("Sound" + nameSound + " does not exist!");
            }

            AudioSource audioSource = null;

            foreach(AudioSource audio in  audioSources)
            {
                if(audio.gameObject.activeSelf)
                {
                    continue;
                }
                audioSource = audio;
            }

            if(audioSource == null)
            {
                audioSource = Instantiate(_audioChildPrefab, transform.position, Quaternion.identity, this.transform);
                audioSources.Add(audioSource); 
            }

            audioSource.gameObject.SetActive(false);
            audioSource.clip = audioClip;
            audioSource.gameObject.SetActive(true);
        }
    }
}
