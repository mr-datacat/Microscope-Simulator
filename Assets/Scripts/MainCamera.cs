using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
    Transform target;
    [SerializeField]
    Transform revolver;
    [SerializeField]
    Transform objective;
    [SerializeField]
    Transform table;
    [SerializeField]
    Transform oculars;
    [SerializeField]
    Transform tubus;
    [SerializeField]
    Transform stand;
    [SerializeField]
    Transform lighter;
    [SerializeField]
    Transform screws;
    
    Vector3 revolverCameraPosition = new Vector3(-2.019547f, 9.633814f, -0.36f);
    Quaternion revolverCameraRotation = Quaternion.Euler(0.17f, 89.984f, 0f);
    Vector3 objectiveCameraPosition = new Vector3(-4.019539f, 9.639748f, -0.36f);
    Quaternion objectiveCameraRotation = Quaternion.Euler(0.17f, 89.984f, 0f);
    Vector3 tableCameraPosition = new Vector3(-1.619844f, 10f, -0.36f);
    Quaternion tableCameraRotation = Quaternion.Euler(29.57f, 89.984f, 0f);
    Vector3 ocularsCameraPosition = new Vector3(-3.677479f, 11.45534f, -0.36f);
    Quaternion ocularsCameraRotation = Quaternion.Euler(21.17f, 89.984f, 0f);
    Vector3 tubusCameraPosition = new Vector3(0.4989812f, 11.45534f, -4.224718f);
    Quaternion tubusCameraRotation = Quaternion.Euler(21.17f, 0f, 0f);
    Vector3 standCameraPosition = new Vector3(2.5f, 9.6f, -5.137942f);
    Quaternion standCameraRotation = Quaternion.Euler(7.17f, 0f, 0f);
    Vector3 lighterCameraPosition = new Vector3(-1.976102f, 9f, -0.36f);
    Quaternion lighterCameraRotation = Quaternion.Euler(14.87f, 89.984f, 0f);
    Vector3 screwsCameraPosition = new Vector3(2.2f, 9.1f, -5.137942f);
    Quaternion screwsCameraRotation = Quaternion.Euler(7.17f, 0f, 0f);

    bool isMoving = false;
    bool isFixed = false;
    
    const float scrollSpeed = 12f;
    const float moveSpeed = 0.06f;
    const int rotationSensivity = 10;
    const int maxDistance = 22;
    const int minDistance = 3;
    const int maxHeight = 5;
    const int minHeight = 0;
    const int maxAngle = 60;
    const int minAngle = 0;
 
    bool ControlDistance (float distance)
    {
        if (distance > minDistance && distance < maxDistance) 
        {
            return true;
        }
        return false;
    }
    
    bool ControlHeight (float height)
    {
        if (height > minHeight && height < maxHeight) 
        {
            return true;
        }
        return false;
    }

    void Start()
    {
        target = table;
        transform.LookAt(target);
    }

    void Update()
    {
        // Вертикальный наклон камеры
        if (Input.GetMouseButton(1) && !isFixed)
        {
            float angle = Input.GetAxis("Mouse Y") * rotationSensivity;
            if (transform.rotation.eulerAngles.x + angle > minAngle && transform.rotation.eulerAngles.x + angle < maxAngle)
            {
                transform.RotateAround(target.position, transform.right, angle);
            }
        }
        
        // Вращение камеры вокруг микроскопа клавишами
        float x = Input.GetAxis("Horizontal"); 
        if (x != 0 && !isFixed)
        {
            float angle = 1.25f;
            if (x > 0)
            {
                angle = -1 * angle;
            }
            transform.RotateAround(target.position, Vector3.up, angle);
        }

        // Приближение камеры колёсиком мыши
        if (Input.GetAxis("Mouse ScrollWheel") != 0 && !isFixed)
        {
            Vector3 newPos = transform.position + transform.TransformDirection(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * scrollSpeed);
            if (ControlDistance(Vector3.Distance(newPos, target.position))) 
            {
                transform.position = newPos;
            }
        }
    }

    private IEnumerator MoveTo(Transform newTarget, Vector3 needPosition, Quaternion needRotation)
    {
        if (!isMoving)
        {
            isMoving = true;
            target = newTarget;
            float offset = 0;
            Vector3 startPosition = transform.position;
            Quaternion startRotation = transform.rotation;
            while (offset < 1)
            {
                offset += moveSpeed;
                transform.position = Vector3.Lerp(startPosition, needPosition, offset);
                transform.rotation = Quaternion.Slerp(startRotation, needRotation, offset);
                yield return new WaitForSeconds(Time.fixedDeltaTime);
            }
            isMoving = false;
        }
    }

    public void MoveToRevolver()
    {
        IEnumerator coroutine = MoveTo(revolver, revolverCameraPosition, revolverCameraRotation);
        StartCoroutine(coroutine);
    }

    public void MoveToObjective()
    {
        IEnumerator coroutine = MoveTo(objective, objectiveCameraPosition, objectiveCameraRotation);
        StartCoroutine(coroutine);
    }

    public void MoveToTable()
    {
        IEnumerator coroutine = MoveTo(table, tableCameraPosition, tableCameraRotation);
        StartCoroutine(coroutine);
    }

    public void MoveToOculars()
    {
        IEnumerator coroutine = MoveTo(oculars, ocularsCameraPosition, ocularsCameraRotation);
        StartCoroutine(coroutine);
    }

    public void MoveToTubus()
    {
        IEnumerator coroutine = MoveTo(tubus, tubusCameraPosition, tubusCameraRotation);
        StartCoroutine(coroutine);
    }

    public void MoveToStand()
    {
        IEnumerator coroutine = MoveTo(stand, standCameraPosition, standCameraRotation);
        StartCoroutine(coroutine);
    }

    public void MoveToLighter()
    {
        IEnumerator coroutine = MoveTo(lighter, lighterCameraPosition, lighterCameraRotation);
        StartCoroutine(coroutine);
    }

    public void MoveToScrews()
    {
        IEnumerator coroutine = MoveTo(screws, screwsCameraPosition, screwsCameraRotation);
        StartCoroutine(coroutine);
    }

}
