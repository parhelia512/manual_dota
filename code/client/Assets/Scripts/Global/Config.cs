using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System;

public delegate void onLoadXmlFinish(string xmlfile, XmlDocument doc);

public class Config {
#if PUBLISHED
	public static bool published = true;
#else
	public static bool published = false;
#endif
	public static string error_msg = "";
	public static string res_url;
#if UNITY_ANDROID
	public static string platform = "android";
#elif UNITY_IPHONE
	public static string platform = "ios";
#else
	public static string platform = "standalone";
#endif
	// Use this for initialization
	public static string version = "0.0.0.3";
	public static float version_value = 0.003f;
	//public static string update_url = "http://192.168.1.105:8080/tiandao";
	public static string update_url = "http://115.29.141.185/coc/tiandao";
	public Config () {
	}

	public static string UTF8ByteArrayToString(byte[] characters)   
	{        
		UTF8Encoding encoding = new UTF8Encoding();   
		string constructedString = encoding.GetString(characters);   
		return (constructedString);   
	}   
	
	public static byte[] StringToUTF8ByteArray(string pXmlString)   
	{   
		UTF8Encoding encoding = new UTF8Encoding();   
		byte[] byteArray = encoding.GetBytes(pXmlString);   
		return byteArray;   
	} 

	public static string ConvertXmlToString(XmlDocument xmlDoc)  
	{  
		MemoryStream stream = new MemoryStream();  
		XmlTextWriter writer = new XmlTextWriter(stream, null);  
		writer.Formatting = Formatting.Indented;  
		xmlDoc.Save(writer);   
		StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);  
		stream.Position = 0;  
		string xmlString = sr.ReadToEnd();  
		sr.Close();  
		stream.Close();   
		return xmlString;  
	}  

	public static string objectToString (object obj) {
		System.Type type = obj.GetType();
		if (type == typeof(int))
			return obj.ToString();
		else if (type == typeof(float))
			return obj.ToString();
		else if (type == typeof(bool))
			return obj.ToString();
		else if (type == typeof(string))
			return (string) obj;
		else if (type == typeof(Vector3))
		{
			Vector3 val = (Vector3) obj;
			return val.x + "," + val.y + "," + val.z;
		}
		else if (type == typeof(Vector2))
		{
			Vector2 val = (Vector2) obj;
			return val.x + "," + val.y;
		}
		else if (type == typeof(AnimationCurve))
		{
			AnimationCurve val = (AnimationCurve) obj;
			string str = "";
			foreach (Keyframe frame in val.keys)
			{
				string v = frame.time.ToString() + "|" + frame.value.ToString() + "|" + frame.tangentMode.ToString() + "|" + frame.inTangent.ToString() + "|" + frame.outTangent.ToString();
				if (string.IsNullOrEmpty(str))
					str = v;
				else
					str += "," + v;
			}
			return str;
		}
		/*
		else if (type == typeof(MonoScript))
		{
			return type.Name;
		}*/
		
		return type.Name;
	}
	
	public static object stringToObject(System.Type type, string val) {
		if (type == typeof(int))
			return int.Parse(val);
		else if (type == typeof(float))
			return float.Parse(val);
		else if (type == typeof(bool))
			return bool.Parse(val);
		else if (type == typeof(string))
			return val;
		else if (type == typeof(Vector3))
		{
			string[] values = val.Split(',');
			return new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]));
		}
		else if (type == typeof(Vector2))
		{
			string[] values = val.Split(',');
			return new Vector2(float.Parse(values[0]), float.Parse(values[1]));
		}
		else if (type == typeof(AnimationCurve))
		{
			AnimationCurve cur = new AnimationCurve();
			if (!string.IsNullOrEmpty(val))
			{			
				string[] frame_strs = val.Split(',');
				foreach (string frame_str in frame_strs) 
				{
					string[] strs = frame_str.Split('|');
					Keyframe frame = new Keyframe(float.Parse(strs[0]), float.Parse(strs[1]), float.Parse(strs[3]), float.Parse(strs[4]));
					frame.tangentMode = int.Parse(strs[2]);
					cur.AddKey(frame);
				}
			}
			return cur;
		}
		/*
		else if (type == typeof(MonoScript))
		{
			return type;
		}
		*/
		return null;
	}

	public static System.Type findType(string str) {
		System.Type type = System.Type.GetType(str);
		if (type != null)
			return type;
		
		switch (str)
		{
		case "UnityEngine.AnimationCurve":
			return typeof(AnimationCurve);
		case "UnityEngine.Vector3":
			return typeof(Vector3);
		case "UnityEngine.Vector2":
			return typeof(Vector2);
		case "UnityEngine.Vector4":
			return typeof(Vector4);
		case "UnityEngine.Quaternion":
			return typeof(Quaternion);
		}
		
		return null;
	}

	public static Dictionary<string, object> fromStromgToParams (string str) {
		Dictionary<string, object> script_params = new Dictionary<string, object>();
		string[] all_words = str.Split(new string[] { "##" }, StringSplitOptions.None);
		foreach (string words in all_words)
		{
			string[] all_vars = words.Split(new string[] { "||" }, StringSplitOptions.None);
			if (all_vars.Length >= 3)
			{
				string key = all_vars[0];
				System.Type type = Config.findType(all_vars[1]);
				object val = Config.stringToObject(type, all_vars[2]);
				script_params.Add(key, val);
			}
		}

		return script_params;
	}
	
	public static XmlDocument fromStringToXmlDoc (byte[] bs) {
		XmlDocument doc = new XmlDocument();
		string text = UTF8ByteArrayToString(bs);
		doc.LoadXml(text);
		return doc;
	}
	
	public static XmlDocument getLocalXmlDoc (string xmlfile) {
#if REMOTE
		string url = Application.persistentDataPath + xmlfile;
		byte[] bs = File.ReadAllBytes(url);
		XmlDocument doc = fromStringToXmlDoc(bs);		
#else
		XmlDocument doc = new XmlDocument();
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
			doc.Load(Application.dataPath +  "/StreamingAssets" + xmlfile);
		else
		{
#if UNITY_ANDROID
	        WWW www = new WWW("jar:file://" + Application.dataPath + "!/assets" + xmlfile);
	        while (!www.isDone) {}
			try
			{
				/*
				System.IO.StringReader stringReader = new System.IO.StringReader(www.text);
				stringReader.Read(); // skip BOM
				System.Xml.XmlReader reader = System.Xml.XmlReader.Create(stringReader);
				*/
				doc.LoadXml(www.text);
				//doc.LoadXml(stringReader.ReadToEnd());
			}
			catch (Exception ex)
			{
				//error_msg += "LOAD " + xmlfile + " ERROR!" + "\n";
			}
#elif UNITY_IPHONE
			doc.Load(Application.dataPath + "/Raw" + xmlfile);
#endif
		}
#endif	
		return doc;
	}
	
	public static XmlDocument getStreamAssetsXmlDoc (string xmlfile) {
		XmlDocument doc = new XmlDocument();
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
			doc.Load(Application.dataPath +  "/StreamingAssets" + xmlfile);
		else
		{
#if UNITY_ANDROID
	        WWW www = new WWW("jar:file://" + Application.dataPath + "!/assets" + xmlfile);
	        while (!www.isDone) {}
			try
			{
				/*
				System.IO.StringReader stringReader = new System.IO.StringReader(www.text);
				stringReader.Read(); // skip BOM
				System.Xml.XmlReader reader = System.Xml.XmlReader.Create(stringReader);
				*/
				doc.LoadXml(www.text);
				//doc.LoadXml(stringReader.ReadToEnd());
			}
			catch (Exception ex)
			{
				//error_msg += "LOAD " + xmlfile + " ERROR!" + "\n";
			}
#elif UNITY_IPHONE
			doc.Load(Application.dataPath + "/Raw" + xmlfile);
#endif
		}
		return doc;
	}
}
