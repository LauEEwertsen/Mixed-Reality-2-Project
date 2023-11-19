using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Layer_Blocks_Controller : MonoBehaviour
{

    [SerializeField] GameObject LayerTypePrefab_1;
    [SerializeField] GameObject LayerTypePrefab_2;
    [SerializeField] GameObject LayerTypePrefab_3;
    [SerializeField] GameObject LayerTypePrefab_4;
    [SerializeField] GameObject LayerTypePrefab_5;

    [SerializeField] GameObject LayerPos_1;
    [SerializeField] GameObject LayerPos_2;
    [SerializeField] GameObject LayerPos_3;
    [SerializeField] GameObject LayerPos_4;
    [SerializeField] GameObject LayerPos_5;

    enum LayerTypes
    {
        Dirt_Layer,
        Sand_Layer,
        Chalk_Layer,
        Stone_Layer,
        Clay_Layer
    }

    [SerializeField] LayerTypes LayerTypes_1 = new();
    [SerializeField] LayerTypes LayerTypes_2 = new();
    [SerializeField] LayerTypes LayerTypes_3 = new();
    [SerializeField] LayerTypes LayerTypes_4 = new();
    [SerializeField] LayerTypes LayerTypes_5 = new();

    GameObject layer_1;
    GameObject layer_2;
    GameObject layer_3;
    GameObject layer_4;
    GameObject layer_5;

    string layer_1_SavedType;
    string layer_2_SavedType;
    string layer_3_SavedType;
    string layer_4_SavedType;
    string layer_5_SavedType;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        if (LayerTypes_1.ToString() != layer_1_SavedType)
        {
            Destroy(layer_1, 0.0f);

            layer_1 = Instantiate(
                FindLayerType(LayerTypes_1.ToString()),
                LayerPos_1.transform.position,
                Quaternion.identity);

            layer_1_SavedType = LayerTypes_1.ToString();
        }

        if (LayerTypes_2.ToString() != layer_2_SavedType)
        {
            Destroy(layer_2, 0.0f);

            layer_2 = Instantiate(
                FindLayerType(LayerTypes_2.ToString()),
                LayerPos_2.transform.position,
                Quaternion.identity);

            layer_2_SavedType = LayerTypes_2.ToString();
        }

        if (LayerTypes_3.ToString() != layer_3_SavedType)
        {
            Destroy(layer_4, 0.0f);

            layer_3 = Instantiate(
                FindLayerType(LayerTypes_3.ToString()),
                LayerPos_3.transform.position,
                Quaternion.identity);

            layer_3_SavedType = LayerTypes_3.ToString();
        }

        if (LayerTypes_4.ToString() != layer_4_SavedType)
        {
            Destroy(layer_4, 0.0f);

            layer_4 = Instantiate(
                FindLayerType(LayerTypes_4.ToString()),
                LayerPos_4.transform.position,
                Quaternion.identity);

            layer_4_SavedType = LayerTypes_4.ToString();
        }

        if (LayerTypes_5.ToString() != layer_5_SavedType)
        {
            Destroy(layer_5, 0.0f);

            layer_5 = Instantiate(
                FindLayerType(LayerTypes_5.ToString()),
                LayerPos_5.transform.position,
                Quaternion.identity);

            layer_5_SavedType = LayerTypes_5.ToString();
        }

    }

    GameObject FindLayerType (string LayerType)
    {
        switch (LayerType)
        {
            case "Dirt_Layer":
                return LayerTypePrefab_1;
                
            case "Sand_Layer":
                return LayerTypePrefab_2;
                
            case "Chalk_Layer":
                return LayerTypePrefab_3;
                
            case "Stone_Layer":
                return LayerTypePrefab_4;
                
            case "Clay_Layer":
                return LayerTypePrefab_5;
                
            default:
                return LayerTypePrefab_1;
               
        }
    }
}
