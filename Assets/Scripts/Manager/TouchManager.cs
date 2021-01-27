using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : SingletonClass<TouchManager>
{
    private ICamera uiCam;
    private Touchable touchable;
    private RectTransform rt;
    private void Start()
    {
        uiCam = CameraManager.GetInstance.GetCamera("UiCamera");
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() == false)
            {
                
            }
            else
            {
                GameObject selectedGo = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

                //터치관련 인터페이스가 포함된 오브젝트인지 확인
                if (selectedGo != null)
                    touchable = selectedGo.GetComponent<Touchable>();

                if (touchable != null)
                    rt = selectedGo.GetComponent<RectTransform>();
            }

            if (touchable == null)
            {

            }
            else
            {
                if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, Input.mousePosition, uiCam.camera, out Vector2 localCursor))
                    return;

                touchable.Touch(localCursor);
            }
        }
        else
        {
            if (touchable == null) return;

            touchable.StopTouch();
            touchable = null;
        }
    }
}
