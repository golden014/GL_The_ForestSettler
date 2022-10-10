using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LoaderScript : MonoBehaviour
{
    //public GameObject a;
    public GameObject loadingScreen;
    public Slider slider;

    public void loadLevel(int idx)
    {
        StartCoroutine(Loadasynchronously(idx));
    }

    IEnumerator Loadasynchronously (int idx)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(idx);

       // a.SetActive(false);
        loadingScreen.SetActive(true);
       // Debug.Log(operation.progress);
      //  Debug.Log("aaaaaaaaa");

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }

    }
}
