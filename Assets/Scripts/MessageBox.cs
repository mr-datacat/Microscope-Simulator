using UnityEngine;
using TMPro;

public class MessageBox : MonoBehaviour
{
    public static MessageBox instance = null;
   
    [SerializeField] TMP_Text tmp_text;
    string _savedText = "";

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    public string Text
    {
        get
        {
            return tmp_text.text;
        }
        set
        {
            tmp_text.text = value;
        }
    }

    public void SaveText()
    {
        _savedText = Text;
    }

    public void LoadText()
    {
        Text = _savedText;
    }
}
