using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kit 2A�� â�Ǽ���4�� ������,�ŵ���,�̻���,���ؿ�
public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody;  //�̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f;  //ź�� �̵� �ӷ�
    // Start is called before the first frame update
    void Start()
    {
        //���� ������Ʈ���� ������ٵ� ������Ʈ�� ã�� �ҷ�������ٵ� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        //������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�
        bulletRigidbody.velocity = transform.forward * speed;

        //3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)//Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���  
    {
       //�浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
       if(other.tag == "Player")
        {
            //���� ���� ������Ʈ���� �÷��̾���Ʈ�ѷ� ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();
            //�������κ��� �÷��̾���Ʈ�ѷ� ������Ʈ�� �������� �� �����ߴٸ�
            if(playerController != null)
            {
                //���� �÷��̾���Ʈ�ѷ� ������Ʈ�� ����() �޼��� ����
                playerController.Die();
            }
        }
    }
}
