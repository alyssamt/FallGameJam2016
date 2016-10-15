using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    public void LoadGame ()
    {
        SceneManager.LoadScene("Main Scene");
    }
}
