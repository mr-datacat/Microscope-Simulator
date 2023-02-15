using UnityEngine;
using UnityEngine.UI;

public class QuestTable : MonoBehaviour
{
    void Start()
    {
        GameObject
            .Find("Canvas").transform
            .Find("TableButton").GetComponent<Button>()
            .gameObject.SetActive(true);
        MessageBox.instance.Text = "Рассмотрите все микропрепараты и заполните таблицу";
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit))
        {
            return;
        }

        GameObject hitObject = hit.collider.gameObject;
        if (hitObject.tag == "Preparation")
        {
            PreparationController.Active = hitObject;
            PreparationController.SetImage();
        }
    }
}
