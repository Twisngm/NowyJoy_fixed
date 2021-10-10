using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMoving : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    float moveX, moveY;
    public GameObject TitlePlayer;
    Rigidbody2D rb;
    [Header("�̵��ӵ� ����")]
    [SerializeField] [Range(1f, 150f)] float moveSpeed = 20f;

    [SerializeField]
    private Touch touchZero; // ù��° ��ġ
    bool onTouch; // ��ġ������ �˻��ϴ� bool�� ����

    public Vector3 m_curPos; // �÷��̾��� ���� ��ġ
    public Vector3 m_prevPos; // �÷��̾��� ���� ��ġ
    CircleCollider2D Playercollider; // collider
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Playercollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            OnDrag();

            TitlePlayerMove();


        }
    }

    private void TitlePlayerMove()
    {
        moveX = Input.GetAxis("Horizontal") * (moveSpeed * 5) * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * (moveSpeed * 5) * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
    }

    private void OnDrag()
    {
        if (Input.touchCount == 1) // ��ġ �Է��� �ϳ��� ��
        {
            touchZero = Input.GetTouch(0); // ���� �Է¹��� ��ġ�� ù��° ��ġ�� ����
            if (touchZero.phase == TouchPhase.Began) // ù��° ��ġ�� phase�� Began(����)�̶��
            {
                onTouch = true; // onTouch�� true�� (�̵� o)
                m_prevPos = m_curPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position); // �̵���Ű��
            }
            else if (touchZero.phase == TouchPhase.Ended) // ù��° ��ġ�� phase�� Ended(��)�̶��
            {
                onTouch = false; // onTouch�� false�� (�̵� x)
            }
        }
        
        if (onTouch)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            m_curPos = mousePosition; // ���� ��ġ ��ġ
            Vector3 gap = m_curPos - m_prevPos; // ���� ��ġ�� ���� ��ġ �� ���

            transform.position += gap; // position�� gap��ŭ�� �߰��� �̵���Ŵ
            m_prevPos = m_curPos; // ���� ��ġ�� ���� ��ġ�� ����
        }
    }

}
