using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlatformManager : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private List<GameObject> _allProbablyIntersectObjects;
    private Transform _transform;
    private bool _isDragging;
    private const float move = 0.05f;

    [SerializeField]
    private GameObject slot;

    public bool PlatformMode = true;

    private Collider2D collider;

    public GameObject Slot { private get { return slot; } set => slot = value; }

    void Start()
    {
        _transform = GetComponent<Transform>();
        _isDragging = false;

        collider = gameObject.GetComponent<Collider2D>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Time.timeScale == 0.0f || !PlatformMode)
            return;
        Vector3 position = Camera.main.ScreenToWorldPoint(eventData.position);
        position.z = _transform.position.z;
        _transform.position = position;
        _isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _allProbablyIntersectObjects = GetAllProbablyIntersectObjects();
        for (int i = 0; i != 3; i++)
        {
            foreach (var obj in _allProbablyIntersectObjects)
                FixIntersection(obj);
        }
        _isDragging = false;
    }

    private List<GameObject> GetAllProbablyIntersectObjects()
    {
        var objects = GameObject.FindGameObjectsWithTag("Platform").ToList();
        objects.AddRange(GameObject.FindGameObjectsWithTag("EntryExit").ToList());
        objects.AddRange(GameObject.FindGameObjectsWithTag("Wall").ToList());

        foreach (var obj in objects)
        {
            if (obj == gameObject)
            {
                objects.Remove(obj);
                break;
            }
        }
        return objects;
    }

    private void FixIntersection(GameObject other)
    {
        float moveX = GetMoveDirection(other);
        while (IsIntersects(other))
        {
            _transform.position -= new Vector3(moveX, 0, 0);
        }
    }

    private bool IsIntersects(GameObject other)
    {
        var mainPlatformBounds = GetComponent<Renderer>().bounds;
        var checkPlatformBounds = other.GetComponent<Renderer>().bounds;
        if (checkPlatformBounds.Intersects(mainPlatformBounds))
            return true;
        return false;
    }

    private float GetMoveDirection(GameObject other)
    {
        if (other.GetComponent<Renderer>().bounds.center.x <
                  GetComponent<Renderer>().bounds.center.x)
            return -move;
        return move;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_isDragging && PlatformMode)
        {
            float angle = 10.0f;
            if (GetComponent<Renderer>().bounds.center.x < Camera.main.ScreenToWorldPoint(eventData.position).x)
                angle = -10.0f;
            gameObject.transform.Rotate(0, 0, angle);
            _allProbablyIntersectObjects = GetAllProbablyIntersectObjects();
            for (int i = 0; i != 3; i++)
            {
                foreach (var obj in _allProbablyIntersectObjects)
                    FixIntersection(obj);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData) {}
}
