using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    public AnimationCurve ZoomCurve;
    //public AnimationCurve EnthickenSteps;
    public float InitialZoom = 0.5f;

    private float _zoomLevel;
    private Vector3 _inputLastFrame;
    private Camera _camera;

    private const float ZoomMin = 3.5f;
    private const float ZoomMax = 12f;

    private static float ZoomRange => ZoomMax - ZoomMin;

    public void Start()
    {
        _camera = GetComponent<Camera>();
        _zoomLevel = InitialZoom;
    }

    public void Update()
    {
        var inputPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
        inputPosition.z = 0;
        if (Input.GetMouseButtonDown(0))
        {
            _inputLastFrame = inputPosition;
        }

        if (Input.GetMouseButton(0))
        {
            var diff = inputPosition - _inputLastFrame;
            var viewportToWorld = _camera.ViewportToWorldPoint(Vector3.one) - _camera.ViewportToWorldPoint(Vector3.zero);
            transform.position -= new Vector3(diff.x * viewportToWorld.x, diff.y * viewportToWorld.y);
            _inputLastFrame = inputPosition;
        }

        var newZoomLevel = Mathf.Clamp01(_zoomLevel - Input.mouseScrollDelta.y * 0.1f);
        _camera.orthographicSize = ZoomMin + ZoomCurve.Evaluate(newZoomLevel) * ZoomRange;
        Shader.SetGlobalFloat("_EnthickenLines", newZoomLevel);

        _zoomLevel = newZoomLevel;
    }
}
