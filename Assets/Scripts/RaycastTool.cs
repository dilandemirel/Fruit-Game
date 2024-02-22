using System.Collections;
using UnityEngine;

public class RaycastTool : MonoBehaviour
{
    [SerializeField] private GameArea _gameArea;

    private bool isWorking;

    private RaycastHit2D[] hits;

    private void Update()
    {
        var left = _gameArea.GetBorderPositionHorizontal().x;
        var right = _gameArea.GetBorderPositionVertical().y;
        Vector2 startingPoint = new Vector2(left, up);

        var direction = Vector2.right;
        RaycastHit2D[] hits = Physics2D.RaycastAll(startingPoint, direction, 10f);

        if (hits.Length == 0)
            return;

        if (isWorking)
            return;

        isWorking = true;
        StartCoroutine(CheckList());

        /*
        foreach (RaycastHit2D hit in hits)
        {
            GameObject hitObject = hit.collider.gameObject;
            Vector2 hitPoint = hit.point;

            Debug.Log("Hit Object: " + hitObject.name + ", Hit Point: " + hitPoint);
        }
        */
    }

    private IEnumerator CheckList()
    {
        yield return new WaitForSeconds(2);

        if(hits.Length > 0)
        {
            //Game Over
            GameManager.Instance.GameOver();
        }


        isWorking = false;


    }
}
