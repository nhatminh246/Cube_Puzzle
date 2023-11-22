using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform controller;
    public Transform endGameMenu;
    public Transform loseText;
    public Transform loseMenu;
    public Transform winText;
    public Transform winMenu;
    public Transform stepText;
    private void Awake()
    {
        OpenController();
        OpenDownUIObject(stepText);
    }
    public void OpenController()
    {
        controller.localPosition = new Vector2(0, -Screen.height);
        controller.LeanMoveLocalY(-450f, 0.3f).setEaseOutExpo().delay = 0.1f;
    }
    public void CloseController()
    {

        controller.LeanMoveLocalY(-Screen.height * 2f, 0.5f).setEaseInExpo();
    }

    public void OpenDownUIObject(Transform transform)
    {

        transform.localPosition = new Vector2(0, Screen.height);
        transform.LeanMoveLocalY(700f, 0.3f).setEaseOutExpo().delay = 0.1f;
    }
    public void OpenUpUIObject(Transform transform)
    {

        transform.localPosition = new Vector2(0, -Screen.height);
        transform.LeanMoveLocalY(-450f, 0.3f).setEaseOutExpo().delay = 0.1f;
    }
    public void CloseUpUIObject(Transform transform)
    {

        transform.LeanMoveLocalY(Screen.height * 2f, 0.5f).setEaseInExpo();
    }
    public void CloseDownUIObject(Transform transform)
    {

        transform.LeanMoveLocalY(-Screen.height * 2f, 0.5f).setEaseInExpo();
    }

    public void ZoomInUIObject(Transform transform)
    {
        transform.localScale = new Vector2(1.5f,1.5f);
        transform.LeanScale(Vector2.one, 0.2f);
    }

    public void WinGame()
    {
        CloseController();
        OpenDownUIObject(winText);
        OpenUpUIObject(winMenu);
        CloseUpUIObject(stepText);
    }
    public void LoseGame()
    {
        CloseController();
        OpenDownUIObject(loseText);
        OpenUpUIObject(loseMenu);
        CloseUpUIObject(stepText);

    }

}
