
/*-------Boid.cs-------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    static public List<Boid> boids;     //ʵ����Boid �ı�

    public Vector3 velocity;        //��ǰ�ٶ�
    public Vector3 newVelocity;     //��һ֡�е��ٶ�
    public Vector3 newPosition;     //��һ֡�е�λ��

    public List<Boid> neighbors;        //�������е� Boid �ı�
    public List<Boid> collisionRisks;   //������������� Boid �ı�(������ײ���գ���Ҫ����)
    public Boid closest;                //����� Boid

    //��ʼ��Boid
    private void Awake()
    {
        //���List����boidsδ���壬�������ж���
        if (boids == null)
            boids = new List<Boid>();

        //��Boids List �����Boid
        boids.Add(this);

        //Ϊ��ǰBoidʵ���ṩһ�������λ�ú��ٶ�
        //ʵ������boidλ���� �뾶Ϊ 1*spawnRadius �����η�Χ��
        Vector3 randPos = Random.insideUnitSphere * BoidSpawner.S.spawnRadius;

        //ֻ��Boid��xzƽ�����ƶ������趨��ʼ����
        randPos.y = 0;
        this.transform.position = randPos;

        //Random.onUnitSphere ���� һ���뾶Ϊ1�� �������ĵ�
        velocity = Random.onUnitSphere;
        velocity *= BoidSpawner.S.spawnVelcoty;

        //��ʼ������List
        neighbors = new List<Boid>();
        collisionRisks = new List<Boid>();

        //��this.transform��ΪBoid��Ϸ������Ӷ���
        this.transform.parent = GameObject.Find("Boids").transform;

        //��Boid����һ���������ɫ
        Color randColor = Color.black;
        //������ɫ����ɫҪ �����͸��
        while (randColor.r + randColor.g + randColor.b < 1.0f)
            randColor = new Color(Random.value, Random.value, Random.value);
        //��Ⱦ boid
        Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rends)
            r.material.color = randColor;
    }

    private void Update()
    {
        //��ȡ�� ��ǰboid �������е�Boids �ı�
        List<Boid> neighbors = GetNeighbors(this);

        //ʹ�õ�ǰλ�ú��ٶȳ�ʼ����λ�ú����ٶ�
        newVelocity = velocity;
        newPosition = this.transform.position;

        //�ٶ�ƥ��
        //ȡ���� ��ǰBoid ���ٶȽӽ��� �����ڽ�Boid���� ��ƽ���ٶ�
        Vector3 neighborVel = GetAverageVelocity(neighbors);
        //�� ���ٶ� += �ڽ�boid��ƽ���ٶ�*velocityMatchingAmt
        newVelocity += neighborVel * BoidSpawner.S.velocityMatchingAmt;

        /*
        ���������ԣ�ʹ ��ǰboid �� �ڽ�Boid���� ������ �ƶ�
        */
        //ȡ���� ��ǰBoid ����λ����ӽ��� �����ڽ�Boid���� ��ƽ����λ���
        Vector3 neighborCenterOffset = GetAveragePosition(neighbors) - this.transform.position;
        //�� ���ٶ� += �ڽ�boid��ƽ�����*flockCenteringAmt
        newVelocity += neighborCenterOffset * BoidSpawner.S.flockCenteringAmt;

        /*
        �ų��ԣ�����ײ�� �ڽ���Boid
        */
        Vector3 dist;
        if (collisionRisks.Count > 0)   //���� �����boid ��
        {
            //ȡ�� ���������boid ��ƽ��λ��
            Vector3 collisionAveragePos = GetAveragePosition(collisionRisks);
            dist = collisionAveragePos - this.transform.position;
            //�� ���ٶ� += �����boid��ƽ�����*flockCenteringAmt
            newVelocity += dist * BoidSpawner.S.collisionAvoidanceAmt;
        }

        //��������꣺���۾����Զ����������ƶ�
        dist = BoidSpawner.S.mousePos - this.transform.position;

        //�����������̫Զ���򿿽�����֮�뿪(�޸����ٶ�)
        if (dist.magnitude > BoidSpawner.S.mouseAvoiddanceDsit)
            newVelocity += dist * BoidSpawner.S.mouseAtrractionAmt;
        else
            newVelocity -= dist.normalized * BoidSpawner.S.mouseAvoidanceAmt;

        //������Update()�� ȷ���� ���ٶȺ���λ�ã���Ҫ�ں���LateUpdate()��Ӧ��
        //һ�㶼��Update()��ȷ����������LateUpdate()��ʵ���ƶ�
    }

    private void LateUpdate()
    {
        //ʹ�����Բ�ֵ��
        //���ڼ���������ٶ� �����޸� ��ǰ�ٶ�
        velocity = (1 - BoidSpawner.S.velocityLerpAmt) * velocity + BoidSpawner.S.velocityLerpAmt * newVelocity;

        //ȷ�� �ٶ�ֵ �������޷�Χ��(������Χ���趨Ϊ��Χֵ)
        if (velocity.magnitude > BoidSpawner.S.maxVelocity)
            velocity = velocity.normalized * BoidSpawner.S.maxVelocity;
        if (velocity.magnitude < BoidSpawner.S.minVelocity)
            velocity = velocity.normalized * BoidSpawner.S.minVelocity;

        //ȷ����λ��(�����·���)���൱��1s�ƶ� velocity �ľ���
        newPosition = this.transform.position + velocity * Time.deltaTime;

        //�����ж���������XZƽ��
        //�޸ĵ�ǰboid�ķ��򣺴�ԭ��λ�ÿ�����λ��newPosition
        this.transform.LookAt(newPosition);

        //position�ƶ���ʽ���ƶ�����λ��
        this.transform.position = newPosition;
    }

    //������ЩBoid���뵱ǰBoid�����㹻�������Ա�������������
    public List<Boid> GetNeighbors(Boid boi)
    {
        float closesDist = float.MaxValue;  //��С��࣬MaxValue Ϊ�����������ֵ
        Vector3 delta;              //��ǰ boid ������ĳ�� boid ����ά��� 
        float dist;                 //��λ���ת��Ϊ�� ʵ�����

        neighbors.Clear();          //�����ϴα������
        collisionRisks.Clear();     //�����ϴα������

        //����Ŀǰ���е� boid�������趨�ķ�Χֵɸѡ�� ������boid �� �����boid �ڸ��Ա���
        foreach (Boid b in boids)
        {
            if (b == boi)   //��������
                continue;

            delta = b.transform.position - boi.transform.position;  //�������� b �뵱ǰ���е� boi(��Ϊboid) ����ά���
            dist = delta.magnitude;     //ʵ�����

            if (dist < closesDist)
            {
                closesDist = dist;      //������С���
                closest = b;            //��������� boid Ϊ b
            }

            if (dist < BoidSpawner.S.nearDist)  //���ڸ����� boid ��Χ
                neighbors.Add(b);

            if (dist < BoidSpawner.S.collisionDist) //��������� boid ��Χ(����ײ����)
                collisionRisks.Add(b);
        }

        if (neighbors.Count == 0)   //��û�����������ڽ���Χ��boid��������boid���븽����boid����
            neighbors.Add(closest);

        return (neighbors);
    }

    //��ȡ List<Boid>���� ����Boid ��ƽ��λ��
    public Vector3 GetAveragePosition(List<Boid> someBoids)
    {
        Vector3 sum = Vector3.zero;
        foreach (Boid b in someBoids)
            sum += b.transform.position;
        Vector3 center = sum / someBoids.Count;

        return (center);
    }

    //��ȡ List<Boid> ���� ����Boid ��ƽ���ٶ�
    public Vector3 GetAverageVelocity(List<Boid> someBoids)
    {
        Vector3 sum = Vector3.zero;
        foreach (Boid b in someBoids)
            sum += b.velocity;
        Vector3 avg = sum / someBoids.Count;

        return (avg);
    }
}
