using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script creado por ASSALAM o alaikum
 *  Encargado de adaptar (proporcionalmente a la escala) el "tiling" de las texturas vinculadas a los materiales de los "GameObjects" donde se encuentre el Script vinculado
 */
[ExecuteInEditMode]
public class DynamicTextureTiling : MonoBehaviour
{
    // Reference to the original material with the texture
    Material originalMaterial;

    void Start()
    {
        // Ensure we have a material
        originalMaterial = GetComponent<Renderer>().material;  // Modificada de material a sharedMaterial

        // Create a new material instance for this object
        Material materialInstance = new Material(originalMaterial);

        // Apply the new material to the object
        GetComponent<Renderer>().material = materialInstance;

        // Get the initial scale of the object
        Vector3 initialScale = transform.localScale;

        // Set the texture tiling based on the initial scale
        SetTextureTiling(materialInstance, initialScale);
    }

    void Update()
    {
        // Adjust texture tiling based on the current scale
        SetTextureTiling(GetComponent<Renderer>().material, transform.localScale); // Modificada de material a sharedMaterial
    }

    void SetTextureTiling(Material material, Vector3 scale)
    {
        // Calculate tiling based on the scale
        Vector2 tiling = new Vector2(scale.x/2, scale.z/2);

        // Apply tiling to the material
        material.mainTextureScale = tiling;
    }
}


