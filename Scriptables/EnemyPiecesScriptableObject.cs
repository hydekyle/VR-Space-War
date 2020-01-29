using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPieces", menuName = "ScriptableObjects/EnemyPieces", order = 1)]
public class EnemyPiecesScriptableObject : ScriptableObject
{
    public List<EnemyPiece> pieces;
}
