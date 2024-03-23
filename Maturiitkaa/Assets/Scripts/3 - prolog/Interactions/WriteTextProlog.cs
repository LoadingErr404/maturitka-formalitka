using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class WriteTextProlog : MonoBehaviour
{
    public string givenSentence;
    [SerializeField] private TMP_Text textArea;
    [SerializeField] private float writeOutDelay;
    private float _writeCounter;
    private int _position;
    [SerializeField] private WriteOutSentences writeOutSentences;
    
    protected void Update()
    {
        if (!writeOutSentences.writeNewSentence)
        {
            return;
        }

        if (_writeCounter < writeOutDelay)
        {
            
            _writeCounter += Time.deltaTime;
            return;
        }
        
        if (_position >= givenSentence.Length)
        {
            writeOutSentences.writeNewSentence = false;
            writeOutSentences.interactText.textForInteraction = givenSentence;
            writeOutSentences.ableToWriteInto = true;
            _position = 0;
            return;
        }
        Debug.Log(givenSentence);
        textArea.text += givenSentence[_position++];
        writeOutSentences.ableToWriteInto = false;    
        _writeCounter = 0f;
        

    }
    
}
