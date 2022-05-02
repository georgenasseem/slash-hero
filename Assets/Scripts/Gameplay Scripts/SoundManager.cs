using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    [SerializeField]
    private AudioSource bgAudio, gameOverAudio;

    [SerializeField]
    private AudioClip bgMusic, mainMenuMusic, playerAttackSound, playerJumpSound,
        playerDeathSound, enemyAttackSound,
        enemyDeathSound, collectableSound, destroyObstacleSound;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {

        if (scene.name == TagManager.GAMEPLAY_SCENE_NAME)
        {

            if (DataManager.GetData(TagManager.MUSIC_DATA) == 1)
                PlayBGMusic(true);

        }
        else
        {
            if (DataManager.GetData(TagManager.MUSIC_DATA) == 1)
                PlayBGMusic(false);
        }

    }

    public void PlayBGMusic(bool gameplay)
    {
        if (gameplay)
        {
            bgAudio.clip = bgMusic;
        }
        else
        {
            bgAudio.clip = mainMenuMusic;
        }

        bgAudio.Play();
    }

    public void StopBGMusic()
    {
        bgAudio.Stop();
    }    

    public void Play_GameOver_Sound()
    {
        gameOverAudio.Play();
    }

    public void Play_PlayerAttack_Sound()
    {
        AudioSource.PlayClipAtPoint(playerAttackSound, transform.position);
    }

    public void Play_PlayerJump_Sound()
    {
        AudioSource.PlayClipAtPoint(playerJumpSound, transform.position);
    }

    public void Play_PlayerDeath_Sound()
    {
        AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
    }

    public void Play_EnemyAttack_Sound()
    {
        AudioSource.PlayClipAtPoint(enemyAttackSound, transform.position);
    }

    public void Play_EnemyDeath_Sound()
    {
        AudioSource.PlayClipAtPoint(enemyDeathSound, transform.position);
    }

    public void Play_CollectableSound_Sound()
    {
        AudioSource.PlayClipAtPoint(collectableSound, transform.position);
    }

    public void Play_ObstacleDestroy_Sound()
    {
        AudioSource.PlayClipAtPoint(destroyObstacleSound, transform.position);
    }

} // class
































