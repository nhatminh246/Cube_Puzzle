using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;
    public int nextSceneLoad;

    public FadeInOut fade;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;

        fade = FindObjectOfType<FadeInOut>();
        int levelAt = PlayerPrefs.GetInt("levelAt", 1); /* < Change this int value to whatever your
                                                             level selection build index is on your
                                                             build settings */

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > levelAt)
                lvlButtons[i].interactable = false;
        }
        
    }

    public void ChangeScene(int index)
    {
        StartCoroutine(ChangeScene_FadeIn(index));
    }

    public IEnumerator ChangeScene_FadeIn(int index)
    {
        fade.FadeIn();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(index);

    }
    public IEnumerator ChangeScene_FadeOut(int index)
    {
        fade.FadeOut();
        yield return new WaitForSeconds(0.5f);

    }
    public void NextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7) /* < Change this int value to whatever your
                                                                   last level build index is on your
                                                                   build settings */
        {
            Debug.Log("You Completed ALL Levels");

            //Show Win Screen or Somethin.
        }
        else
        {
            //Setting Int for Index
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
        StartCoroutine(ChangeScene_FadeIn(nextSceneLoad));
    }
    public void RestartScene()
    {
        StartCoroutine(ChangeScene_FadeIn(SceneManager.GetActiveScene().buildIndex));
    }
}
