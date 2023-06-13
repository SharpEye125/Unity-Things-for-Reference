﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public float textSpeed = 1f;
    public Text nameText;
    public Text dialougeText;
    public Image portrait;
    public AudioClip voice;
    public bool talking;
    public Animator animator;

    private Queue<string> sentences;

    public void StartDialogue(Dialogue dialogue)
    {
        talking = true;
        animator.SetBool("isOpen", talking);
        nameText.text = dialogue.name;
        portrait.sprite = dialogue.portrait;
        voice = dialogue.voice;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        //dialougeText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)
    {
        dialougeText.text = "";
        
        foreach (char letter in sentence.ToCharArray())
        {
            dialougeText.text += letter;
            if (letter != ' ' && voice != null)
            {
                FindObjectOfType<RoomMusicTransition>().gameObject.GetComponent<AudioSource>().PlayOneShot(voice);
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }
    public void EndDialogue()
    {
        talking = false;
        animator.SetBool("isOpen", talking);
    }

    // Start is called before the first frame update
    void Start()
    {

        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
