using UnityEngine;

public class MicroscopeButtonsSwitch : MonoBehaviour
{
    public GameObject microscopeButtons;

    public void Switch()
    {
        if (!microscopeButtons.activeSelf)
        {
            microscopeButtons.SetActive(true);
        }
        else
        {
            microscopeButtons.SetActive(false);
        }
    }
}
