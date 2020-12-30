using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicController : MonoBehaviour
{
    [Header("Camera AnimationTimes")]
    public float ZoomIn = 1f;
    public float ZoomOut = 1f;

    [Header("Players Animation Times")]
    public string LeftCharacterWalkAnim = "LeftCharacterWalk";
    public string RightCharacterWalkAnim = "RightCharacterWalk";
    public string HoldTheStickTogether = "HoldTheStickTogether";

    [Header("Animations")]
    public Animation CameraAnimation;
    public Animation PlayerAnimation;

    [Header("C1 Talks")]
    public string C1T1;
    public string C1T2;
    public string C1T3;
    public string C1T4;

    [Header("C2 Talks")]
    public string C2T1;
    public string C2T2;
    public string C2T3;
    public string C2T4;

    public float talkTimes = 2f;
    [Header("UI's")]
    public Text LeftTalksText;
    public Text RightTalksText;
    public Button SkipButton;
    public Image Image;

    void Start()
    {
        StartCoroutine(AnimationCoroutine());
        LeftTalksText.transform.parent.gameObject.SetActive(false);
        RightTalksText.transform.parent.gameObject.SetActive(false);
    }

    private IEnumerator AnimationCoroutine()
    {
        CameraAnimation.Play();
        yield return new WaitForSeconds(1f);
        PlayerAnimation.Play(LeftCharacterWalkAnim);
        yield return new WaitForSeconds(0.5f);
        LeftTalksText.transform.parent.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        LeftTalksText.text = C1T1;
        yield return new WaitForSeconds(talkTimes);
        LeftTalksText.text = C1T2;
        yield return new WaitForSeconds(talkTimes);
        PlayerAnimation.Play(RightCharacterWalkAnim);
        yield return new WaitForSeconds(0.5f);
        RightTalksText.transform.parent.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RightTalksText.text = C2T1;
        yield return new WaitForSeconds(talkTimes);
        RightTalksText.text = C2T2;
        yield return new WaitForSeconds(talkTimes);
        LeftTalksText.text = C1T3;
        yield return new WaitForSeconds(talkTimes);
        RightTalksText.text = C2T3;
        PlayerAnimation.Play(HoldTheStickTogether);
        yield return new WaitForSeconds(1f);
        LeftTalksText.text = C1T4;
        RightTalksText.text = C2T4;

        Color color = Image.color;
        while(color.a < 0.95f)
        {
            color.a += Time.deltaTime * 0.5f;
            Image.color = color;
            yield return null;
        }
        EndAndChangeScene();
    }

    private void EndAndChangeScene()
    {
        StopAllCoroutines();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void Skip()
    {
        EndAndChangeScene();
    }
}
