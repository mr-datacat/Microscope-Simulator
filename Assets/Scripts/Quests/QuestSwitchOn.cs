using UnityEngine;

class QuestSwitchOn : MonoBehaviour
{
    [SerializeField] GameObject nextQuest;
    
    public void Start()
    {
        MessageBox.instance.Text = "Включите микроскоп";
    }

    public void Update()
    {        
        if (!Input.GetMouseButton(0))
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
        if (hitObject.name == "MicroscopeButton")
        {
            hitObject.GetComponent<Animator>().SetTrigger("Play");
            Instantiate(nextQuest);
            Destroy(this.gameObject);
        }
    }
}

