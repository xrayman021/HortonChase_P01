using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInput : MonoBehaviour
{
    [SerializeField] AudioClip _backgroundMusic;
    private AudioSource Audio;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ReloadLevel();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void ReloadLevel()
    {
        int activeSceneIndex =
            SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }

    // Start is called before the first frame update
    void Awake()
    {
        Audio = GetComponent<AudioSource>();
        Audio.clip = _backgroundMusic;
        Audio.loop = true;
        Audio.Play();
    }



}