namespace Intel8080.Emulator.Instructions
{
    public static partial class DefaultInstructionSet
    {
        private static void LXI(CPU cpu, ref ushort reg)
        {
            var data = cpu.ReadNextUshort();

            reg = data;
        }

        private static void MVI(CPU cpu, ref byte reg)
        {
            reg = cpu.ReadNextByte();
        }

        // 0x01   - LXI, B,d16
        // Bytes  - 3
        // Cycles - 10
        // Flags  - None
        public static void LXI_B(CPU cpu)
        {
            LXI(cpu, ref cpu.Registers.BC);
        }

        // 0x11   - LXI D, d16
        // Bytes  - 3
        // Cycles - 10
        // Flags  - None
        public static void LXI_D(CPU cpu)
        {
            LXI(cpu, ref cpu.Registers.DE);
        }

        // 0x21   - LXI H, d16
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None
        public static void LXI_H(CPU cpu)
        {
            LXI(cpu, ref cpu.Registers.HL);
        }

        // 0x31   - LXI SP, d16
        // Bytes  - 3
        // Cycles - 10
        // Flags  - None
        public static void LXI_SP(CPU cpu)
        {
            LXI(cpu, ref cpu.Registers.SP);
        }

        // 0x06   - MVI B,d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public static void MVI_B(CPU cpu)
        {
            MVI(cpu, ref cpu.Registers.B);
        }

        // 0x0E   - MVI C, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public static void MVI_C(CPU cpu)
        {
            MVI(cpu, ref cpu.Registers.C);
        }

        // 0x16   - MVI D, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public static void MVI_D(CPU cpu)
        {
            MVI(cpu, ref cpu.Registers.D);
        }

        // 0x1E   - MVI E, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public static void MVI_E(CPU cpu)
        {
            MVI(cpu, ref cpu.Registers.E);
        }

        // 0x26   - MVI H, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public static void MVI_H(CPU cpu)
        {
            MVI(cpu, ref cpu.Registers.H);
        }

        // 0x2E   - MVI L, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public static void MVI_L(CPU cpu)
        {
            MVI(cpu, ref cpu.Registers.L);
        }

        // 0x36   - MVI M
        // Bytes  - 2
        // Cycles - 10
        // Flags  - None
        public static void MVI_M(CPU cpu)
        {
            var location = cpu.Registers.HL;

            cpu.Memory[location] = cpu.ReadNextByte();
        }

        // 0x3E   - MVI A, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public static void MVI_A(CPU cpu)
        {
            MVI(cpu, ref cpu.Registers.A);
        }

        public static void ADI(CPU cpu)
        {
            var data = cpu.ReadNextByte();

            ADD(cpu, ref data);
        }

        public static void ACI(CPU cpu)
        {
            var data = cpu.ReadNextByte();

            ADC(cpu, ref data);
        }

        public static void SUI(CPU cpu)
        {
            var data = cpu.ReadNextByte();

            SUB(cpu, ref data);
        }

        public static void SBI(CPU cpu)
        {
            var data = cpu.ReadNextByte();

            SBB(cpu, ref data);
        }

        public static void ANI(CPU cpu)
        {
            var data = cpu.ReadNextByte();

            ANA(cpu, ref data);
        }

        public static void XRI(CPU cpu)
        {
            var data = cpu.ReadNextByte();

            XRA(cpu, ref data);
        }

        public static void ORI(CPU cpu)
        {
            var data = cpu.ReadNextByte();

            ORA(cpu, ref data);
        }

        public static void CPI(CPU cpu)
        {
            var data = cpu.ReadNextByte();

            CMP(cpu, ref data);
        }
    }
}