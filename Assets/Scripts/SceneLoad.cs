using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{

    [SerializeField] private int loadLevelNumber;

    public void LoadNextScene() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadSelectedLevel() {

        StartCoroutine("LoadDelay");
    }

    public IEnumerator LoadDelay() {
        yield return new WaitForSeconds (1);
        SceneManager.LoadScene(loadLevelNumber);
    }


}
