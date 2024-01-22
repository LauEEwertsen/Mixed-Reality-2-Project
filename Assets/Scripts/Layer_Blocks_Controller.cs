using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Layer_Blocks_Controller : MonoBehaviour
{
    [SerializeField] GameObject LayerTypePrefab_0;
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

    GameObject[] LayerPos;

    enum LayerTypes
    {
        Dirt_Layer,
        Sand_Layer,
        Chalk_Layer,
        Stone_Layer,
        Clay_Layer
    }

    [SerializeField] LayerTypes Layer_1_Type = new();
    [SerializeField] LayerTypes Layer_2_Type = new();
    [SerializeField] LayerTypes Layer_3_Type = new();
    [SerializeField] LayerTypes Layer_4_Type = new();
    [SerializeField] LayerTypes Layer_5_Type = new();

    LayerTypes[] layerTypes;

    public SerialController SC;

    GameObject layer_1,
     layer_2,
     layer_3,
     layer_4,
     layer_5;

    GameObject[] layers;

    string layer_1_SavedType,
     layer_2_SavedType,
     layer_3_SavedType,
     layer_4_SavedType,
     layer_5_SavedType;

    string[] layer_SavedTypes;

    Color32 Brown_color,
     Yellow_color,
     White_color,
     Grey_color,
     Red_color;

    List<Color32> colorList;

    // Start is called before the first frame update
    void Start()
    {
        SC = GetComponent<SerialController>();

        Brown_color = new Color32(107, 77, 26, 255);  //LayerTypePrefab_1.GetComponent<SpriteRenderer>().color;
        Yellow_color = new Color32(105, 92, 19, 255); //LayerTypePrefab_2.GetComponent<SpriteRenderer>().color;
        White_color = new Color32(84, 98, 40, 255);   //LayerTypePrefab_3.GetComponent<SpriteRenderer>().color;
        Grey_color = new Color32(97, 85, 49, 255);    //LayerTypePrefab_4.GetComponent<SpriteRenderer>().color;
        Red_color = new Color32(179, 51, 26, 255);    //LayerTypePrefab_5.GetComponent<SpriteRenderer>().color;

        colorList = new()
        {
            Brown_color,
            Yellow_color,
            White_color,
            Grey_color,
            Red_color
        };

        layers = new GameObject[]
        {
            layer_1,
            layer_2,
            layer_3,
            layer_4,
            layer_5
        };

        layer_SavedTypes = new string[]
        {
            layer_1_SavedType,
            layer_2_SavedType,
            layer_3_SavedType,
            layer_4_SavedType,
            layer_5_SavedType
        };

        LayerPos = new GameObject[]
        {
            LayerPos_1,
            LayerPos_2,
            LayerPos_3,
            LayerPos_4,
            LayerPos_5
        };

        layerTypes = new LayerTypes[]
        {
            Layer_1_Type,
            Layer_2_Type,
            Layer_3_Type,
            Layer_4_Type,
            Layer_5_Type
        };

        for (int i = 0; i < layers.Length; i++)
        {
            BlockCreation(i + 1, -1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        string recievedString;
        recievedString = SC.ReadSerialMessage();
        //recievedString = "5 84 98 40";    //White block
        //recievedString = "4 96 96 32;"    //Brown block
        //recievedString = "4 107 77 26";   //Brown block
        //recievedString = "3 105 92 19";   //Yellow block
        //recievedString = "3 136 85 34";   //Yellow block
        //recievedString = "2 179 51 26";   //Red block
        //recievedString = "1 97 85 49";    //Grey block
        //recievedString = "1 78 98 39";    //Grey block

        if (recievedString == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(recievedString, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(recievedString, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else            
        {
            Debug.Log("Message arrived: " + recievedString);
            ChangeBlock(recievedString);         
        }
    }

    void BlockCreation(int layerNumber, int ColorIndex)
    {

        if (layerTypes[layerNumber - 1].ToString() != layer_SavedTypes[layerNumber - 1])
        {
            Destroy(layers[layerNumber - 1], 0.0f);

            layers[layerNumber - 1] = Instantiate(
                FindLayerTypePrefab(ColorIndex),
                LayerPos[layerNumber - 1].transform.position,
                Quaternion.identity
            );

            layer_SavedTypes[layerNumber - 1] = layerTypes[layerNumber - 1].ToString();
        }

    }

    /*
    void BlockCreation(int layerNumber)
    {
        BlockDestruction(layerNumber);

        
        if (Layer_1_Type.ToString() != layer_1_SavedType)
        {
            //BlockDestruction(1);

            Destroy(layer_1, 0.0f);

            layer_1 = Instantiate(
                FindLayerTypePrefab(Layer_1_Type.ToString()),
                LayerPos_1.transform.position,
                Quaternion.identity);

            layer_1_SavedType = Layer_1_Type.ToString();
        }

        if (Layer_2_Type.ToString() != layer_2_SavedType)
        {
            //BlockDestruction(2);

            Destroy(layer_2, 0.0f);

            layer_2 = Instantiate(
                FindLayerTypePrefab(Layer_2_Type.ToString()),
                LayerPos_2.transform.position,
                Quaternion.identity);

            layer_2_SavedType = Layer_2_Type.ToString();
        }

        if (Layer_3_Type.ToString() != layer_3_SavedType)
        {
            //BlockDestruction(3);

            Destroy(layer_3, 0.0f);

            layer_3 = Instantiate(
                FindLayerTypePrefab(Layer_3_Type.ToString()),
                LayerPos_3.transform.position,
                Quaternion.identity);

            layer_3_SavedType = Layer_3_Type.ToString();
        }

        if (Layer_4_Type.ToString() != layer_4_SavedType)
        {
            //BlockDestruction(4);

            Destroy(layer_4, 0.0f);

            layer_4 = Instantiate(
                FindLayerTypePrefab(Layer_4_Type.ToString()),
                LayerPos_4.transform.position,
                Quaternion.identity);

            layer_4_SavedType = Layer_4_Type.ToString();
        }

        if (Layer_5_Type.ToString() != layer_5_SavedType)
        {
            //BlockDestruction(5);

            Destroy(layer_5, 0.0f);

            layer_5 = Instantiate(
                FindLayerTypePrefab(Layer_5_Type.ToString()),
                LayerPos_5.transform.position,
                Quaternion.identity);

            layer_5_SavedType = Layer_5_Type.ToString();
        }
    }*/

    void ChangeBlock(string recievedString)
    {
        string[] textSplit;

        textSplit = recievedString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int BlockNumber = int.Parse(textSplit[0]);
        byte redColorNumber = byte.Parse(textSplit[1]);
        byte greenColorNumber = byte.Parse(textSplit[2]);
        byte blueColorNumber = byte.Parse(textSplit[3]);

        //Debug.Log("BlockNumber: " + BlockNumber);
        //Debug.Log("redColorNumber: " + redColorNumber);
        //Debug.Log("greenColorNumber: " + greenColorNumber);
        //Debug.Log("blueColorNumber: " + blueColorNumber);

        Color32 inputColor = new Color32(redColorNumber, greenColorNumber, blueColorNumber, 255);

        //Debug.Log("inputColor: " + inputColor);      

        int indexInList = -1;

        if (redColorNumber != 0 && greenColorNumber != 0 && blueColorNumber != 0)
        {
            indexInList = findClosestColor(colorList, inputColor);
        } 

        //closes match in RGB space
        int findClosestColor(List<Color32> colors, Color32 target)
        {
            int colorDiffs = colors.Select(n => ColorDiff(n, target)).Min(n => n);
            return colors.FindIndex(n => ColorDiff(n, target) == colorDiffs);
        }

        // distance in RGB space
        int ColorDiff(Color32 c1, Color32 c2)
        {
            return (int)Math.Sqrt((c1.r - c2.r) * (c1.r - c2.r)
                                 + (c1.g - c2.g) * (c1.g - c2.g)
                                 + (c1.b - c2.b) * (c1.b - c2.b));
        }

        //string temp = "LayerTypes_" + BlockNumber.ToString();

        //static object Parse (Type enumType, string value);

        //layer_SavedTypes[BlockNumber - 1] = layerTypes[BlockNumber - 1].ToString();

        //layerTypes[BlockNumber - 1] = Enum.Parse(typeof(LayerTypes).GetName(typeof(LayerTypes), indexInList));         

        //Debug.Log("layerTypes[BlockNumber - 1]: " + layerTypes[BlockNumber - 1]);
        //Debug.Log("(LayerTypes)indexInList: " + (LayerTypes)indexInList);

        layerTypes[BlockNumber - 1] = (LayerTypes)indexInList;

        //GetType().GetField("Layer_" + BlockNumber.ToString() + "_Type",
        //    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public
        //    ).SetValue(
        //        this,
        //        Enum.Parse(
        //            typeof(LayerTypes),
        //            Enum.GetName(
        //                typeof(LayerTypes),
        //                indexInList
        //            )
        //        )
        //    );

        BlockCreation(BlockNumber, indexInList);
    }

    GameObject FindLayerTypePrefab(int LayerType)
    {
        switch (LayerType)
        {
            case 0:
                return LayerTypePrefab_1;              
                
            case 1:
                return LayerTypePrefab_2;
                
            case 2:
                return LayerTypePrefab_3;
                
            case 3:
                return LayerTypePrefab_4;
                
            case 4:
                return LayerTypePrefab_5;
                
            default:
                return LayerTypePrefab_0;
               
        }
    }
}
