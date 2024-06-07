using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tank_top_down
{
    public class AudioChild : MonoBehaviour
    {
        AudioSource _audioSource;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            StartCoroutine(WaitSoundDone());
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator WaitSoundDone()
        {
            yield return new WaitUntil(() => !_audioSource.isPlaying);
            this.gameObject.SetActive(false);
        }
    }
}

