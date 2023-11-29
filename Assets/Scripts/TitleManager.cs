using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public string targetSceneName = "gps_scene"; // Change this to your target scene name
    public AudioClip backgroundMusic; // Assign your background music clip in the Unity Editor
    private AudioSource audioSource;

    void Start()
    {
        // Create an AudioSource component dynamically
        audioSource = gameObject.AddComponent<AudioSource>();

        // Assign the background music clip
        audioSource.clip = backgroundMusic;

        // Set the audio source to loop
        audioSource.loop = true;

        // Start playing the background music
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        // Check for screen touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Perform scene change logic
            ChangeScene();
        }
        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouse button
        {
            // Perform scene change logic
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
