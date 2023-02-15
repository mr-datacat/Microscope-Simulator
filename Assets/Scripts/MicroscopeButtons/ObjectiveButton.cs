using UnityEngine;

public class ObjectiveButton : MicroscopeButton
{
    [SerializeField]
    GameObject objective;

    public void Start()
    {
        message = "Объектив - система линз, заключённая в металлическую оправу. " +
            "Объектив увеличивает изображение рассматриваемого предмета. " +
            "Степень увеличения указывается на оправе.";
    }

    override public void SetMaterial(Material material)
    {
        objective.GetComponent<Renderer>().material = material;
    }
}
