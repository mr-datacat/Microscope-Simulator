using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using TMPro;

public class AverageCellSize : MonoBehaviour
{
    public GameObject fieldsGroup;
    public TMP_Text value;
    List<TMP_InputField> fields = new List<TMP_InputField>();

    void Start()
    {
        foreach (Transform child in fieldsGroup.transform)
        {
            TMP_InputField inputField = child.gameObject.GetComponent<TMP_InputField>();
            inputField.onValueChanged.AddListener(delegate { SetValue(); }); 
            fields.Add(inputField);
        }
    }

    void SetValue()
    {
        if (!fields.All(field => field.text != ""))
        {
            value.text = "";
            return;
        }

        float sum = 0;
        try
        {
            foreach (var field in fields)
            {
                sum += float.Parse(field.text, CultureInfo.InvariantCulture.NumberFormat);
            }
            value.text = (sum / fields.Count).ToString();
        }
        catch
        {
            value.text = "ОШИБКА";
        }
    }
}
