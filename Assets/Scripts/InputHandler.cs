using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    [SerializeField] private float overlapRadius = 0.8f;
    [SerializeField] private int minMatchingHits = 3;
    [SerializeField] private int minSurroundingHits = 3;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {

        if (!context.started) return;

        Vector2 mousePos = Mouse.current.position.ReadValue();

        Collider2D firstHit = GetHitCollider(mousePos);
        if (!firstHit) return;

        List<Collider2D> matchingHits = GetMatchingHits(firstHit);
        List<Collider2D> surroundingHits = GetSurroundingHits(matchingHits);

        for (int i = 0; i < 20; i++)
        {
            List<Collider2D> moreSurroundingHits = GetSurroundingHits(surroundingHits);
            surroundingHits.AddRange(moreSurroundingHits);
        }

        ProcessMatchingHits(matchingHits);
        ProcessSurroundingHits(surroundingHits);
    }

    private Collider2D GetHitCollider(Vector2 mousePos)
    {
        Ray ray = _mainCamera.ScreenPointToRay(mousePos);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        return hit.collider;
    }

    private List<Collider2D> GetMatchingHits(Collider2D firstHit)
    {
        List<Collider2D> hits = new List<Collider2D>(Physics2D.OverlapCircleAll(firstHit.transform.position, overlapRadius));
        List<Collider2D> matchingHits = new List<Collider2D>();

        foreach (Collider2D hit in hits)
        {
            if (hit.name == firstHit.name)
            {
                matchingHits.Add(hit);
            }
        }

        return matchingHits;
    }

    private List<Collider2D> GetSurroundingHits(List<Collider2D> hits)
    {
        List<Collider2D> surroundingHits = new List<Collider2D>();

        foreach (Collider2D hit in hits)
        {
            Collider2D[] hitsAround = Physics2D.OverlapCircleAll(hit.transform.position, overlapRadius);

            foreach (Collider2D hitAround in hitsAround)
            {
                if (hitAround.name == hit.name && !surroundingHits.Contains(hitAround) && !hits.Contains(hitAround))
                {
                    surroundingHits.Add(hitAround);
                }
            }
        }

        return surroundingHits;
    }

    private System.Collections.IEnumerator DestroyMatchingHits(List<Collider2D> matchingHits)
    {
        foreach (Collider2D hit in matchingHits)
        {
            Destroy(hit.gameObject);
            yield return new WaitForSeconds(0.1f);

            // Đợi 0.1 giây trước khi xóa tiếp game object tiếp theo
        }
    }

    private System.Collections.IEnumerator DestroySurroundingHits(List<Collider2D> surroundingHits)
    {
        foreach (Collider2D hit in surroundingHits)
        {
            Destroy(hit.gameObject);
            yield return new WaitForSeconds(0.1f);


        }
    }


    private void ProcessMatchingHits(List<Collider2D> matchingHits)

    {

        if (matchingHits.Count >= minMatchingHits)
        {
            StartCoroutine(DestroyMatchingHits(matchingHits));
            WinningHandler.instance.turn -= 1;
        }
    }

    private void ProcessSurroundingHits(List<Collider2D> surroundingHits)
    {
        if (surroundingHits.Count >= minSurroundingHits)
        {
            StartCoroutine(DestroySurroundingHits(surroundingHits));
        }
    }
}
