using Signals;
using UnityEngine;
using TMPro;

namespace Controllers
{
    public class CollectableScoreController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        [SerializeField] private TextMeshPro scoreText;
        #endregion

        #region Private Variables
        private CollectableManager _manager;



        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _manager = GetComponent<CollectableManager>();
            scoreText.text = _manager.Value.ToString();
        }

        
    }
}