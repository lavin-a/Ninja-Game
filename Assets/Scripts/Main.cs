using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StarterAssets
{
    public class Main : MonoBehaviour
    {
        // Runs before a scene gets loaded
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void LoadMain()
        {
            GameObject main = GameObject.Instantiate(Resources.Load("Main")) as GameObject;
            GameObject.DontDestroyOnLoad(main);
            SceneManager.LoadScene("LevelSelect", LoadSceneMode.Additive);
        }

        public static void LevelSwitch(Collider Collided, AudioSource source, StarterAssetsInputs input)
        {
            if (Collided.gameObject.CompareTag("Level"))
            {
                ThirdPersonController.charPos = Collided.transform.position;
                ThirdPersonController.charRot = Collided.transform.rotation;
                source.Stop();
                source.clip = (AudioClip)Resources.Load("Music/" + Collided.gameObject.name + " Music", typeof(AudioClip));
                source.Play();
                RenderSettings.skybox = (Material)Resources.Load("Skyboxes/" + Collided.gameObject.name + " Skybox", typeof(Material));
                GameObject.Find("DynamicFog").GetComponent<Renderer>().material = (Material)Resources.Load("Fog/" + Collided.gameObject.name + " Fog", typeof(Material));
                //RenderSettings.fogColor = new Color(0.56f, 0.2f, 0.2f, 1f);
                Collided.enabled = false;
            }
            if (Collided.gameObject.CompareTag("Reset"))
            {
                input.reset = true;
            }
        }
        // You can choose to add any "Service" component to the Main prefab.
        // Examples are: Input, Saving, Sound, Config, Asset Bundles, Advertisements
    }
}