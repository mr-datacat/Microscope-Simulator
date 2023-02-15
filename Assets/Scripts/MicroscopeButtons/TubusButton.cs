using UnityEngine;

public class TubusButton : MicroscopeButton
{
    [SerializeField]
    GameObject tubus;

    public void Start()
    {
        message = "Тубус проводит свет между основными оптическими деталями – окуляром и объективом.";
    }

    override public void SetMaterial(Material material)
    {
        tubus.GetComponent<Renderer>().material = material;
    }
}
