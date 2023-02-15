using UnityEngine;
using TMPro;

public class CellSizeGrid : MonoBehaviour
{
    public void Clear()
    {
        foreach (Transform group in transform)
        {
            foreach (Transform obj in group.transform)
            {
                obj.GetComponent<TMP_InputField>().text = "";
            }
        }
    }
}
