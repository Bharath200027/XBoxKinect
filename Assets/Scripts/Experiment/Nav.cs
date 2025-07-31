using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nav : MonoBehaviour
{
    private void Awake()
    {
        //DontDestroyOnLoad(this);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name != "WelcomeScene 1" && SceneManager.GetActiveScene().name != "LanguageSelect" && SceneManager.GetActiveScene().name != "WelcomeSceneHindi")
            {
                if(Utils.langMode== Utils.LanguageMode.English)
                    GoToScene("WelcomeScene 1");
                else
                    GoToScene("WelcomeSceneHindi");

            }
                
            else
                GoToScene("LanguageSelect");
        }
    }

    public void GoToScene( string sceneName)
    {
        StartCoroutine(DelayGoToScene(sceneName));
    }

    public IEnumerator DelayGoToScene(string sceneName)
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(sceneName);
    }

    public void SetLangMode(int i)
    {
        if(i==0)
            Utils.langMode = Utils.LanguageMode.English;
        else
            Utils.langMode = Utils.LanguageMode.Hindi;

        if (Utils.langMode == Utils.LanguageMode.English)
            GoToScene("WelcomeScene 1");
        else
            GoToScene("WelcomeSceneHindi");

    }
}
