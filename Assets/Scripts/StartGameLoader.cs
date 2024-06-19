using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameLoader : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Loader());
    }
    IEnumerator Loader()
    {
        yield return new WaitForSeconds(3f);

        AsyncOperation operationProgress = SceneManager.LoadSceneAsync(1);
    }

    
}
