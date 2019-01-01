//ORG: ghostyii & MOONLIGHTGAME
using UnityEngine;
using UnityEditor;
using MoonLightGame;

public class RotationController : MonoBehaviour
{
    public bool showDebugMes = false;

    public GameObject target;
    public RotationType mode;

    public float fixSpeed = 2.5f;
    public float freeSpeed = 2.5f;
    public bool fixHorizontal = false, fixVertical = false;
    public float sensitivity = 10;
    public float degree = 90f;

    [HideInInspector]
    public bool isStop = false;
    private Vector2 downPoint, upPoint;
    private Vector2 sen;
    private Direction dir;

    private Quaternion rot = Quaternion.identity, saveRot = Quaternion.identity;
    private Vector3 freeDelta = Vector3.zero;
    private bool isMoving = false;

    private void Start()
    {
        if (target == null)
        {
            MLLogger.Log("ERROR", "rotate target is null. [STOP WILL BE TRUE]");
            isStop = true;
        }
    }

    private void Update()
    {
        if (isStop)
            return;

        Vector3 center = target.transform.position;

        if (Input.GetMouseButtonDown(2))
        {
            rot = Quaternion.identity;
            saveRot = Quaternion.identity;
            target.transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        sen = new Vector2(sensitivity, sensitivity);
        switch (mode)
        {
            case RotationType.Fixed:
                if (Quaternion.Angle(target.transform.rotation, rot) > 0.5f && !isMoving)
                {
                    isMoving = true;
                    target.transform.rotation = Quaternion.RotateTowards(target.transform.rotation, rot, Time.deltaTime * fixSpeed * 100);
                }
                else if (!isMoving)
                {
#if UNITY_STANDALONE
                    if (Input.GetMouseButtonDown(1))
                    {
                        if (target.transform.childCount == 0)
                            center = Vector2.zero;
                        else
                            center = GetCenterPos(target.transform);
                        downPoint = Input.mousePosition;
                    }

                    if (Input.GetMouseButtonUp(1))
                    {
                        upPoint = Input.mousePosition;
                        if (ControlUtility.GetDirection(downPoint, upPoint, sen).HasValue)
                        {
                            dir = ControlUtility.GetDirection(downPoint, upPoint, sen).Value;

                            if ((fixHorizontal && dir == Direction.Left) || (fixHorizontal && dir == Direction.Right))
                                return;
                            if ((fixVertical && dir == Direction.Up) || (fixVertical && dir == Direction.Down))
                                return;

                            saveRot = target.transform.rotation;
                            target.transform.RotateAround(center, dir.ToRatateAxis(), degree);
                            rot = target.transform.rotation;
                            target.transform.rotation = saveRot;
                        }
                    }

                }
#elif UNITY_IOS || UNITY_ANDROID
                Touch t = Input.GetTouch(0);
                if (t.phase == TouchPhase.Began)
                    downPoint = t.position;
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    upPoint = t.position;
                    if (ControlUtility.GetDirection(downPoint, upPoint, sen).HasValue)
                    {
                        dir = ControlUtility.GetDirection(downPoint, upPoint, sen).Value;
                        saveRot = target.transform.rotation;
                        target.transform.RotateAround(target.transform.position, dir.ToRatateAxis(), degree);
                        rot = target.transform.rotation;
                        target.transform.rotation = saveRot;
                    }
                }
#endif
                isMoving = false;
                break;
            case RotationType.Free:
                if (!fixVertical)
                    freeDelta.x = Input.GetAxis("Mouse Y");
                if (!fixHorizontal)
                    freeDelta.y = -Input.GetAxis("Mouse X");
                if (Input.GetMouseButtonDown(1))
                {
                    if (target.transform.childCount == 0)
                        center = Vector2.zero;
                    else
                        center = GetCenterPos(target.transform);
                }
                if (Input.GetMouseButton(1))
                    target.transform.RotateAround(center, freeDelta, Time.deltaTime * freeSpeed * 100);
                //target.transform.Rotate(freeDelta, Time.deltaTime * freeSpeed * 100, Space.World);

                break;
            default:
                MLLogger.Log("rotate mode is invail");
                break;
        }

    }

    private Vector3 GetCenterPos(Transform t)
    {
        Transform parent = t;
        Vector3 postion = parent.position;
        Quaternion rotation = parent.rotation;
        Vector3 scale = parent.localScale;

        parent.position = Vector3.zero;
        parent.rotation = Quaternion.Euler(Vector3.zero);
        parent.localScale = Vector3.one;

        Vector3 center = Vector3.zero;
        Renderer[] renders = parent.GetComponentsInChildren<Renderer>();

        foreach (Renderer child in renders)
            center += child.bounds.center;


        center /= parent.GetComponentsInChildren<Renderer>().Length;
        Bounds bounds = new Bounds(center, Vector3.zero);
        foreach (Renderer child in renders)
            bounds.Encapsulate(child.bounds);

        parent.position = postion;
        parent.rotation = rotation;
        parent.localScale = scale;

        foreach (Transform item in parent)
            item.position = item.position - bounds.center;

        parent.transform.position = bounds.center + parent.position;
        return parent.transform.position;

    }

    private void OnGUI()
    {
        if (!showDebugMes)
            return;

        switch (mode)
        {
            case RotationType.Free:
                Vector3 pos = Vector3.zero;
                if (Input.GetMouseButton(1))
                    pos = new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0);
                GUI.Label(new Rect(0, 0, 200, 150), "type:" + mode.ToString() + "\npos:" + pos.ToString() + "\nfixed horizontal:" + fixHorizontal + "\nfixed vertical:" + fixVertical + "\nspeed:" + freeSpeed + "\npress middel mouse button to reset rotation");
                break;
            case RotationType.Fixed:
                GUI.Label(new Rect(0, 0, 200, 150), "type:" + mode.ToString() + "\ndown:" + downPoint.ToString() + "\nup:" + upPoint.ToString() + "\ndir:" + dir.ToString() + "\ndegree:" + degree + "\nspeed:" + fixSpeed + "\npress middel mouse button to reset rotation");
                break;
            default:
                break;
        }

    }
}

[CustomEditor(typeof(RotationController))]
public class RotationControllerEditor : Editor
{
    private RotationController self;

    private void OnEnable()
    {
        self = target as RotationController;
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        self.showDebugMes = EditorGUILayout.Toggle("Debug Mes", self.showDebugMes);

        self.target = (GameObject)EditorGUILayout.ObjectField("Target", self.target, typeof(GameObject), true);
        self.mode = (RotationType)EditorGUILayout.EnumPopup("Mode", self.mode);

        switch (self.mode)
        {
            case RotationType.Fixed:
                self.fixSpeed = EditorGUILayout.Slider("Fix Speed", self.fixSpeed, 0, 10);
                self.sensitivity = EditorGUILayout.FloatField("Sensitivity", self.sensitivity);
                self.degree = EditorGUILayout.FloatField("Degree", self.degree);
                break;
            case RotationType.Free:
                self.freeSpeed = EditorGUILayout.Slider("Free Speed", self.freeSpeed, 0, 10);
                break;
            default:
                break;
        }

        self.fixHorizontal = EditorGUILayout.Toggle("Horizontal Fixed", self.fixHorizontal);
        self.fixVertical = EditorGUILayout.Toggle("Vertical Fixed", self.fixVertical);


    }
}
