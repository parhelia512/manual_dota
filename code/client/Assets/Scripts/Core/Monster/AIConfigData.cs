using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System;
//
//public class AIConfigData
//{
//    public static Schemas.AiConfig config;
//
//    public static void Init(XmlDocument doc)
//    {
//        config = XmlBase.Deserialize<Schemas.AiConfig>(doc);
//    }
//
//    public static Schemas.AiConfigAI FindById(int id)
//    {
//        return System.Array.Find<Schemas.AiConfigAI>(config.AI, delegate(Schemas.AiConfigAI AI)
//        {
//            return AI.AiId == id;
//        });
//    }
//
//    public static List<Schemas.AiConfigSkillGroupEditor> FindBySkillGroupId(string id)
//    {
//        List<Schemas.AiConfigSkillGroupEditor> Group = new List<Schemas.AiConfigSkillGroupEditor>();
//        for(int i = 0; i < config.SkillGroupEditor.Length; i++)
//        {
//            if(id == config.SkillGroupEditor[i].Id)
//                Group.Add(config.SkillGroupEditor[i]);
//        }
//
//        return Group;
//    }
//   
//}
