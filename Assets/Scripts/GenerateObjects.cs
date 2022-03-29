using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour
{
    public GameObject[] objects;
    public int ObjectsToGenerate = 500;
    int Objects = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        List<Vector3> usedLocations = new();
        while (Objects <= ObjectsToGenerate)
        {
            Vector3 position = new(Random.Range(20, 80), Random.Range(0, 50), Random.Range(0, 5000));
            Vector3 position2 = new(Random.Range(-15, -75), Random.Range(0, 50), Random.Range(0, 5000));
            Quaternion rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
            if (usedLocations.Contains(position) || usedLocations.Contains(position2))
            {
                break;
            }
            Instantiate(objects[Random.Range(0, objects.Length)], position, rotation);
            Instantiate(objects[Random.Range(0, objects.Length)], position2, rotation);
            yield return new WaitForSeconds(0.01f);
            Objects += 2;
            usedLocations.Add(position);
            usedLocations.Add(position2);
        }
    }
}
