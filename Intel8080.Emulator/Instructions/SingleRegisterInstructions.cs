namespace Intel8080.Emulator.Instructions
{
    public static partial class DefaultInstructionSet
    {
        private static void INR(CPU cpu, ref byte reg)
        {
            cpu.Flags.CalcAuxCarryFlag(reg, 1);

            reg += 1;

            cpu.Flags.CalcSignFlag(reg);
            cpu.Flags.CalcZeroFlag(reg);
            cpu.Flags.CalcParityFlag(reg);
        }

        private static void DCR(CPU cpu, ref byte reg)
        {
            cpu.Flags.CalcAuxCarryFlag(reg, -1);

            reg -= 1;

            cpu.Flags.CalcSignFlag(reg);
            cpu.Flags.CalcZeroFlag(reg);
            cpu.Flags.CalcParityFlag(reg);
        }

        // 0x04   - INR B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void INR_B(CPU cpu)
        {
            INR(cpu, ref cpu.Registers.B);
        }

        // 0x0C   - INR C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P

        public static void INR_C(CPU cpu)
        {
            INR(cpu, ref cpu.Registers.C);
        }

        // 0x14   - INR D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void INR_D(CPU cpu)
        {
            INR(cpu, ref cpu.Registers.D);
        }

        // 0x1C   - INR E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void INR_E(CPU cpu)
        {
            INR(cpu, ref cpu.Registers.E);
        }

        // 0x24   - INR H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void INR_H(CPU cpu)
        {
            INR(cpu, ref cpu.Registers.H);
        }

        // 0x2C  - INR L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void INR_L(CPU cpu)
        {
            INR(cpu, ref cpu.Registers.L);
        }

        // 0x34   - INR M
        // Bytes  - 1
        // Cycles - 10
        // Flags  - S, Z, A, P
        public static void INR_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Flags.CalcAuxCarryFlag(cpu.Memory[location], 1);

            cpu.Memory[location] += 1;

            cpu.Flags.CalcSignFlag(cpu.Memory[location]);
            cpu.Flags.CalcZeroFlag(cpu.Memory[location]);
            cpu.Flags.CalcParityFlag(cpu.Memory[location]);
        }

        // 0x3C   - INR A
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void INR_A(CPU cpu)
        {
            INR(cpu, ref cpu.Registers.A);
        }

        // 0x05   - DCR B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void DCR_B(CPU cpu)
        {
            DCR(cpu, ref cpu.Registers.B);
        }

        // 0x0D   - DCR C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void DCR_C(CPU cpu)
        {
            DCR(cpu, ref cpu.Registers.C);
        }

        // 0x15   - DCR D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void DCR_D(CPU cpu)
        {
            DCR(cpu, ref cpu.Registers.D);
        }

        // 0x1D   - DCR E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void DCR_E(CPU cpu)
        {
            DCR(cpu, ref cpu.Registers.E);
        }

        // 0x25   - DCR H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void DCR_H(CPU cpu)
        {
            DCR(cpu, ref cpu.Registers.H);
        }

        // 0x2D  - DCR L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void DCR_L(CPU cpu)
        {
            DCR(cpu, ref cpu.Registers.L);
        }

        // 0x35   - DCR M
        // Bytes  - 1
        // Cycles - 10
        // Flags  - S, Z, A, P
        public static void DCR_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Flags.CalcAuxCarryFlag(cpu.Memory[location], -1);

            cpu.Memory[location] -= 1;

            cpu.Flags.CalcSignFlag(cpu.Memory[location]);
            cpu.Flags.CalcZeroFlag(cpu.Memory[location]);
            cpu.Flags.CalcParityFlag(cpu.Memory[location]);
        }

        // 0x3D   - DCR A
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void DCR_A(CPU cpu)
        {
            DCR(cpu, ref cpu.Registers.A);
        }

        // 0x2F   - CMA
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None
        public static void CMA(CPU cpu)
        {
            cpu.Registers.A = (byte)~cpu.Registers.A;
        }

        // 0x27   - DAA
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S Z A P C
        public static void DAA(CPU cpu)
        {
            bool carry = false;
            byte correction = 0;

            byte low = (byte)(cpu.Registers.A & 0x0F);
            byte high = (byte)((cpu.Registers.A & 0xF0) >> 4);

            if (low > 0x09 | cpu.Flags.AuxiliaryCarry)
            {
                correction += 0x06;
            }

            if (high > 0x09 || (high >= 0x09 && low > 0x09) || cpu.Flags.Carry)
            {
                // Add 0x06 (0x60 == 0x06 << 4) to Accumulator high bits
                correction += 0x60;
                carry = true;
            }

            ADD(cpu, ref correction);

            cpu.Flags.Carry = carry;
        }
    }
}