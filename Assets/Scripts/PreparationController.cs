using UnityEngine;
using UnityEngine.UI;

public static class PreparationController
{
    private static readonly Vector3 _tablePosition = new Vector3(0.817f, 8.485f, -0.358f);
    private static Vector3 _activeDefaultPosition = new();
    private static GameObject _active = null;
    
    public static GameObject Active
    {
        get { return _active; }
        set
        {
            if (_active != null)
            {
                _active.transform.position = _activeDefaultPosition;
            }
            _activeDefaultPosition = value.transform.position;
            _active = value;
            _active.transform.position = _tablePosition;
        }
    }

    public static void SetImage()
    {
            Image image = GameObject.FindGameObjectWithTag("PreparationImage").GetComponent<Image>();
            Sprite sprite = Resources.Load<Sprite>($"Images/{_active.name}");
            image.sprite = sprite;
    }
}
