using System.Collections;
using System.Collections.Generic;
//using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleClip : PlayableAsset
{
    public string subtitleText;
   // public TextMeshProUGUI subtitleText;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SubtitleBehaviour>.Create(graph);
        SubtitleBehaviour subtitleBehaviour = playable.GetBehaviour();
        subtitleBehaviour.subtitleText = subtitleText;
        return playable;
    }
}
