using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// pass into dialogue whenever we want to start a new dialogue
// Serializeble means editable.
[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;
}
