using UnityEngine;

[ExecuteInEditMode]
public class ShapeRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRendererPrefab;

    private EdgeCollider2D[] colliders;
    //private EdgeCollider2D edgeCollider;
    private LineRenderer lineRenderer;

    private void Start()
    {
        colliders = GetComponents<EdgeCollider2D>();

        foreach (EdgeCollider2D collider in colliders)
        {
            lineRenderer = Instantiate(lineRendererPrefab, Vector3.zero, Quaternion.identity, transform) as LineRenderer;

            lineRenderer.positionCount = collider.pointCount - 1;

            Vector2[] points = collider.points;

            for (int i = 0; i < lineRenderer.positionCount; i++)
            {
                lineRenderer.SetPosition(i, new Vector3(points[i].x, points[i].y, 0));
            }
        }
    }
}