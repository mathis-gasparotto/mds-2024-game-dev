using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance = null;

    public static AudioManager Instance => _instance;

    [SerializeField] private AudioSource _startGameClickAudioSource = null;
    [SerializeField] private AudioSource _clockTickAudioSource = null;
    [SerializeField] private AudioSource _endGameAudioSource = null;

    public bool IsClockTickAudioPlaying => _clockTickAudioSource.isPlaying;
    public bool IsEndGameAudioPlaying => _endGameAudioSource.isPlaying;

    #region Methods
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayStartGameClickAudio()
    {
        _startGameClickAudioSource.Play();
    }

    public void PlayClockTickAudio()
    {
        _clockTickAudioSource.Play();
    }

    public void PlayEndGameAudio()
    {
        _endGameAudioSource.Play();
    }

    public void StopClockTickAudio()
    {
        _clockTickAudioSource.Stop();
    }

    public void StopEndGameAudio()
    {
        _endGameAudioSource.Stop();
    }

    public void StopAllAudio()
    {
        StopClockTickAudio();
        StopEndGameAudio();
    }
    #endregion Methods
}
