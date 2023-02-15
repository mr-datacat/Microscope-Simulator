using UnityEngine;

public class AboutBoxSwitch : MonoBehaviour
{    
    [SerializeField] GameObject aboutBox;
    
    public void Switch()
    {
        if (!aboutBox.activeSelf)
        {
            aboutBox.SetActive(true);
        }
        else
        {
            aboutBox.SetActive(false);
        }
    }
}
