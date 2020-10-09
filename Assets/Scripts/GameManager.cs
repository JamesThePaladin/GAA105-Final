using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //variable that holds this instance of the GameManager
    public static GameManager instance;

    [HideInInspector]
    public bool isGameStart;

    [Header("Enemy Stuff")]
    //list to hold all enemies in game
    public List<GameObject> enemies;
    //list of all enemy prefabs to spawn as enemies
    public List<GameObject> enemyPrefabs;
    //list to hold enemy spawners
    public List<GameObject> enemySpawners;
    //list of waypoints for patrolling
    public List<Transform> waypoints;
    //int for currrent enemies on the map
    public int currentEnemies;
    //int for max enemies on the map
    public int maxEnemies;
    //spawn cooldown for enemy spawns
    public float enemySpawnDelay;

    [Header("Sound Stuff")]
    public AudioSource music;
    public AudioListener master;
    public List<AudioSource> sfx;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    [HideInInspector]
    public float masterVolume;
    [HideInInspector]
    public float sfxVolume;
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
        master = FindObjectOfType<AudioListener>();
        music = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        masterSlider = GameObject.FindWithTag("MasterSlider").GetComponent<Slider>();
        musicSlider = GameObject.FindWithTag("MusicSlider").GetComponent<Slider>();
        sfxSlider = GameObject.FindWithTag("sfxSlider").GetComponent<Slider>();
        LoadOptions();
    }

    void Update()
    {

    }

    /// <summary>
    /// handles multiplayer at the start of the game
    /// </summary>
    public void GameStart() 
    {

    }

    public void LoadOptions() 
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", masterVolume);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", musicVolume);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", sfxVolume);
        
    }
    public void LoadOptionsGUI() 
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterSliderValue", masterSlider.value);
        musicSlider.value = PlayerPrefs.GetFloat("MusicSliderValue", musicSlider.value);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXSliderValue", sfxSlider.value);
    }

    /// <summary>
    /// Saves player option menu preferences, float values only.
    /// Does not save boolen values.
    /// </summary>
    public void SaveOptions()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.SetFloat("MasterSliderValue", masterSlider.value);
        PlayerPrefs.SetFloat("MusicSliderValue", musicSlider.value);
        PlayerPrefs.SetFloat("SFXSliderValue", sfxSlider.value);

    }

    public void CheckForVolumeChange() 
    {
        masterVolume = masterSlider.value;
        sfxVolume = sfxSlider.value;
        musicVolume = musicSlider.value;
    }

    public void CheckForSoundObjects() 
    {
        if (masterSlider == null)
        {
            masterSlider = GameObject.FindWithTag("MasterSlider").GetComponent<Slider>();
        }

        if (musicSlider == null)
        {
            musicSlider = GameObject.FindWithTag("MusicSlider").GetComponent<Slider>();
        }

        if (sfxSlider == null)
        {
            sfxSlider = GameObject.FindWithTag("sfxSlider").GetComponent<Slider>();
        }

        if (music == null)
        {
            music = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        }
    }
}
