using UnityEngine;

namespace Internal.Camera
{
    [RequireComponent(typeof(Animator))]
    public class CameraManager : MonoBehaviour
    {
        private Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void SwitchCameraByName(string name) => animator.Play(name);
    }
}
