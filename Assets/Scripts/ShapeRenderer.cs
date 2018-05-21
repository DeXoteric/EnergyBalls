using UnityEngine;


public class ShapeRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRendererPrefab;

    private EdgeCollider2D edgeCollider;
    private LineRenderer lineRenderer;

    private void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
        lineRenderer = Instantiate(lineRendererPrefab, Vector3.zero, Quaternion.identity, transform) as LineRenderer;

        lineRenderer.positionCount = edgeCollider.pointCount - 1;

        Vector2[] points = edgeCollider.points;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(points[i].x, points[i].y, 0));
        }
    }
}