using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace chaParser
{
    class Parser
    {
        public Parser( string filename )
        {
            using ( FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read)) 
            {
                int length = (int)fs.Length;
                _buffer = new byte[length];
                fs.Read(_buffer, 0, length);
                _curBufferIndex = 0;
            }
        }

        public int ParseInt32()
        {
            int value = BitConverter.ToInt32( _buffer, _curBufferIndex );
            _curBufferIndex += 4;
            return value;
        }

        public short ParseInt16()
        {
            short value = BitConverter.ToInt16( _buffer, _curBufferIndex);
            _curBufferIndex += 2;
            return value;
        }

        public char ParseChar()
        {
            char value = (char)_buffer[_curBufferIndex++];
            return value;
        }

        public float ParseFloat()
        {
            float value = BitConverter.ToSingle(_buffer, _curBufferIndex);
            _curBufferIndex += 4;
            return value;
        }

        public string ParseString(int charNum)
        {
            char[] chars = new char[charNum];
            for (int i = 0; i < charNum; ++i)
            {
                chars[i] = (char)_buffer[_curBufferIndex++];
            }
            string str = new string(chars);
            return str;
        }

        public byte[] ParseMusic()
        {
            byte[] data = new byte[32];
            Array.Copy(_buffer, data, 32);
            _curBufferIndex += 32;
            return data;
        }

        private byte[] _buffer;
        private int _curBufferIndex;
    }
}
