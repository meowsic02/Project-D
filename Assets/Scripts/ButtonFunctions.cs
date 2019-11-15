using TMPro;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public TextMeshProUGUI TMPugui;

    public void OnPointerEnter()
    {
        TMPugui.color = new Color32(255, 255, 0, 255);
    }
    public void OnPointerExit()
    {
        TMPugui.color = new Color32(255, 255, 255, 255);
    }
    public void QuitButtonClick()
    {
        Debug.Log("QuitButton Click");
    }
    public void OptionsButtonClick()
    {
        Debug.Log("OptionsButton Click");
    }
    public void ExitButtonClick()
    {
        Debug.Log("ExitButton Click");
    }
}
