using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class QuestMacroscrews : MonoBehaviour
{
    [SerializeField] Image preparationImage;
    [SerializeField] GameObject nextQuest;
    
    Image image;
    Stack<Sprite> leafSprites;
    Stack<string> animationTriggers;
    List<Animator> animators;

    void Start()
    {
        GameObject
            .Find("Canvas").transform
            .Find("ViewButton").GetComponent<Button>()
            .gameObject.SetActive(true);
        
        image = Instantiate(preparationImage);
        image.transform.SetParent(GameObject.Find("Canvas").transform, false);
        image.transform.SetAsFirstSibling();
        image.sprite = Resources.Load<Sprite>("Images/Leaf/violet_leaf_7");
        
        leafSprites = new Stack<Sprite>();
        leafSprites.Push(Resources.Load<Sprite>("Images/Leaf/violet_leaf_4"));
        leafSprites.Push(Resources.Load<Sprite>("Images/Leaf/violet_leaf_5"));
        leafSprites.Push(Resources.Load<Sprite>("Images/Leaf/violet_leaf_6"));

        animationTriggers = new Stack<string>();
        animationTriggers.Push("180deg");
        animationTriggers.Push("120deg");
        animationTriggers.Push("60deg");

        animators = GameObject
                    .FindGameObjectsWithTag("Macroscrew")
                    .Select(obj => obj.GetComponent<Animator>())
                    .ToList();
        
        MessageBox.instance.Text = "Отрегулируйте чёткость изображения макровинтами";
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
        if (hitObject.name == "RightMacroscrew" || hitObject.name == "LeftMacroscrew")
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
