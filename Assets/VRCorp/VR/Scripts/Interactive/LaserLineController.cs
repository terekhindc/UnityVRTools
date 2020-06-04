using UnityEngine;

/***
 * Интерактивный контроллер для создания лазерной указки
 * Требует добавления в качестве дочернего префаба с Canvasом
 * и изображением точки, накладываемой на интерактивный объект при наведении.
 */
namespace VRCorp.VR
{
    [AddComponentMenu("VRCorp/VR/Interactive/LaserLine")]
    [RequireComponent(typeof(LineRenderer))]
    public class LaserLineController : Interactor
    {
        private LineRenderer _lineRenderer;

        [SerializeField] Transform reticle;
        private Canvas _reticleRender;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _reticleRender = reticle.GetComponent<Canvas>();
            _reticleRender.enabled = false;
        }

        private void Update()
        {
            PhysicsInteraction();
        }
        
        void PhysicsInteraction()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                reticle.position = hit.point+(hit.normal*0.01f);
                _reticleRender.enabled = true;
                reticle.rotation = Quaternion.LookRotation(hit.normal);
                
                float distance = Vector3.Distance(hit.point, transform.position);
                _lineRenderer.SetPosition(1,new Vector3(0,0,distance));

                if (hit.transform.GetComponent<Interactable>())
                {
                    SetInteractiveObject(hit.transform.GetComponent<Interactable>());
                }
            }
            else
            {
                _lineRenderer.SetPosition(1,new Vector3(0,0,100));
                _reticleRender.enabled = false;
                if (_currentTarget != null) LostInteractiveObject();
            }
        }
    }
}
