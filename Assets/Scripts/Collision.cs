using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private GameObject destroyEF;
    private void OnMouseDown()
    {
        //Debug.Log(gameObject.name);
        Destroy(Instantiate(destroyEF, transform.position, Quaternion.identity), 1f);
        Destroy(gameObject);
    }
}
