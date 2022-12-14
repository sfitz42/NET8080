namespace Intel8080.Emulator.Instructions
{
    public static partial class DefaultInstructionSet
    {
        // 0x07   - RLC
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public static void RLC(CPU cpu)
        {
            cpu.Flags.Carry = ((cpu.Registers.A & 0x80) >> 7) == 1;
            cpu.Registers.A = (byte) (((cpu.Registers.A & 0x80) >> 7) | (cpu.Registers.A << 1));
        }

        // 0x0F   - RRC
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public static void RRC(CPU cpu)
        {
            cpu.Flags.Carry = (cpu.Registers.A & 0x01) == 1;
            cpu.Registers.A = (byte) (((cpu.Registers.A & 0x01) << 7) | (cpu.Registers.A >> 1));
        }

        // 0x17   - RAL
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public static void RAL(CPU cpu)
        {
            bool carry = cpu.Flags.Carry;

            cpu.Flags.Carry = ((cpu.Registers.A & 0x80) >> 7) == 1;

            cpu.Registers.A <<= 1;

            if (carry) cpu.Registers.A |= 1;
        }

        // 0x1F   - RAR
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public static void RAR(CPU cpu)
        {
            bool carry = cpu.Flags.Carry;

            cpu.Flags.Carry = (cpu.Registers.A & 0x01) == 1;

            cpu.Registers.A >>= 1;

            if (carry) cpu.Registers.A |= 0x80;
        }
    }
}