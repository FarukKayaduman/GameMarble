using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager_sc : MonoBehaviour
{
    private static AudioManager_sc audioManager = null;
    
    public AudioSource audioSource; // Audio
    public AudioSource _audioSource; // Temp

    public AudioClip mainMenuAudioClip;
    public AudioClip gameAudioClip;

    void Awake()
    {
        if (audioManager == null)
            audioManager = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += SceneChanged;
    }

    // Main Menu ile oyun sahnesi aras�nda ge�i� oldu�unda oynat�lacak ses klibini de�i�tirir
    void SceneChanged(Scene scene, LoadSceneMode sceneMode)
    {
        // Build index de�erine g�re istenilen klibin ge�ici de�i�kene atanmas�
        if (scene.buildIndex == 0)
            _audioSource.clip = mainMenuAudioClip;
        else
            _audioSource.clip = gameAudioClip;

        // Sadece de�i�iklik oldu�unda �al��mas� i�in
        if (audioSource.clip != _audioSource.clip)
        {
            audioSource.enabled = false;
            audioSource.clip = _audioSource.clip;
            audioSource.enabled = true;
        }
    }
}
