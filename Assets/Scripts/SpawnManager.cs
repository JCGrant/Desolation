using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject playerPrefab;
    public Transform playerSpawn;

    void Start() {
        Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);
    }
}