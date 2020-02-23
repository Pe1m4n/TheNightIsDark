using UnityEngine;

namespace Fight.Enemies
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private EnemyView _view;
        
        public void SetEnemyView(EnemyView view)
        {
            _view = view;
        }
        
        public void Attack()
        {
            _view.Attack();
        }
    }
}