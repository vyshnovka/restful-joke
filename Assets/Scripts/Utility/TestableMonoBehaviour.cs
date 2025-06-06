using UnityEngine;

namespace Utility
{
    public abstract class TestableMonoBehaviour : MonoBehaviour
    {
#if (UNITY_EDITOR)
        [Header("Editor Settings")]
        [Tooltip("Available and used in Editor only!")]
        [SerializeField]
        protected bool testInEditor;
#endif
    }
}