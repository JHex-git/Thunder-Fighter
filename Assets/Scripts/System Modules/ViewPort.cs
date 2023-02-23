using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPort : Singleton<ViewPort>
{
    float minX;
    float maxX;
    float middleX;
    float minY;
    float maxY;
    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = Camera.main;

        Vector3 leftBottom = mainCamera.ViewportToWorldPoint(new Vector3(0, 0));
        Vector3 rightTop = mainCamera.ViewportToWorldPoint(new Vector3(1, 1));

        middleX = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0)).x;
        minX = leftBottom.x;
        maxX = rightTop.x;
        minY = leftBottom.y;
        maxY = rightTop.y;
    }

    public Vector3 PlayerMoveablePosition(Vector3 playerPosition, float paddingX, float paddingY)
    {
        Vector3 position = Vector3.zero;

        position.x = Mathf.Clamp(playerPosition.x, minX + paddingX, maxX - paddingX);
        position.y = Mathf.Clamp(playerPosition.y, minY + paddingY, maxY - paddingY);

        return position;
    }

    public Vector3 RandomEnemySpawnPosition(float paddingX, float paddingY)
    {
        Vector3 position = Vector3.zero;

        position.x = maxX + paddingX;
        position.y = Random.Range(minY + paddingY, maxY - paddingY);

        return position;
    }

    public Vector3 RandomRightHalfPosition(float paddingX, float paddingY)
    {
        Vector3 position = Vector3.zero;

        position.x = Random.Range(middleX, maxX - paddingX);
        position.y = Random.Range(minY + paddingY, maxY - paddingY);
        return position;
    }
}
