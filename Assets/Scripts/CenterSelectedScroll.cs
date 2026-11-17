using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(ScrollRect))]
public class CenterSelectedScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 10f;

    private ScrollRect scrollRect;
    private RectTransform viewport;
    private RectTransform content;
    private GameObject lastSelected;
    private FishList fL;
    [SerializeField] private GameObject[] buttons;

    void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
        fL = GameObject.FindWithTag("list").GetComponent<FishList>();
        viewport = scrollRect.viewport;
        content = scrollRect.content;
    }

    private void OnEnable()
    {
        StartCoroutine(openMenu());
    }

    void Update()
    {
        GameObject current = EventSystem.current.currentSelectedGameObject;

        // Keep track of the last valid selection so keyboard navigation never breaks
        if (current == null)
        {
            if (lastSelected != null)
                EventSystem.current.SetSelectedGameObject(lastSelected);
            return;
        }

        lastSelected = current;

        // Only scroll if the selected object is inside this ScrollRect's content
        if (!current.transform.IsChildOf(content))
            return;

        RectTransform selectedRect = current.GetComponent<RectTransform>();
        CenterOnItem(selectedRect);
    }

    private void CenterOnItem(RectTransform target)
    {
        // Convert both the viewport center and target center into content-local space
        Vector3 viewportCenterWorld = viewport.TransformPoint(viewport.rect.center);
        Vector3 viewportCenterLocal = content.InverseTransformPoint(viewportCenterWorld);

        Vector3 targetCenterWorld = target.TransformPoint(target.rect.center);
        Vector3 targetCenterLocal = content.InverseTransformPoint(targetCenterWorld);

        // Calculate the distance needed to bring the target to the viewport center
        Vector2 difference = (Vector2)viewportCenterLocal - (Vector2)targetCenterLocal;
        Vector2 targetAnchoredPos = content.anchoredPosition + difference;

        // Lock axes that are not enabled on the ScrollRect
        if (!scrollRect.horizontal) targetAnchoredPos.x = content.anchoredPosition.x;
        if (!scrollRect.vertical) targetAnchoredPos.y = content.anchoredPosition.y;

        // Smoothly move the content container
        content.anchoredPosition = Vector2.Lerp(
            content.anchoredPosition,
            targetAnchoredPos,
            Time.unscaledDeltaTime * scrollSpeed
        );
    }

    private IEnumerator openMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(buttons[fL.selectedButton]);
    }
}

