using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*********************************************************************************
this script is used to simplify the Tutorial process to make the gameplay more descriptive.
all what you need is to add statements that describe your scene mechanics or any gameplay tip you want.
then you can override the TutorialSkip to activate spawners or any script you have disactivated
*********************************************************************************/

public class RespirationTutorial : Tutorial
{
    [HideInInspector]
    //  Remove those strings and add strings that describes your scene mechanics
    //  like what should the player do in your scene
    //  or how can he play? how can he increase the state that is related to your scene
    //  [Note]: try writing each statement you add at the text in the Tutorial Tablet 
    //          to make sure that it fits the text box size
    public string[] RespirationTutorialScripts = new string[] {
        "Hi",
        "Your task is to filter the air",
        "Remove CO2 molecules from red blood cells and throw them on the lungs",
        "Grab O2 molecules and put them on red blood cells"
    };
    private static bool isTutorialDone = false;
    public Sprite[] RespirationDescriptiveImages;
    new void Start()
    {
        base.Start();
        TutorialScripts = new string[] {
                "Hi",
                "Your task is to filter the air",
                "Remove CO2 molecules from red blood cells and throw them on the lungs",
                "Grab O2 molecules and put them on red blood cells"
            };
    }
    new void Update()
    {
        base.Update();
        OnTutorialMode = isTutorialDone ? false : OnTutorialMode;
        if (OnTutorialMode && RespirationDescriptiveImages[TutorialIndex] != null)
        {
            DescriptiveImage.sprite = RespirationDescriptiveImages[TutorialIndex];
            DescriptiveImage.gameObject.SetActive(true);
        }
        else if (OnTutorialMode && RespirationDescriptiveImages[TutorialIndex] == null)
        {
            DescriptiveImage.gameObject.SetActive(false);
        }
        else if (!OnTutorialMode && DescriptiveImage.gameObject.activeSelf)
        {
            DescriptiveImage.gameObject.SetActive(false);
        }
    }

    public override void TutorialSkip()
    {
        base.TutorialSkip();
        isTutorialDone = true;

        // remove the next line override the method however you want
        Debug.Log("Respiration Tutorial");
    }
    public override void TutorialNext()
    {
        base.TutorialNext();
    }
}
