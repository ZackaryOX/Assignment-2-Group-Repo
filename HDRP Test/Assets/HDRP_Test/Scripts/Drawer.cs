using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{


    public Material NewMat;
    public GameObject Object;
    public GameObject lookingAt;
    private Vector3 origRotation;

    GameObject objReference;
    Vector3 origPos;
    Vector3 newPos;
    bool switchBool = false;
    bool triggerAnim;
    bool controlUp = false;
    float timeLerp = 1.0f;
    float currentLerp;


    MeshRenderer Rend;
    Material OldMat;

    public bool mouseOver = false;
    public static bool MovingStuff = false;
    public static GameObject ObjectMoving;


    void Awake()
    {
        //ObjectMoving = this.gameObject;
        Rend = GetComponent<MeshRenderer>();
        OldMat = Rend.material;
    }

    float ReturnGridPos(float x)
    {
        float gridtolockto = 0.25f;

        float posToSet = x;

        if (posToSet > 0)
        {
            posToSet /= gridtolockto;
            posToSet += 0.5f;
            float roundedX = (int)posToSet;
            roundedX *= gridtolockto;
            posToSet = roundedX;
        }
        else if (posToSet < 0)
        {
            posToSet /= gridtolockto;
            posToSet -= 0.5f;
            float roundedX = (int)posToSet;
            roundedX *= gridtolockto;
            posToSet = roundedX;
        }

        return posToSet;
    }
    void lerpAnimation(Vector3 orig, Vector3 newP)
    {
        currentLerp += Time.deltaTime;
        if (currentLerp > timeLerp)
        {
            currentLerp = timeLerp;
        }

        float lerpT = currentLerp / timeLerp;
        lerpT = Mathf.SmoothStep(0.0f, 1.0f, lerpT);

        if (triggerAnim == true)
        {
            objReference.transform.position = Vector3.Lerp(orig, newP, lerpT);
            Debug.Log("1");
            if (lerpT == 1.0f)
            {
                switchBool = true;
            }
        }

        else if (triggerAnim == false)
        {
            objReference.transform.position = Vector3.Lerp(orig, newP, lerpT);
            if (lerpT == 1.0f)
            {
                switchBool = false;
            }
            Debug.Log("2");
        }
    }
    void Update()
    {

        lookingAt = GameObject.Find(rayFromCamera.lookingAt);

        if (controlUp == true)
        {
            lerpAnimation(origPos, newPos);
        }




        if (mouseOver && !MovingStuff)
        {
            if (lookingAt.tag != ("Untagged") && lookingAt.CompareTag("Item"))
            {
                Rend.material = NewMat;
            }
            if (Input.GetKey(KeyCode.E))
            {
                //MovingStuff = true;
                //ObjectMoving = lookingAt;

            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            MovingStuff = false;
            return;
        }



    }

    void OnMouseOver()
    {
        lookingAt = GameObject.Find(rayFromCamera.lookingAt);

        if (lookingAt.tag != ("Untagged") && lookingAt.CompareTag("Interactable"))
        {
            objReference = lookingAt;
            if (Input.GetKey(KeyCode.E))
            {
                controlUp = true;
                origPos.Set(objReference.transform.position.x, objReference.transform.position.y, objReference.transform.position.z);

                if (switchBool == true)
                {
                    newPos = new Vector3(origPos.x - 1.0f, origPos.y, origPos.z);
                    triggerAnim = false;

                }

                if (switchBool == false)
                {
                    newPos = new Vector3(origPos.x + 1.0f, origPos.y, origPos.z);
                    triggerAnim = true;

                }

                currentLerp = 0.0f;
            }
        }
        else
        {
            mouseOver = true;
        }

    }



    void OnMouseExit()
    {
        mouseOver = false;
        if (!MovingStuff)
        {
            Rend.material = OldMat;
        }


    }

}
