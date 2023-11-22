using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OpenUpUIObject(transform);
    }

    // Update is called once per frame
    public void OpenUpUIObject(Transform transform)
    {

        transform.localPosition = new Vector2(0, -Screen.height);
        transform.LeanMoveLocalY(-140, 0.6f).setEaseOutBack();
    }
}
