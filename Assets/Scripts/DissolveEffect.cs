using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    [SerializeField] private Material dissolveMaterial; 
    [SerializeField] private float dissolveSpeed = 1.0f;
    [SerializeField] private Color edgeColor = Color.yellow;

    private Material materialInstance;
    private float dissolvePercentage = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (dissolveMaterial)
        {
            // I am creating instance so that the original material is not modified.
            materialInstance = new Material(dissolveMaterial);
            GetComponent<Renderer>().material = materialInstance;

            materialInstance.SetFloat("_DissolvePercentage", dissolvePercentage);
            materialInstance.SetColor("_EdgeColor", edgeColor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (materialInstance && dissolvePercentage < 1.0f)
        {
            dissolvePercentage += Time.deltaTime / dissolveSpeed;
            materialInstance.SetFloat("_DissolvePercentage", dissolvePercentage);

            if (dissolvePercentage >= 1.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
