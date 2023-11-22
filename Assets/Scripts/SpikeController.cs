using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject engineSpike;
    public GameObject hurtPlayer;
    public UIManager uIManager;
    private bool isOnSpike = false;
    public bool isFixed = false;
    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    public void SpikeUp()
    {
        LeanTween.moveLocal(engineSpike.gameObject, new Vector3(0f,1.5f,0f), 0.15f);
    }
    public void SpikeDown()
    {
        LeanTween.moveLocal(engineSpike.gameObject, new Vector3(0f, -1.25f, 0f), 0.15f);

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Test");
        if(other.gameObject.tag == "Player")
        {
            isOnSpike = true;
            StartCoroutine(CheckSpikeAfterDelay());
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isOnSpike = false;
            StopAllCoroutines();
        }

    }
    private IEnumerator CheckSpikeAfterDelay()
    {
        //Debug.Log("GGGGGGGGGGGGGGGG");
        yield return new WaitForSeconds(0.225f); // Chờ 0.5 giây

        if (isOnSpike)
        {
            StepManager stepManager = FindObjectOfType<StepManager>().GetComponent<StepManager>();
            stepManager.StepMinus();
            SoundsManager sounds = FindObjectOfType<SoundsManager>();
            sounds.PlayOneShotAudioSpikeDamage();
            Camera.main.GetComponent<CameraShake>().Shake();
            Destroy(Instantiate(hurtPlayer, transform.position, Quaternion.identity), 1f);
            if(stepManager.numberStep <= 0 && GameObject.FindGameObjectWithTag("Crystal")!=null)
            {
                Debug.Log(GameObject.FindGameObjectWithTag("Crystal").name);
                Debug.Log("Lossse");
                uIManager.LoseGame();
            
            }
            //Debug.Log("CCCCC");
        }
    }

}
