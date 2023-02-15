using UnityEngine;

public class ScrewsButton : MicroscopeButton
{
    [SerializeField]
    GameObject leftMacroscrew;

    [SerializeField]
    GameObject rightMacroscrew;

    [SerializeField]
    GameObject leftMicroscrew;

    [SerializeField]
    GameObject rightMicroscrew;

    public void Start()
    {
        message = "Винты фокусировки регулируют чёткость изображения. " +
            "Делятся на макро- и микровинты.";
    }

    override public void SetMaterial(Material material)
    {
        leftMacroscrew.GetComponent<Renderer>().material = material;
        rightMacroscrew.GetComponent<Renderer>().material = material;
        leftMicroscrew.GetComponent<Renderer>().material = material;
        rightMicroscrew.GetComponent<Renderer>().material = material;
    }
}
