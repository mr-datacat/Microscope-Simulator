using UnityEngine;

public class QuestButton : MonoBehaviour
{
    [SerializeField]
    GameObject questPrefab;   
    
    public void Click()
    {
        Instantiate(questPrefab);
        Destroy(this.gameObject);
    }
}
