using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] protected int speedText;
    [SerializeField] protected float holdTime;
    [SerializeField] GameObject mainPanel = null;

    protected float startTime;
    protected GameObject credPanel;
    protected Vector3 initPos;
    protected Vector3 finalPos;

    private void Start()
    {
        initPos = transform.localPosition;
        credPanel = GameObject.Find("CreditsPanel");
        finalPos = credPanel.GetComponent<RectTransform>().position;
    }

    private void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            startTime += Time.deltaTime;

            if (startTime > holdTime)
            {
                mainPanel.SetActive(true);
                credPanel.SetActive(false);
                startTime = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if (GetComponent<RectTransform>().position.y <= finalPos.y)
        {
            transform.Translate(Vector2.up * speedText * Time.deltaTime);
        }

        if (GetComponent<RectTransform>().position.y >= finalPos.y)
        {
            startTime += Time.deltaTime;
            if (startTime > 1f)
            {
                mainPanel.SetActive(true);
                credPanel.SetActive(false);
                startTime = 0;
            }
        }
    }

    private void OnDisable()
    {
        transform.localPosition = initPos;
    }
}
