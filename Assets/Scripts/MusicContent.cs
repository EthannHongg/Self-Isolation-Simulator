using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicContent : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private AudioClip classical1;

    [SerializeField]
    private AudioClip classical2;

    [SerializeField]
    private AudioClip classical3;

    public bool buttonsSet;
    private bool play;
    private string currentPlayingMusic;

    void Start()
    {
        buttonsSet = false;
        play = false;
        currentPlayingMusic = null;
    }

    // Update is called once per frame
    void Update()
    {
        SceneAppropriate();
        
    }

    private void SceneAppropriate()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Music" && buttonsSet == false)
        {
            buttonsSet = true;
            ResetButton();
        }
    }

    public void PlayClassical()
    {
        //if (play == true && currentPlayingMusic == "Classical")
        //{
        //    AudioSource source = gameObject.GetComponent<AudioSource>();
        //    source.Pause();
        //    play = false;
        //    Debug.Log("A");
        //}
        //else if (play == false && currentPlayingMusic == "Classical")
        //{
        //    play = true;
        //    currentPlayingMusic = "Classical";
        //    Debug.Log("C");
        //}
        //else
        //{
        //    PlayRandom(classical1, classical2, classical3);
        //}
        PlayRandom(classical1, classical2, classical3);
    }

    private void PlayRandom(AudioClip clip1, AudioClip clip2, AudioClip clip3)
    {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        int num = Random.Range(0, 3);
        if (num == 0)
        {
            source.clip = clip1;
        }
        else if (num == 1)
        {
            source.clip = clip2;
        }
        else
        {
            source.clip = clip3;
        }
        source.Play();
    }

    void ResetButton()
    {
        //Button pop = GameObject.Find("PopPlay").GetComponent<Button>();
        //pop.onClick.AddListener(PlayPop);
        //Button rock = GameObject.Find("RockPlay").GetComponent<Button>();
        //rock.onClick.AddListener(PlayRock);
        //Button instrumental= GameObject.Find("InstrumentalPlay").GetComponent<Button>();
        //instrumental.onClick.AddListener(PlayInstrumental);
        //Button jazz = GameObject.Find("JazzPlay").GetComponent<Button>();
        //jazz.onClick.AddListener(PlayJazz);
        Button classical = GameObject.Find("ClassicalPlay").GetComponent<Button>();
        classical.onClick.AddListener(PlayClassical);
        //Button songs = GameObject.Find("SongsPlay").GetComponent<Button>();
        //songs.onClick.AddListener(PlaySongs);
    }
}
