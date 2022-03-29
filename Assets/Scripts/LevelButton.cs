using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class LevelButton : MonoBehaviour
{
    public GameObject character;
    public GameObject level;
    [HideInInspector] public int levelNum;
    public TextMeshProUGUI buttonText;
    string levelNumStr;
    // Start is called before the first frame update
    void Start()
    {   
        Cursor.lockState = CursorLockMode.Confined;
        /*levelNumStr = buttonText.text.Remove(0, 5);
        levelNum = int.Parse(levelNumStr);*/
        levelNumStr = buttonText.text;
    }

    public void LoadLevel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        character = GameObject.FindGameObjectWithTag("Player");
        level = GameObject.Find(levelNumStr);
        if (character != null && level != null)
        {
            level.GetComponent<Collider>().enabled = true;
            character.transform.position = level.transform.position;
        }
        SceneManager.UnloadSceneAsync("LevelSelect");
        StarterAssets.ThirdPersonController.pauseState = false;
        Physics.SyncTransforms();
    }
}