using UnityEngine;

public class QuestPutLeaf : MonoBehaviour
{
    [SerializeField] GameObject nextQuest;

    void Start()
    {
        MessageBox.instance.Text = "Кликните на микропрепарат с номером 1, чтобы поместить его на предметный столик";
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
        if (hitObject.name == "leaf")
        {
            PreparationController.Active = hitObject;
            Instantiate(nextQuest);
            Destroy(this.gameObject);
        }
    }
}
