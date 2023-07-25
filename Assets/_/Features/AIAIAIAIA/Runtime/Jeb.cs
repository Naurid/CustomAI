using UnityEngine;

public class Jeb : MonoBehaviour
{
    #region Public Members

    public float m_jebFactor;

    #endregion


    #region Unity API
    private void Start()
    {
        _playerMesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float r = Mathf.Sin(Time.time * m_jebFactor);
        float g = Mathf.Cos(Time.time * m_jebFactor);
        float b = Mathf.Sin(-Time.time * m_jebFactor);
        _playerMesh.material.color = new Color(r, g, b);
    }

    #endregion


    #region Main Methods

   

    #endregion

    #region Private and Protected

    MeshRenderer _playerMesh;

    #endregion
}
