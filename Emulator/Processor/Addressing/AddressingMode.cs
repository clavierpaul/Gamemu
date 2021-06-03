namespace Gamemu.Emulator.Processor.Addressing
{
    public enum AddressingMode
    {
        None,
        RegisterA,
        RegisterB,
        RegisterC,
        RegisterD,
        RegisterE,
        RegisterH,
        RegisterL,
        RegisterAF,
        RegisterBC,
        RegisterDE,
        RegisterHL,
        RegisterSP,
        AbsoluteBC,
        AbsoluteDE,
        AbsoluteHL,
        AbsoluteSP,
        AbsoluteHLInc,
        AbsoluteHLDec,
        AbsoluteImmediate,
        Immediate,
        ImmediateSigned,
        Immediate16,
        IOImmediate,
        IORegisterC
    }
}