using System;
using System.IO;
using System.Text;

namespace Gamemu.Emulator
{
    public class Cartridge : IMemory
    {
        private String Title { get; set; }
        byte[] _data;
        
        public Cartridge(byte[] data)
        {
            _data = data;
            var titleBuilder = new StringBuilder();
            
            var titleLength = _data[0x014B] == 0x33 ? 11 : 16;
            // Read cartridge title
            for (var i = 0; i < titleLength; ++i)
            {
                // Get character at title offset
                char character = (char) _data[0x0134 + i];

                if (character == '\0')
                    break;
                
                titleBuilder.Append((char) character);
            }

            Title = titleBuilder.ToString();
        }

        public virtual int Read(int address)
        {
            return _data[address];
        }

        public virtual void Write(int address, int value)
        {
            throw new InvalidOperationException("Attempt to write to ROM-only cartridge");
        }
    }
}