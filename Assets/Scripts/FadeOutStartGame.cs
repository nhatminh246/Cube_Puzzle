using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutStartGame : MonoBehaviour
{

    FadeInOut fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
        fade.FadeOut();
    }


}
