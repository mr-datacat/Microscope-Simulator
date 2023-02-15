using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class QuestMicroscrews : MonoBehaviour
{
    [SerializeField] GameObject nextQuest;
    Image image;
    Stack<Sprite> leafSprites;
    Stack<string> animationTriggers;
    List<Animator> animators;

    void Start()
    {
        image = GameObject.FindGameObjectWithTag("PreparationImage").GetComponent<Image>();

        leafSprites = new Stack<Sprite>();
        leafSprites.Push(Resources.Load<Sprite>("Images/leaf"));
        leafSprites.Push(Resources.Load<Sprite>("Images/Leaf/violet_leaf_2"));
        leafSprites.Push(Resources.Load<Sprite>("Images/Leaf/violet_leaf_3"));

        animationTriggers = new Stack<string>();
        animationTriggers.Push("180deg");
        animationTriggers.Push("120deg");
        animationTriggers.Push("60deg");

        animators = GameObject
                    .FindGameObjectsWithTag("Microscrew")
                    .Select(obj => obj.GetComponent<Animator>())
                    .ToList();

        MessageBox.instance.Text = "Теперь используйте микровинты";
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit))
        {
            return;
        }

        GameObject hitObject = hit.collider.gameObject;
        if (hitObject.name == "RightMicroscrew" || hitObject.name == "LeftMicroscrew")
        {
            image.sprite = leafSprites.Pop();

            string trigger = animationTriggers.Pop();
            animators.ForEach(anim => anim.SetTrigger(trigger));

            if (leafSprites.Count == 0)
            {
                Instantiate(nextQuest);
                Destroy(this.gameObject);
            }
        }
    }
}
