using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using ShopUtils;
using ShopUtils.Language;
using ShopUtils.Network;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Localization;

namespace Boombox
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    [BepInDependency("hyydsz-ShopUtils")]
    public class Boombox : BaseUnityPlugin
    {
        public static ManualLogSource log;

        public const string ModGUID = "hyydsz-Boombox";
        public const string ModName = "Boombox";
        public const string ModVersion = "1.1.4";

        private readonly Harmony harmony = new Harmony(ModGUID);

        public static AssetBundle asset;

        public static bool InfiniteBattery = false;
        public static float BatteryCapacity = 250f;

        public static ConfigEntry<KeyCode> VolumeUpKey;
        public static ConfigEntry<KeyCode> VolumeDownKey;

        void Awake()
        {
            LoadConfig();
            LoadBoombox();
            LoadLangauge();

            harmony.PatchAll();
        }

        void Start()
        {
            MusicLoadManager.StartLoadMusic();
        }

        private void LoadConfig()
        {
            VolumeUpKey = Config.Bind("Config", "VolumeUp", KeyCode.Equals);
            VolumeDownKey = Config.Bind("Config", "VolumeDown", KeyCode.Minus);

            log = Logger;

            Networks.SetNetworkSync(new Dictionary<string, object>
            {
                {"BoomboxInfiniteBattery", Config.Bind("Config", "InfiniteBattery", false).Value},
                {"BoomboxBattery", Config.Bind("Config", "BatteryCapacity", 250f).Value }
            }, 
            (dic) =>
            {
                try
                {
                    InfiniteBattery = bool.Parse(dic["BoomboxInfiniteBattery"]);
                    BatteryCapacity = float.Parse(dic["BoomboxBattery"]);

                    Logger.LogInfo($"Boombox Load [InfiniteBattery: {InfiniteBattery}, BatteryCapacity: {BatteryCapacity}]");
                }
                catch
                {
                    Logger.LogError($"Boombox Network Error");
                }
            });
        }

        private void LoadBoombox()
        {
            asset = QuickLoadAssetBundle("boombox");

            Item item = asset.LoadAsset<Item>("Boombox");
            item.itemObject.AddComponent<BoomboxBehaviour>();

            Entries.RegisterAll();
            Items.RegisterShopItem(item, ShopItemCategory.Misc, Config.Bind("Config", "BoomboxPrice", 100).Value);
            Networks.RegisterItemPrice(item);
        }

        private void LoadLangauge()
        {
            Locale Chinese = Languages.GetLanguage(LanguageEnum.ChineseSimplified);
            Chinese.AddLanguage("Boombox_ToolTips", "[LMB] 播放;[RMB] 切换音乐");
            Chinese.AddLanguage("Boombox", "音响");
            Chinese.AddLanguage("BoomboxVolume", "{0}% 音量");

            Locale ChineseTraditional = Languages.GetLanguage(LanguageEnum.ChineseTraditional);
            ChineseTraditional.AddLanguage("Boombox_ToolTips", "[LMB] 播放;[RMB] 切換音樂");
            ChineseTraditional.AddLanguage("Boombox", "音響");
            ChineseTraditional.AddLanguage("BoomboxVolume", "{0}% 音量");

            Locale English = Languages.GetLanguage(LanguageEnum.English);
            English.AddLanguage("Boombox_ToolTips", "[LMB] Player;[RMB] Switch Music");
            English.AddLanguage("Boombox", "Boombox");
            English.AddLanguage("BoomboxVolume", "{0}% Volume");

            Locale French = Languages.GetLanguage(LanguageEnum.French);
            French.AddLanguage("Boombox_ToolTips", "[LMB] Jouer de la musique;[RMB] Changer de musique");
            French.AddLanguage("Boombox", "Audio portable");
            French.AddLanguage("BoomboxVolume", "{0}% Volume");

            Locale German = Languages.GetLanguage(LanguageEnum.German);
            German.AddLanguage("Boombox_ToolTips", "[LMB] Musik abspielen;[RMB] Musik wechseln");
            German.AddLanguage("Boombox", "Boom Box");
            German.AddLanguage("BoomboxVolume", "{0}% Volume");

            Locale Italian = Languages.GetLanguage(LanguageEnum.Italian);
            Italian.AddLanguage("Boombox_ToolTips", "[LMB] Riproduci musica;[RMB] Cambia musica");
            Italian.AddLanguage("Boombox", "boom box");
            Italian.AddLanguage("BoomboxVolume", "{0}% volume");

            Locale Japanese = Languages.GetLanguage(LanguageEnum.Japanese);
            Japanese.AddLanguage("Boombox_ToolTips", "[LMB] 音楽を流す;[RMB] 音楽を切り替える");
            Japanese.AddLanguage("Boombox", "ポータブルオーディオ");
            Japanese.AddLanguage("BoomboxVolume", "{0}% 音量");

            Locale Portuguese = Languages.GetLanguage(LanguageEnum.Portuguese);
            Portuguese.AddLanguage("Boombox_ToolTips", "[LMB] Tocar música;[RMB] Mudar a Música");
            Portuguese.AddLanguage("Boombox", "Sistema de áudio portátil");
            Portuguese.AddLanguage("BoomboxVolume", "{0}% volume");

            Locale Russian = Languages.GetLanguage(LanguageEnum.Russian);
            Russian.AddLanguage("Boombox_ToolTips", "[LMB] Музыка;[RMB] Переключить музыку");
            Russian.AddLanguage("Boombox", "Портативный звук");
            Russian.AddLanguage("BoomboxVolume", "{0}% Громкость");

            Locale Spanish = Languages.GetLanguage(LanguageEnum.Spanish);
            Spanish.AddLanguage("Boombox_ToolTips", "[LMB] Reproducir música;[RMB] Cambiar música");
            Spanish.AddLanguage("Boombox", "Traductor portátil");
            Spanish.AddLanguage("BoomboxVolume", "{0}% Volumen");

            Locale Ukrainian = Languages.GetLanguage(LanguageEnum.Ukrainian);
            Ukrainian.AddLanguage("Boombox_ToolTips", "[LMB] Грати музику;[RMB] Перемкнути музику");
            Ukrainian.AddLanguage("Boombox", "Портувана аудіосистема");
            Ukrainian.AddLanguage("BoomboxVolume", "{0}% гучність");

            Locale Korean = Languages.GetLanguage(LanguageEnum.Korean);
            Korean.AddLanguage("Boombox_ToolTips", "[LMB] 음악 재생;[RMB] 음악 전환");
            Korean.AddLanguage("Boombox", "휴대용 오디오");
            Korean.AddLanguage("BoomboxVolume", "{0}% 볼륨");

            Locale Swedish = Languages.GetLanguage(LanguageEnum.Swedish);
            Swedish.AddLanguage("Boombox_ToolTips", "[LMB] Spela musik;[RMB] Byt musik");
            Swedish.AddLanguage("Boombox", "Bärbart ljudsystem");
            Swedish.AddLanguage("BoomboxVolume", "{0}% volym");
        }

        public static AssetBundle QuickLoadAssetBundle(string name)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), name);
            return AssetBundle.LoadFromFile(path);
        }
    }
}
