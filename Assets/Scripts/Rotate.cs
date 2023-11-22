using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 10f; // Tốc độ xoay

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime); // Xoay theo trục Y
    }
}
