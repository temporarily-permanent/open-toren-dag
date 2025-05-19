using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A script that plays music based on the selected item in a dropdown menu.
/// </summary>
public class Interactivity : MonoBehaviour
{
    /// <summary>
    /// A list of audio clips that contain the organ music.
    /// </summary>
    [SerializeField] private List<AudioClip> organMusic;

    /// <summary>
    /// The AudioSource component used to play the music.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// The Dropdown component that is used to select the music.
    /// </summary>
    private Dropdown dropdown;

    /// <summary>
    /// Called when the script is initialized. Finds the Dropdown component.
    /// </summary>
    void Start()
    {
        dropdown = GameObject.Find("Dropdown").GetComponent<Dropdown>();
    }

    /// <summary>
    /// Called every frame. Plays the music based on the selected item in the dropdown.
    /// </summary>
    void Update()
    {
        PlayMusic();
    }

    /// <summary>
    /// Plays the music based on the selected item in the dropdown.
    /// </summary>
    private void PlayMusic()
    {
        int value = dropdown.value;
        if (audioSource == null || audioSource.clip != organMusic[value])
        {
            if (audioSource != null)
            {
                audioSource.Stop();
            }
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
            audioSource.clip = organMusic[value];
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}