using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform levelPanel;
    public CanvasGroup bg;

    public void OpenPanel()
    {
        //levelPanel.gameObject.SetActive(true);

        bg.alpha = 0;
        bg.LeanAlpha(1, 0.5f);
        levelPanel.localPosition = new Vector2(0, -Screen.height);
        levelPanel.LeanMoveLocalY(0, 0.7f).setEaseOutExpo().delay = 0.1f;
    }
    public void ClosePanel()
    {

        bg.LeanAlpha(0, 0.5f);
        levelPanel.LeanMoveLocalY(-Screen.height*2.5f, 0.7f).setEaseOutSine();
        //levelPanel.gameObject.SetActive(false);
        //levelPanel.gameObject.SetActive(false);
    }
    

}
