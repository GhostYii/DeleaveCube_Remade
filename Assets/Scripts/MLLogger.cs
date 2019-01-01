//ORG: ghostyii & MOONLIGHTGAME
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

namespace MoonLightGame
{
    public static class MLLogger
    {
        private static string savePath = Application.dataPath + "\\log.txt";
        public static string SavePath
        {
            get { return savePath; }
            set { savePath = value; }
        }

        /// <summary>
        /// log as "[TIME][INFO] info" in save path (log.txt)
        /// </summary>
        public static void Log(string info, bool unityDebug = true)
        {
            string str = string.Format("[{0}][INFO] {1}\n", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), info);
            File.AppendAllText(savePath, str, Encoding.UTF8);
#if UNITY_EDITOR
            if (unityDebug)
                Debug.Log(str);
#endif
        }
        /// <summary>
        /// log as "[LOGTYPE] info" in save path (log.txt)
        /// logType will be upper
        /// </summary>
        public static void Log(string logType, string info, bool unityDebug = true)
        {
            string str = string.Format("[{0}][{1}] {2}\n", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), logType.ToUpper(), info);
            File.AppendAllText(savePath, str, Encoding.UTF8);
#if UNITY_EDITOR
            if (unityDebug)
                Debug.Log(str);
#endif
        }

        public static void LogFormat(string info, bool unityDebug = true, params object[] objs)
        {
            string str = string.Format(info, objs);
            File.AppendAllText(savePath, str, Encoding.UTF8);
#if UNITY_EDITOR
            if (unityDebug)
                Debug.Log(str);
#endif
        }
    }
}

