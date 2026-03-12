using UnityEngine;

public class HPBarController : MonoBehaviour
{
    [SerializeField] private GameObject hpBarPrefab;
    
    private HPBar _hpBar;
    private Canvas _canvas;
    private Camera _camera;

    private void Start()
    {
        _hpBar = Instantiate(hpBarPrefab, this.transform).GetComponent<HPBar>();
    }
}
