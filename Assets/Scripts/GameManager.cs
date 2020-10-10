using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //variable that holds this instance of the GameManager
    public static GameManager instance;

    [Header("Game Objectives")]
    public List<GameObject> brokenRobots;
    public SpriteRenderer interactNotification;

    [Header("UI Stuff")]
    public Text objectiveCount;

    [Header("Sound Stuff")]
    public AudioSource music;
    public AudioListener master;
    public List<AudioSource> sfx;
    [HideInInspector]
    public Slider masterSlider;
    [HideInInspector]
    public Slider musicSlider;
    //public Slider sfxSlider;
    [HideInInspector]
    public float masterVolume;
    //[HideInInspector]
    //public float sfxVolume;
    [HideInInspector]
    public float musicVolume;
    //TODO: sfx and music volume DURING GAME PLAY

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) // if instance is empty
        {
            instance = this; // store THIS instance of the class in the instance variable
            DontDestroyOnLoad(this.gameObject); //keep this instance of game manager when loading new scenes
        }
        else
        {
            Destroy(this.gameObject); // delete the new game manager attempting to store itself, there can only be one.
            Debug.Log("Warning: A second game manager was detected and destrtoyed"); // display message in the console to inform of its demise
        }
    }

    void Start()
    {
        interactNotification = GameObject.FindWithTag("InteractNotification").GetComponent<SpriteRenderer>();
        objectiveCount.text = "x " + brokenRobots.Count;

        master = FindObjectOfType<AudioListener>();
        music = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        if (PauseMenu.isOptions)
        {
            masterSlider = GameObject.FindWithTag("MasterSlider").GetComponent<Slider>();
            musicSlider = GameObject.FindWithTag("MusicSlider").GetComponent<Slider>();
        }

        //sfxSlider = GameObject.FindWithTag("sfxSlider").GetComponent<Slider>();
        LoadOptions();
    }

    void Update()
    {
        UpdateObjective();
        CheckForGameWin();

        if (PauseMenu.isOptions)
        {
            CheckForSliders();
        }
    }

    /// <summary>
    /// handles multiplayer at the start of the game
    /// </summary>
    public void GameStart()
    {

    }

    public void UpdateObjective()
    {
        objectiveCount.text = "x " + brokenRobots.Count;
    }

    public void LoadOptions()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", masterVolume);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", musicVolume);
        //sfxVolume = PlayerPrefs.GetFloat("SFXVolume", sfxVolume);

    }
    public void LoadOptionsGUI()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterSliderValue", masterSlider.value);
        musicSlider.value = PlayerPrefs.GetFloat("MusicSliderValue", musicSlider.value);
        // sfxSlider.value = PlayerPrefs.GetFloat("SFXSliderValue", sfxSlider.value);
    }

    /// <summary>
    /// Saves player option menu preferences, float values only.
    /// Does not save boolen values.
    /// </summary>
    public void SaveOptions()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        //PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.SetFloat("MasterSliderValue", masterSlider.value);
        PlayerPrefs.SetFloat("MusicSliderValue", musicSlider.value);
        //PlayerPrefs.SetFloat("SFXSliderValue", sfxSlider.value);

    }

    public void CheckForVolumeChange()
    {
        masterVolume = masterSlider.value;
        // sfxVolume = sfxSlider.value;
        musicVolume = musicSlider.value;
    }

    public void CheckForSliders()
    {
        if (masterSlider == null)
        {
            masterSlider = GameObject.FindWithTag("MasterSlider").GetComponent<Slider>();
        }

        if (musicSlider == null)
        {
            musicSlider = GameObject.FindWithTag("MusicSlider").GetComponent<Slider>();
        }

        //if (sfxSlider == null)
        //{
        //sfxSlider = GameObject.FindWithTag("sfxSlider").GetComponent<Slider>();
        // }

        if (music == null)
        {
            music = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        }
    }

    void CheckForGameWin()
    {
        if (brokenRobots.Count <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void NotifyPlayer() 
    {
        interactNotification.enabled = true;
    }

    public void DeNotifyPlayer()
    {
        interactNotification.enabled = false;
    }
}
