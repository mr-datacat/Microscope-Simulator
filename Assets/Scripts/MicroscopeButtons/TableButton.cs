using UnityEngine;

public class TableButton : MicroscopeButton
{
    [SerializeField]
    GameObject table;

    public void Start()
    {
        message = "На предметном столике размещают микропрепараты. " +
            "Держатели закрепляют микропрепарат в неподвижном положении.";
    }

    override public void SetMaterial(Material material)
    {
        table.GetComponent<Renderer>().material = material;
    }
}
