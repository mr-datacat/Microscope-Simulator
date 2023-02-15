using UnityEngine;

public class TableBox : MonoBehaviour
{
    [SerializeField] GameObject tableButton;

    void Start()
    {
        gameObject.SetActive(true);
    }

    public void Switch()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.transform.SetAsLastSibling();
            tableButton.transform.SetAsLastSibling();
            gameObject.SetActive(true);
        }
        else
        {
            tableButton.transform.SetSiblingIndex(4);
            tableButton.transform.SetSiblingIndex(5);
            gameObject.SetActive(false);
        }
    }
}
