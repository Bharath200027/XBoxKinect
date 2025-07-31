using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using TMPro;

public class SubtitleBehaviour : PlayableBehaviour
{
    public string subtitleText;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Text txt = playerData as Text;
        txt.text = subtitleText;
        //txt.color = new Color(0.03f, 0.11f, 0.45f, info.weight);
        //txt.color = new Color(0.6f, 0.2f, 0.03f, info.weight);
    }
}
