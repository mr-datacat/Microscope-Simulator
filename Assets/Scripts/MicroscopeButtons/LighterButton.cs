using UnityEngine;

public class LighterButton : MicroscopeButton
{
    [SerializeField]
    Material lensMaterial;

    [SerializeField]
    GameObject lens;

    [SerializeField]
    GameObject stand;

    override public void SetMaterial(Material material)
    {
        lens.GetComponent<Renderer>().material = material;
        stand.GetComponent<Renderer>().material = material;
    }

    public override void PointerExit()
    {
        lens.GetComponent<Renderer>().material = lensMaterial;
        stand.GetComponent<Renderer>().material = DefaultMaterial;
    }
}
