using UnityEngine;
using Unity.Collections;
using UnityEngine.Experimental.Video;
using UnityEngine.Experimental.Audio;
using UnityEngine.Video;

public class ManagedAudioOutput : MonoBehaviour
{
    AudioSampleProvider provider;

    void Start()
    {
        VideoPlayer vp = GetComponent<VideoPlayer>();
        vp.audioOutputMode = VideoAudioOutputMode.APIOnly;
        vp.prepareCompleted += Prepared;
        vp.Prepare();
    }

    void Prepared(VideoPlayer vp)
    {
        provider = vp.GetAudioSampleProvider(0);
        provider.sampleFramesAvailable += SampleFramesAvailable;
        provider.enableSampleFramesAvailableEvents = true;
        provider.freeSampleFrameCountLowThreshold = provider.maxSampleFrameCount / 4;
        vp.Play();
    }

    void SampleFramesAvailable(AudioSampleProvider provider, uint sampleFrameCount)
    {
        using (NativeArray<float> buffer = new NativeArray<float>(
            (int)sampleFrameCount * provider.channelCount, Allocator.Temp))
        {
            var sfCount = provider.ConsumeSampleFrames(buffer);
            Debug.LogFormat("SetupSoftwareAudioOut.Available got {0} sample frames.", sfCount);
            // Do something with the samples here...
        }
    }
}