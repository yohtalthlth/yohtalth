using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LodingScene : MonoBehaviour
{
    public static string nextScene;
    [SerializeField] Image LodingBar;
    // Start is called before the first frame update
    void Start()
    {
        LodingBar.fillAmount = 0;
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("LodingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync("Stage1");
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while(!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if (op.progress >= 0.9f)
            {
                LodingBar.fillAmount = Mathf.Lerp(LodingBar.fillAmount, 1, timer);
                if (LodingBar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                }
            }
            else
            {
                LodingBar.fillAmount = Mathf.Lerp(LodingBar.fillAmount, op.progress, timer);
                if (LodingBar.fillAmount >= op.progress)
                {
                    timer = 0.0f;
                }
            }
        }
    }
}
