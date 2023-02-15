using UnityEngine;

public class StandButton : MicroscopeButton
{
    [SerializeField]
    GameObject stand;

    public void Start()
    {
        message = "Штатив является опорой, на которую крепятся оптические элементы микроскопа.";
    }

    override public void SetMaterial(Material material)
    {
        stand.GetComponent<Renderer>().material = material;
    }
}
