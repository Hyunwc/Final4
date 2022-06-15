using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// kit 2A�� â�Ǽ���4�� ������,�ŵ���,�̻���,���ؿ�
public class PlayerController : MonoBehaviour { 
    private Rigidbody playerRigidbody;  //�̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f;  //�̵� �ӷ�
    public GameObject HamburgerText;
    public GameObject ChickenText;
    public GameObject PizzaText;
    public GameObject MakiText;
    public GameObject SushiText;
    public GameObject RamenText;
    public GameObject RiceText;
    private Animator animator;
    public GameObject avata;
    // Start is called before the first frame update
    void Start()
    {
        //���� ������Ʈ���� ������ٵ� ������Ʈ�� ã�� �÷��̾����ٵ� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>();
        animator = avata.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 �ӵ��� (xSpeed, 0 ,zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        //������ٵ��� �ӵ��� newVelocity �Ҵ�
        playerRigidbody.velocity = newVelocity;
        if (zInput != 0.0f)
        {
            animator.SetBool("Run", true);
        }
        if (zInput == 0.0f)
        {
            animator.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("Start");
        }
    }
    public void Die()
    {
        //�ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);
        //���� �����ϴ� ���ӸŴ��� Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager = FindObjectOfType<GameManager>();
        //������ ���ӸŴ��� ������Ʈ�� EndGame() �޼��� ����
        gameManager.EndGame();
     }
    void OnTriggerEnter(Collider other)
    {
        //�ܹ��� �±׸� ���� ������Ʈ�� �浹�� �ܹ����ؽ�Ʈ Ȱ��ȭ
        if (other.tag == "Hamburger")
        {
            HamburgerText.SetActive(true);
        }
        //ġŲ �±׸� ���� ������Ʈ�� �浹�� ġŲ�ؽ�Ʈ Ȱ��ȭ
        if (other.tag == "Chicken")
        {
            ChickenText.SetActive(true);
        }
        //���� �±׸� ���� ������Ʈ�� �浹�� �����ؽ�Ʈ Ȱ��ȭ
        if (other.tag == "Pizza")
        {
            PizzaText.SetActive(true);
        }
        //��� �±׸� ���� ������Ʈ�� �浹�� ����ؽ�Ʈ Ȱ��ȭ
        if (other.tag == "Maki")
        {
            MakiText.SetActive(true);
        }
        if (other.tag == "Sushi")
        {
            SushiText.SetActive(true);
        }
        if (other.tag == "Ramen")
        {
            RamenText.SetActive(true);
        }
        if (other.tag == "Rice")
        {
            RiceText.SetActive(true);
        }
    }



}
