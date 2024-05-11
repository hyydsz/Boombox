using Photon.Pun;
using ShopUtils;
using System.Collections.Generic;
using UnityEngine;
using Zorro.Core.Serizalization;

namespace Boombox
{
    public class BoomboxBehaviour : ItemInstanceBehaviour
    {
        public static List<AudioClip> clips = new List<AudioClip>();

        private BatteryEntry batteryEntry;
        private OnOffEntry onOffEntry;
        private TimeEntry timeEntry;
        private VolumeEntry volumeEntry;
        private MusicEntry musicEntry;

        private SFX_PlayOneShot Click;
        private AudioSource Music;

        private int currentIndex = 0;

        void Awake()
        {
            Click = transform.Find("SFX/Click").GetComponent<SFX_PlayOneShot>();
            Music = GetComponent<AudioSource>();
        }

        public override void ConfigItem(ItemInstanceData data, PhotonView playerView)
        {
            if (!Boombox.InfiniteBattery)
            {
                if (!data.TryGetEntry(out batteryEntry))
                {
                    batteryEntry = new BatteryEntry()
                    {
                        m_charge = Boombox.BatteryCapacity,
                        m_maxCharge = Boombox.BatteryCapacity
                    };

                    data.AddDataEntry(batteryEntry);
                }
            }

            if (!data.TryGetEntry(out onOffEntry))
            {
                onOffEntry = new OnOffEntry()
                {
                    on = false
                };

                data.AddDataEntry(onOffEntry);
            }

            if (!data.TryGetEntry(out timeEntry))
            {
                timeEntry = new TimeEntry()
                {
                    currentTime = 0f
                };

                data.AddDataEntry(timeEntry);
            }

            if (!data.TryGetEntry(out musicEntry))
            {
                musicEntry = new MusicEntry()
                {
                    selectMusicIndex = 0
                };

                data.AddDataEntry(musicEntry);
            }

            if (!data.TryGetEntry(out volumeEntry))
            {
                volumeEntry = new VolumeEntry()
                {
                    volume = 5
                };

                data.AddDataEntry(volumeEntry);
            }

            musicEntry.UpdateMusicName();
        }

        void Update()
        {
            if (isHeldByMe && !Player.localPlayer.HasLockedInput())
            {
                if (Player.localPlayer.input.clickWasPressed)
                {
                    if (clips.Count == 0) 
                    {
                        HelmetText.Instance.SetHelmetText("No Music", 2f);
                    }
                    else
                    {
                        onOffEntry.on = !onOffEntry.on;
                        onOffEntry.SetDirty();
                    }

                    Click.Play();
                }

                if (Player.localPlayer.input.aimWasPressed)
                {
                    if (clips.Count > 0)
                    {
                        musicEntry.selectMusicIndex += 1;
                        musicEntry.selectMusicIndex %= clips.Count;
                        musicEntry.UpdateMusicName();
                        musicEntry.SetDirty();

                        timeEntry.currentTime = 0;
                        timeEntry.SetDirty();
                    }

                    Click.Play();
                }

                if (GlobalInputHandler.GetKeyUp(Boombox.VolumeUpKey.Value))
                {
                    if (volumeEntry.volume <= 9) {
                        volumeEntry.volume += 1;
                        volumeEntry.SetDirty();
                    }

                    Click.Play();
                }

                if (GlobalInputHandler.GetKeyUp(Boombox.VolumeDownKey.Value))
                {
                    if (volumeEntry.volume >= 1) {
                        volumeEntry.volume -= 1;
                        volumeEntry.SetDirty();
                    } 

                    Click.Play();
                }
            }

            if (!Boombox.InfiniteBattery) {
                if (batteryEntry.m_charge < 0f)
                {
                    onOffEntry.on = false;
                }
            }

            if (volumeEntry.GetVolume() != Music.volume)
            {
                Music.volume = volumeEntry.GetVolume();
            }

            bool flag = onOffEntry.on;
            if (flag != Music.isPlaying || currentIndex != musicEntry.selectMusicIndex)
            {
                currentIndex = musicEntry.selectMusicIndex;

                if (flag)
                {
                    if (checkMusic(musicEntry.selectMusicIndex))
                    {
                        Music.clip = clips[musicEntry.selectMusicIndex];
                        Music.time = timeEntry.currentTime;
                        Music.Play();
                    }
                }
                else
                {
                    Music.Stop();
                }
            }

            if (flag)
            {
                if (!Boombox.InfiniteBattery) {
                    batteryEntry.m_charge -= Time.deltaTime;
                }

                timeEntry.currentTime = Music.time;
            }
        }

        public static bool checkMusic(int index)
        {
            return index <= clips.Count - 1;
        }
    }

    public class VolumeEntry : ItemDataEntry, IHaveUIData
    {
        public int volume;
        public int max_volume = 10;

        private string VolumeLanguage = "{0}% Volume";

        public VolumeEntry()
        {
            Languages.TryGetLanguage("BoomboxVolume", out VolumeLanguage);
        }

        public override void Deserialize(BinaryDeserializer binaryDeserializer)
        {
            volume = binaryDeserializer.ReadInt();
        }

        public override void Serialize(BinarySerializer binarySerializer)
        {
            binarySerializer.WriteInt(volume);
        }

        public float GetVolume()
        {
            return volume / 10f;
        }

        public string GetString()
        {
            return string.Format(VolumeLanguage, volume * 10);
        }
    }

    public class MusicEntry : ItemDataEntry, IHaveUIData
    {
        private string MusicName;

        public int selectMusicIndex;

        public override void Deserialize(BinaryDeserializer binaryDeserializer)
        {
            selectMusicIndex = binaryDeserializer.ReadInt();
        }

        public override void Serialize(BinarySerializer binarySerializer)
        {
            binarySerializer.WriteInt(selectMusicIndex);
        }

        public void UpdateMusicName()
        {
            MusicName = string.Empty;

            if (BoomboxBehaviour.clips.Count > 0 && BoomboxBehaviour.checkMusic(selectMusicIndex))
            {
                MusicName = getMusicName(BoomboxBehaviour.clips[selectMusicIndex].name);
            }
        }

        public string GetString()
        {
            return MusicName;
        }

        private string getMusicName(string name)
        {
            int length;
            if ((length = name.LastIndexOf('.')) != -1)
            {
                name = name.Substring(0, length);
            }

            if (name.Length > 15) {
                name = name.Substring(0, 15);
                name = name + "...";
            }

            return name;
        }
    }
}
