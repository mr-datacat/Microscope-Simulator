using UnityEngine;

public abstract class MicroscopeButton : MonoBehaviour
{
    [SerializeField] protected Material DefaultMaterial;
    [SerializeField] protected Material HighlightMaterial;
    protected string message;

   
    abstract public void SetMaterial(Material material);
    
    public virtual void PointerEnter()
    {
        SetMaterial(HighlightMaterial);
        MessageBox.instance.SaveText();
        MessageBox.instance.Text = message;
    }
    
    public virtual void PointerExit()
    {
        SetMaterial(DefaultMaterial);
        MessageBox.instance.LoadText();
    }
}
