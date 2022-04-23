using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGuy : MonoBehaviour
{
    public float minTime, maxTime;
    [SerializeField] bool alreadyPlayedAttentionGrabber;
    public Transform player;

    AudioSource soundPlayer;
    public AudioClip[] giveSounds;
    public AudioClip attentionGrabberSound;

    private void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
    }
    public void MoveTime()
    {
        StartCoroutine(GetAMoveOn());
    }
    IEnumerator GetAMoveOn()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        Transform spotToGoTo = WanderPoints.Instance.GetWanderPoint();
        transform.position = new Vector3(spotToGoTo.position.x, 5, spotToGoTo.position.z);
        alreadyPlayedAttentionGrabber = false;
        StartCoroutine(GetAMoveOn());
    }
    private void Update()
    {
        if(Vector3.Distance(transform.position, player.position) <= 20 && !alreadyPlayedAttentionGrabber)
        {
            soundPlayer.clip = attentionGrabberSound;
            soundPlayer.Play();
            alreadyPlayedAttentionGrabber = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        soundPlayer.clip = giveSounds[Random.Range(0, giveSounds.Length)];
        soundPlayer.Play();
        ItemManager.Instance.ReplaceItem(ItemManager.Instance.selectedItem, Random.Range(1, 5));
        transform.position = new Vector3(transform.position.x, -45, transform.position.z);
        alreadyPlayedAttentionGrabber = false;
    }
}
