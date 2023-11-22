using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseInOutObject : MonoBehaviour
{
    // Start is called before the first frame update
    public CameraShake cameraShake;
    void Start()
    {
        cameraShake = GetComponent<CameraShake>();
        ChangeYPossition();
        EaseInSmooth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeYPossition()
    {
        if (gameObject.tag == "MainCamera")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        }
        else transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
    }
    void EaseInSmooth()
    {
        if (gameObject.tag == "MainCamera")
        {
            LeanTween.moveLocal(transform.gameObject, transform.localPosition + new Vector3(0, -10, 0), 0.6f).setEaseOutBack().setOnComplete(() =>
            {
                cameraShake.enabled = true;
            });
            
        }
        else
        {
            LeanTween.moveLocal(transform.gameObject, transform.localPosition + new Vector3(0, 10, 0), 0.6f).setEaseOutBack();
        }

        }
    }
