using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace chaParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser("C:\\AM\\cha");
            FileStream outputFile = new FileStream("C:\\AM\\output.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(outputFile);

            // Parse Character Info.
            int characterNameLength = parser.ParseInt32();
            string characterName = parser.ParseString(characterNameLength);

            // Parse Bone Info.
            int boneNum = parser.ParseInt32();
            sw.WriteLine("骨骼数量:" + boneNum.ToString());
            Bone[] bones = new Bone[boneNum];
            for (int bi = 0; bi < boneNum; ++bi)
            {
                bones[bi] = new Bone();
                int boneNameLength = parser.ParseInt32();
                bones[bi].BoneName = parser.ParseString(boneNameLength);
                sw.WriteLine("\t骨骼名称:" + bones[bi].BoneName.ToString());
                int bonePicNameLength = parser.ParseInt32();
                bones[bi].PicName = parser.ParseString(bonePicNameLength);
                sw.WriteLine("\t图片名称:" + bones[bi].PicName.ToString());
                bones[bi].BoneIndex = parser.ParseInt32();
                sw.WriteLine("\t骨骼索引:" + bones[bi].BoneIndex.ToString());
                sw.WriteLine("");
            }
            sw.WriteLine("-------------------------------------------------");

            // Parse Animation Info.
            int animationNumber = parser.ParseInt32();
            sw.WriteLine("动画数量:" + animationNumber.ToString());
            for (int ai = 0; ai < animationNumber; ++ai)
            {
                int animationNameLength = parser.ParseInt32();
                string animationName = parser.ParseString(animationNameLength);
                sw.WriteLine("\t动画名称:" + animationName);
                // 固定的4个字节, 不知道做什么用.
                int fixed4BytesNum = parser.ParseInt32();

                int animationDataNum = parser.ParseInt32();
                sw.WriteLine("\t动画数据数量:" + animationDataNum.ToString());
                for (int adi = 0; adi < animationDataNum; ++adi)
                {
                    int frameType = parser.ParseInt32();
                    sw.WriteLine("\t\t动画类型:" + frameType.ToString());
                    if (1 == frameType)
                    {
                        // 如果类型是1 要多解析声音数据.
                        int length = parser.ParseInt32(); // 这里长度不知道如何用.
                        int musicNameLength = parser.ParseInt32();
                        string musicName = parser.ParseString(musicNameLength);
                        byte[] musicData = parser.ParseMusic();
                        int type = parser.ParseInt32(); // 如果为1标示声音数据.
                    }
                    int curUsedBoneNum = parser.ParseInt32();
                    sw.WriteLine("\t\t当前使用骨骼数量:" + curUsedBoneNum.ToString());
                    for (int ci = 0; ci < curUsedBoneNum; ++ci)
                    {
                        short boneIndex = parser.ParseInt16();
                        sw.WriteLine("\t\t\t骨骼索引:" + boneIndex.ToString());
                        char alpha = parser.ParseChar();
                        sw.WriteLine("\t\t\t透明度:" + ((int)alpha).ToString());
                        float[] matrix = new float[6];
                        sw.Write("\t\t\t矩阵:");
                        for (int mi = 0; mi < 6; ++mi)
                        {
                            matrix[mi] = parser.ParseFloat();
                            sw.Write(matrix[mi] + ",");
                        }
                        sw.WriteLine("");
                    }
                }
            }

            sw.Flush();
            sw.Close();
        }
    }
}
