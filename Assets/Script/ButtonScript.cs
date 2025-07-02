using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private UnityEvent _onPush;
    [SerializeField] private UnityEvent _onHold;
    [SerializeField] private UnityEvent _onRelease;

    private bool _isPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
        _onPush?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
        _onRelease?.Invoke();
    }

    private void Update()
    {
        if(_isPressed)
        {
            _onHold?.Invoke();
        }
    }
}
