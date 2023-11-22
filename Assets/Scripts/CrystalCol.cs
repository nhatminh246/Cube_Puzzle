using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalCol : MonoBehaviour
{
    public UIManager uiMangager;
    public GameObject destroyCrystal;
    public SoundsManager sounds;

    // Start is called before the first frame update
    void Start()
    {
        uiMangager = FindObjectOfType<UIManager>();
        sounds = FindObjectOfType<SoundsManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            uiMangager.WinGame();

            CameraShake camera = Camera.main.GetComponent<CameraShake>();
            camera.ResetShakeDuration();
            sounds.PlayOneShotAudioWin();
            Destroy(Instantiate(destroyCrystal, transform.position, Quaternion.identity), 1f);

            Destroy(transform.gameObject);
        }
    }
}
