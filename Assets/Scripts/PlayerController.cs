using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Character1;
    public Transform Stick;
    public Transform Character2;

    public Transform Selector1;
    public Transform Selector2;
    public float RotateSpeed = 1f;

    private Transform _selectedCharacter;
    private Rigidbody _rigidbody;
    private bool _gameOver = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        SwitchCharacter();
    }

    private bool _leftTurn = false;
    void Update()
    {
        if (_gameOver || GameController.Instance.TutorialActive)
        {
            return;
        }

#if UNITY_EDITOR_WIN || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.useGravity = false;
            _leftTurn = Input.mousePosition.x < (float)Screen.width / 2f ? true : false;
        }
        else if (Input.GetMouseButton(0))
        {
            transform.RotateAround(_selectedCharacter.transform.position, Vector3.up, Time.deltaTime * RotateSpeed * 360f * (_leftTurn ? -1f : 1f));
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SwitchCharacter();
            _rigidbody.useGravity = true;
        }
#else 
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                _rigidbody.useGravity = false;
                _leftTurn = t.position.x < (float)Screen.width / 2f ? true : false;
            }
            else if (t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary)
            {
                transform.RotateAround(_selectedCharacter.transform.position, Vector3.up, Time.deltaTime * RotateSpeed * 360f * (_leftTurn ? -1f : 1f));
            }
            else if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
            {
                SwitchCharacter();
                _rigidbody.useGravity = true;
            }
        }
#endif

        if (transform.position.y < -3f && !_gameOver)
        {
            GameController.Instance.GameOver();
            _gameOver = true;
        }
    }

    public void SwitchCharacter()
    {
        var euler = transform.rotation.eulerAngles;
        euler.x = 0;
        transform.rotation = Quaternion.Euler(euler);
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;

        Character1.SetParent(transform);
        Character2.SetParent(transform);
        Stick.SetParent(transform);
        Selector1.gameObject.SetActive(false);
        Selector2.gameObject.SetActive(false);

        if (_selectedCharacter == null || _selectedCharacter == Character2)
        {
            _selectedCharacter = Character1;
            Character2.SetParent(_selectedCharacter);
            Selector1.gameObject.SetActive(true);
        }
        else
        {
            _selectedCharacter = Character2;
            Character1.SetParent(_selectedCharacter);
            Selector2.gameObject.SetActive(true);
        }
        Stick.SetParent(_selectedCharacter);
        Selector1.position = _selectedCharacter.position + new Vector3(0, 2f, 0);
    }
}
