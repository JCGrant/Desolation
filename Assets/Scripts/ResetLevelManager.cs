using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevelManager : MonoBehaviour {
	
    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
