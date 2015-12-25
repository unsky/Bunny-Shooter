using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject enemyPrefab;
    public float spawnTime = 3;
    private float timer = 0;

    void Start() {
        InvokeRepeating("ACC", 0, 1);
    }

    void ACC() {
        spawnTime -= 0.05f;
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= spawnTime) {
            timer -= spawnTime;
            SpawnEnemy();
        }
    }

    void SpawnEnemy() {
        GameObject.Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

}
