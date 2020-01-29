using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemyPiecesScriptableObject enemyPieces;

    void Start()
    {
        SummonMonster(50);
    }

    void SummonMonster(int pieces)
    {
        Vector3 sumPos = transform.position;
        float lastScaleX = 0f;
        for (var x = 0; x <= pieces; x++)
        {
            GameObject basePiece = enemyPieces.pieces[Random.Range(0, enemyPieces.pieces.Count)].piece;
            var go = Instantiate
            (
                basePiece,
                sumPos + Vector3.right * (lastScaleX / 2 + basePiece.transform.lossyScale.x / 2), //Para que se peguen las piezas unas con otras
                transform.rotation
            );
            sumPos = go.transform.position;
            lastScaleX = go.transform.lossyScale.x;
        }
    }
}

[System.Serializable]
public struct EnemyPiece
{
    public string name;
    public int health;
    public GameObject piece;
}
