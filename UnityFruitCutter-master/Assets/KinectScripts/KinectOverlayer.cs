using UnityEngine;
using System.Collections;

public class KinectOverlayer : MonoBehaviour
{
    //	public Vector3 TopLeft;
    //	public Vector3 TopRight;
    //	public Vector3 BottomRight;
    //	public Vector3 BottomLeft;

    public GUITexture backgroundImage;
    public KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.ElbowRight;
    public GameObject OverlayObject;
    public float smoothFactor = 10f;
    bool t = true;
    public GUIText debugText;

    private float distanceToCamera = 10f;


    void Start()
    {
        OverlayObject = this.gameObject;
        if (OverlayObject)
        {

            distanceToCamera = (OverlayObject.transform.position - Camera.main.transform.position).magnitude;
        }

    }

    void Update()
    {
        KinectManager manager = KinectManager.Instance;

        if (manager && manager.IsInitialized())
        {
            //backgroundImage.renderer.material.mainTexture = manager.GetUsersClrTex();
           /* if ((backgroundImage && (backgroundImage.texture == null))||t)
            {
                backgroundImage.texture = manager.GetUsersClrTex();
                t = false;
            }*/

            //			Vector3 vRight = BottomRight - BottomLeft;
            //			Vector3 vUp = TopLeft - BottomLeft;

            int iJointIndex = (int)TrackedJoint;

            if (manager.IsUserDetected())
            {
                uint userId = manager.GetPlayer1ID();

                if (manager.IsJointTracked(userId, iJointIndex))
                {
                    Vector3 posJoint = manager.GetRawSkeletonJointPos(userId, iJointIndex);

                    if (posJoint != Vector3.zero)
                    {
                        Debug.Log("vac0");

                        // 3d position to depth
                        Vector2 posDepth = manager.GetDepthMapPosForJointPos(posJoint);
                        Debug.Log("vac1");

                        // depth pos to color pos
                        Vector2 posColor = posDepth;// manager.GetColorMapPosForDepthPos(posDepth);
                        Debug.Log("vac2");

                        float scaleX = (float)posColor.x / KinectWrapper.Constants.ColorImageWidth;
                        float scaleY = 1.0f - (float)0 / KinectWrapper.Constants.ColorImageHeight;
                        Debug.Log("vac3");

                        Debug.Log(scaleX);
                        Debug.Log(scaleY);



                        //						Vector3 localPos = new Vector3(scaleX * 10f - 5f, 0f, scaleY * 10f - 5f); // 5f is 1/2 of 10f - size of the plane
                        //						Vector3 vPosOverlay = backgroundImage.transform.TransformPoint(localPos);
                        //Vector3 vPosOverlay = BottomLeft + ((vRight * scaleX) + (vUp * scaleY));

                        if (debugText)
                        {
                            debugText.GetComponent<GUIText>().text = "Tracked user ID: " + userId;  // new Vector2(scaleX, scaleY).ToString();
                        }

                        if (OverlayObject)
                        {
                            Debug.Log(OverlayObject.tag);
                            Vector3 vPosOverlay = Camera.main.ViewportToWorldPoint(new Vector3(scaleX, scaleY, distanceToCamera));
                            vPosOverlay.Set(vPosOverlay.x, 0, 4);
                            OverlayObject.transform.position = Vector3.Lerp(OverlayObject.transform.position, vPosOverlay, smoothFactor * Time.deltaTime);
                     
                        }
                    }
                }

            }

        }
    }
}
