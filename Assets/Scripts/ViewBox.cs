using UnityEngine;
using UnityEngine.UI;

public class ViewBox : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] GameObject aboutBoxSwitch;

    void Start()
    {
        gameObject.SetActive(true);
    }

    public void Switch()
    {
        if (!gameObject.activeSelf)
        {
            image.sprite = GameObject
                        .FindGameObjectWithTag("PreparationImage")
                        .GetComponent<Image>()
                        .sprite;
            aboutBoxSwitch.transform.SetSiblingIndex(4);
            gameObject.SetActive(true);
        }
        else
        {
            aboutBoxSwitch.transform.SetAsLastSibling();
            gameObject.SetActive(false);
        }
    }
}
