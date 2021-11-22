using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    //have current circle when touched
    //when touching circle make it move to finger until you lift your finger
    //when lifting your finger current circle will be lifted
    [SerializeField]
    Camera _mainCamera;
    GameObject _touchedCircle = null;

    private void Update()
    {
        OnTouched();
    }
    void OnTouched()
    {
        if (Input.touchCount == 1) // touches screen
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = _mainCamera.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if(Physics2D.OverlapPoint(touchPos) == null)
                    {
                        Debug.Log("Physics2d overlap point is null and did not find any colliders");
                        return;
                    }
                    if(Physics2D.OverlapPoint(touchPos).transform.gameObject == null)
                    {
                        Debug.Log("transform or gameobject is null");
                        return;
                    }
                    _touchedCircle = Physics2D.OverlapPoint(touchPos).transform.gameObject;
                    break;
                case TouchPhase.Moved:
                    if(_touchedCircle == null)
                    {
                        return;
                    }
                    _touchedCircle.transform.position = touchPos;
                    break;
                case TouchPhase.Ended:
                    _touchedCircle = null;
                    break;
                default:
                    break;
            }
        }
    }
}
