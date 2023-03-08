using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] Asteroid asteroidPrefab;
    [SerializeField] GameObject pickupPrefab;
    [SerializeField] int numberOfAsteroidsPerAxis = 10;
    [SerializeField] int gridSpacing = 100;

    public List<Asteroid> asteroid = new List<Asteroid> ();

    void Start()
    {
 //       PlaceAsteroids();
    }

    void OnEnable()
    {
        EventManager.onStartGame += PlaceAsteroids;
        EventManager.onPlayerDeath += DestroyAsteroid;
        EventManager.onReSpawnPickUp += PlaceAsteroids;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= PlaceAsteroids;
        EventManager.onPlayerDeath -= DestroyAsteroid;
        EventManager.onReSpawnPickUp -= PlaceAsteroids;
    }

    void PlaceAsteroids()
    {
        for(int x = 0; x < numberOfAsteroidsPerAxis; x++)
        {
            for (int y = 0; y < numberOfAsteroidsPerAxis; y++)
            {
                for (int z = 0; z < numberOfAsteroidsPerAxis; z++)
                {
                    InstatiateAsteroid(x, y, z);
                }
            }
        }

        PlacepickUp();
    }

    void DestroyAsteroid()
    {
        foreach (Asteroid ast in asteroid)
            ast.SelfDestruct();

        asteroid.Clear();
    }

    void InstatiateAsteroid(int x, int y, int z)
    {
        Asteroid temp = Instantiate(asteroidPrefab, 
            new Vector3(  transform.position.x + (x * gridSpacing) + AsteroidOfset(), 
                          transform.position.y + (y * gridSpacing) + AsteroidOfset(), 
                          transform.position.z + (z * gridSpacing) + AsteroidOfset()), 
                    Quaternion.identity, 
                    transform) as Asteroid;
        temp.name = "Asteroid " + x + "-" + y + "-" + z;

        asteroid.Add(temp);
    }

    void PlacepickUp()
    {
        int randomAsteroid = Random.Range(0, asteroid.Count);

        Instantiate(pickupPrefab, asteroid[randomAsteroid].transform.position, Quaternion.identity);
        Debug.Log("Destroying: " + asteroid[randomAsteroid].name);
        Destroy(asteroid[randomAsteroid].gameObject);
        asteroid.RemoveAt(randomAsteroid);
    }

    float AsteroidOfset()
    {
        return Random.Range(-gridSpacing / 2f, gridSpacing / 2);
    }
}
