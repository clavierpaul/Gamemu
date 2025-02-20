﻿using Gamemu.Emulator.Processor.Addressing.Modes;
using static Gamemu.Emulator.Processor.Addressing.AddressingMode;

namespace Gamemu.Emulator.Processor.Instructions.OpCodes;

[Instruction(Opcode = 0x88, Source = RegisterB)]
[Instruction(Opcode = 0x89, Source = RegisterC)]
[Instruction(Opcode = 0x8A, Source = RegisterD)]
[Instruction(Opcode = 0x8B, Source = RegisterE)]
[Instruction(Opcode = 0x8C, Source = RegisterH)]
[Instruction(Opcode = 0x8D, Source = RegisterL)]
[Instruction(Opcode = 0x8E, Cycles = 8, Source = AbsoluteHl)]
[Instruction(Opcode = 0x8F, Source = RegisterA)]
    
[Instruction(Opcode = 0xCE, Cycles = 8, Source = ImmediateValue8)]
public class Adc : ReadInstruction
{
    private readonly Register _a;
    private readonly FlagsRegister _flags;

    public Adc(ISource source, [A] Register a, FlagsRegister flags, int cycles) : base(source, cycles)
    {
        _a = a;
        _flags = flags;
    }

    public override void Execute()
    {
        var a = _a.Read();
        var b = Source.Read();
        var carry = _flags.CarryFlag ? 1 : 0;
            
        _a.Write(a + b + carry);
        InstructionUtilities.SetFlags(_flags, a, b + carry, false, false, true, true, true);
    }
}