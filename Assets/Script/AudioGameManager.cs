using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioGameManager : MonoBehaviour
{
    [HideInInspector] public AudioSource audioSource;
   // private AudioSource audioSFX;
    [SerializeField] private AudioClip audioTheme, audioGame;
    public AudioClip[] audioClipSFX;
    private bool audioThemePlay, audioGamePlay;
    public static AudioGameManager Instance { get;  private set; }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
      //  audioSFX = GetComponent<AudioSource>();
       /* audioTheme = GetComponent<AudioClip>();
        audioGame = GetComponent<AudioClip>();*/
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            if (!audioThemePlay)
            {
                audioSource.clip = audioTheme;
                audioThemePlay = true;
                audioGamePlay = false;
                audioSource.Play();
            }
            

            
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3 && !audioGamePlay)
        {
            audioSource.clip = audioGame;
            audioGamePlay = true;
            audioThemePlay= false;
            audioSource.Play();
        }

        
    }

    public void SoundSelect()
    {
        audioSource.PlayOneShot(audioClipSFX[0], 1);
    }

}
