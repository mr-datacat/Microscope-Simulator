using UnityEngine;

public class RevolverButton : MicroscopeButton
{
    [SerializeField]
    GameObject revolver;

    public void Start()
    {
        message = "Револьвер позволяет менять и закреплять объективы с разной степенью увеличения.";
    }

    override public void SetMaterial(Material material)
    {
        revolver.GetComponent<Renderer>().material = material;
    }
}
