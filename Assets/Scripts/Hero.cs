
using UnityEngine;

public class Hero : Character
{
    public override void Move()
    {
        base.Move();
        currentCell = GameManager.Instance.WorldPointToCell(transform.position);

        if (currentNodeIndex == 0)
        {
            Debug.Log("Win");
            GameManager.Instance.isLevelFinished = true;
        }
    }
}
