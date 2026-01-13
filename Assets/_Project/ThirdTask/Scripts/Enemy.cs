using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] private bool _isDead;

    public float TimeSinceSpawn { get; private set; }
    public bool IsDead => _isDead;

    private void Update() => TimeSinceSpawn += Time.deltaTime;
    private void OnDisable() => TimeSinceSpawn = 0;
}
