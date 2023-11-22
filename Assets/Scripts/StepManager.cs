using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StepManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text stepText;
    UIManager uIManager;

    public int numberStep = 0; // Biến số lưu trữ điểm số

    private void Start()
    {
        uIManager = FindAnyObjectByType<UIManager>();
        UpdateStepText(); // Cập nhật hiển thị điểm số ban đầu
    }

    public void StepMinus()
    {
        numberStep--; // Cộng thêm điểm vào biến score
        uIManager.ZoomInUIObject(stepText.transform);
        UpdateStepText(); // Cập nhật hiển thị điểm số mới
        
    }

    private void UpdateStepText()
    {
        stepText.text = "" + numberStep.ToString(); // Cập nhật Text hiển thị điểm số
    }

    // Update is called once per frame
}
