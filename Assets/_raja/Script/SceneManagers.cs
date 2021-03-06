using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string nameDirectScene;
    public void GoToScene(string sceneName) {
        nameDirectScene = sceneName;
        Resources.UnloadUnusedAssets();
        System.GC.Collect();

        Invoke("ChangeScene", 1);
    }
    public void ChangeScene() {

        //StartCoroutine("LoadYourAsyncScene");
        SceneManager.LoadScene(nameDirectScene);
    }
    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nameDirectScene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
