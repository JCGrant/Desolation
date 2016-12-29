using UnityEngine;
using UnityEngine.UI;

public class GameTextManager : MonoBehaviour {

    public Text playerStateText;
    public Text winText;

    private static GameObject player;
    private static PlayerController playerController;

    void Update () {
        if (playerController == null) {
            playerController = FindObjectOfType<PlayerController>();
            return;
        }
        playerStateText.text = "Thrust Points: " + playerController.thrustPoints.ToString();
        winText.gameObject.SetActive(playerController.hasWon);
    }
}
