using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLAY : MonoBehaviour {
    
	void Start () {
	}
	void Update () {
	}

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }
}
