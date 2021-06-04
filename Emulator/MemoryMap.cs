using System;

namespace Gamemu.Emulator
{
    public class RAM : Memory
    {
        private readonly byte[] _ram;

        public RAM(int size)
        {
            _ram = new byte[size];
        }

        protected override int Read(int address)
        {
            return _ram[address];
        }

        protected override void Write(int address, int value)
        {
            _ram[address] = (byte) value;
        }
    }

    public class MemoryMap : Memory
    {
        private readonly Cartridge _cartridge;
        private RAM _wram = new(8192);
        private RAM _hram = new(128);

        public MemoryMap(Cartridge cartridge)
        {
            _cartridge = cartridge;
        }

        // TODO: Work out how to return address with offset removed
        private Memory GetMemoryDevice(int address) => address switch
        {
            <      0 => throw new ArgumentOutOfRangeException($"Attempted to access invalid memory address 0x{address:X4}"),
            < 0x8000 => _cartridge,
            < 0xA000 => throw new ArgumentException($"Attempted to access VRAM address 0x${address:X4}"),
            < 0xC000 => _cartridge,
            _ => throw new ArgumentOutOfRangeException($"Attempted to access invalid memory location 0x{address:X4}")
        };

        protected override int Read(int address) => GetMemoryDevice(address)[address];

        protected override void Write(int address, int value)
        {
            // Blargg rom writes characters to serial
            if (address == 0xFF01)
                Console.Write((char) value);
            
            GetMemoryDevice(address)[address] = value;
        }
    }
}