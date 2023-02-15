using UnityEngine;

public class OcularsButton : MicroscopeButton
{ 
    [SerializeField]
    GameObject leftOcularTop;
    
    [SerializeField]
    GameObject leftOcularBottom;
    
    [SerializeField]
    GameObject rightOcularTop;
    
    [SerializeField]
    GameObject rightOcularBottom;

    [SerializeField]
    GameObject ocularsTube;

    public void Start()
    {
        message = "Окуляр нужен для увеличения изображения, которое даёт объектив. " +
            "Состоит из двух линз, заключённых в оправу.";
    }

    override public void SetMaterial(Material material)
    {
        leftOcularTop.GetComponent<Renderer>().material = material;
        leftOcularBottom.GetComponent<Renderer>().material = material;
        rightOcularTop.GetComponent<Renderer>().material = material;
        rightOcularBottom.GetComponent<Renderer>().material = material;
        ocularsTube.GetComponent<Renderer>().material = material;
    }
}
