using Gamemu.Emulator.Processor.Addressing;
using static Gamemu.Emulator.Processor.Addressing.AddressingMode;

namespace Gamemu.Emulator.Processor.Instructions
{
    [Instruction(Opcode = 0xA8, Source = RegisterB)]
    [Instruction(Opcode = 0xA9, Source = RegisterC)]
    [Instruction(Opcode = 0xAA, Source = RegisterD)]
    [Instruction(Opcode = 0xAB, Source = RegisterE)]
    [Instruction(Opcode = 0xAC, Source = RegisterH)]
    [Instruction(Opcode = 0xAD, Source = RegisterL)]
    [Instruction(Opcode = 0xAE, Cycles = 8, Source = AbsoluteHL)]
    [Instruction(Opcode = 0xAF, Source = RegisterA)]
    [Instruction(Opcode = 0xEE, Cycles = 8, Source = AddressingMode.Immediate)]
    public class XOR : ReadInstruction
    {
        private readonly Register _a;
        private readonly FlagsRegister _flags;
        
        public XOR([A] Register a, ISource source, FlagsRegister flags, int cycles) : base(source, cycles)
        {
            _a = a;
            _flags = flags;
        }

        public override void Execute()
        {
            var result = _a.Read() ^ Source.Read();
            
            _flags.ZeroFlag = result == 0;
            _flags.SubtractionFlag = false;
            _flags.HalfCarryFlag = false;
            _flags.CarryFlag = false;
            
            _a.Write(result);
        }
    }
}