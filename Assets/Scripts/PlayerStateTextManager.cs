using UnityEngine;
using UnityEngine.UI;

public class PlayerStateTextManager : MonoBehaviour {

    private Text playerStateText;
    private static PlayerController playerController;

    public static void SetPlayerController(PlayerController pc) {
        playerController = pc;
    }

	void Start () {
        playerStateText = GetComponent<Text>();
	}
	
	void Update () {
        playerStateText.text = "Thrust Points: " + playerController.thrustPoints.ToString();
	}
}