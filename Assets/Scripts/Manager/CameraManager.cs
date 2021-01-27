using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingletonClass<CameraManager>
{
    private Dictionary<string, ICamera> cams;

    private void Start()
    {
        InitializeCams();
    }

    private void Update()
    {
        if (cams.TryGetValue("BloomCamera", out ICamera bloomCam))
        {
            bloomCam.CameraMove(Controller.GetInstance.controlTargetObj.transform.position, true);
        }

        if (cams.TryGetValue("MainCamera", out ICamera mainCam))
        {
            mainCam.CameraMove(Controller.GetInstance.controlTargetObj.transform.position, true);
        }
    }

    private ICamera MakeICamera(Camera cam)
    {
        GameObject anchor = new GameObject(IString.Append(cam.name, "Anchor"));

        anchor.transform.SetParent(cam.transform.parent);
        anchor.transform.localPosition = Vector3.zero;
        anchor.transform.rotation = Quaternion.identity;

        cam.transform.SetParent(anchor.transform);
        return anchor.AddComponent<ICamera>();
    }

    private bool CheckICamera(Camera cam, out ICamera iCam)
    {
        iCam = cam.transform.parent.GetComponent<ICamera>();
        return iCam != null;
    }

    public void InitializeCams()
    {
        if (cams == null)
        {
            cams = new Dictionary<string, ICamera>();
        }
        else
        {
            cams.Clear();
        }

        foreach (Camera cam in Camera.allCameras)
        {
            if (!CheckICamera(cam, out ICamera iCam))
            {
                cams[cam.name] = MakeICamera(cam);
            }
            else
            {
                cams[cam.name] = iCam;
            }
        }
    }
    public ICamera GetCamera(string name)
    {
        if (cams == null)
        {
            InitializeCams();
        }

        if (!cams.TryGetValue(name, out ICamera cam))
        {
            IDebug.LogError(name, " : Camera is Not Exist");

            return null;
        }
        
        return cam;
    }
}
