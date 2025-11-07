using UnityEngine;


public abstract class EnemyFactory : MonoBehaviour
{
    public abstract IEnemy GetProduct(Vector3 position);

}