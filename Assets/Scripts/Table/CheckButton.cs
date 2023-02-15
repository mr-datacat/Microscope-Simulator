using UnityEngine;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{
    [SerializeField] GameObject _objectGrid;
    [SerializeField] Image _resultImage;

    public void Check()
    {
        foreach (Transform child in _objectGrid.transform)
        {
            var draggable = child.GetComponentInChildren<Draggable>();
            var slot = child.GetComponent<PreparationSlot>();
            if (draggable == null || draggable.preparationObject != slot.preparationObject)
            {
                _resultImage.gameObject.SetActive(true);
                _resultImage.sprite = Resources.Load<Sprite>("Images/no_check");
                return;
            }
        }
        _resultImage.gameObject.SetActive(true);
        _resultImage.sprite = Resources.Load<Sprite>("Images/yes_check");
    }
}
