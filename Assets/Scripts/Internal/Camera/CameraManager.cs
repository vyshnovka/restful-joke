using UnityEngine;

namespace Internal.Camera
{
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
