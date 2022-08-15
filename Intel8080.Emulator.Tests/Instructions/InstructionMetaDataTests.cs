using System;
using System.Collections.Generic;
using Intel8080.Emulator;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class InstructionMetaDataTests
    {
        private Opcode[] _opcodes;

        public static IEnumerable<object[]> OpcodeData => new List<object[]>
        {
            new object[] { 0x00, "NOP", 1, 4, null },
            new object[] { 0x01, "LXI B, d16", 3, 10, null },
            new object[] { 0x02, "STAX B", 1, 7, null },
            new object[] { 0x03, "INX B", 1, 5, null },
            new object[] { 0x04, "INR B", 1, 5, null },
            new object[] { 0x05, "DCR B", 1, 5, null },
            new object[] { 0x06, "MVI B, d8", 2, 7, null },
            new object[] { 0x07, "RLC", 1, 4, null },
            new object[] { 0x08, "*NOP", 1, 4, null },
            new object[] { 0x09, "DAD B", 1, 10, null },
            new object[] { 0x0A, "LDAX B", 1, 7, null },
            new object[] { 0x0B, "DCX B", 1, 5, null },
            new object[] { 0x0C, "INR C", 1, 5, null },
            new object[] { 0x0D, "DCR C", 1, 5, null },
            new object[] { 0x0E, "MVI C, d8", 2, 7, null },
            new object[] { 0x0F, "RRC", 1, 4, null },
            new object[] { 0x10, "*NOP", 1, 4, null },
            new object[] { 0x11, "LXI D, d16", 3, 10, null },
            new object[] { 0x12, "STAX D", 1, 7, null },
            new object[] { 0x13, "INX D", 1, 5, null },
            new object[] { 0x14, "INR D", 1, 5, null },
            new object[] { 0x15, "DCR D", 1, 5, null },
            new object[] { 0x16, "MVI D, d8", 2, 7, null },
            new object[] { 0x17, "RAL", 1, 4, null },
            new object[] { 0x18, "*NOP", 1, 4, null },
            new object[] { 0x19, "DAD D", 1, 10, null },
            new object[] { 0x1A, "LDAX D", 1, 7, null },
            new object[] { 0x1B, "DCX D", 1, 5, null },
            new object[] { 0x1C, "INR E", 1, 5, null },
            new object[] { 0x1D, "DCR E", 1, 5, null },
            new object[] { 0x1E, "MVI E, d8", 2, 7, null },
            new object[] { 0x1F, "RAR", 1, 4, null },
            new object[] { 0x20, "*NOP", 1, 4, null },
            new object[] { 0x21, "LXI H, d16", 3, 10, null },
            new object[] { 0x22, "SHLD a16", 3, 16, null },
            new object[] { 0x23, "INX H", 1, 5, null },
            new object[] { 0x24, "INR H", 1, 5, null },
            new object[] { 0x25, "DCR H", 1, 5, null },
            new object[] { 0x26, "MVI H, d8", 2, 7, null },
            new object[] { 0x27, "DAA", 1, 4, null },
            new object[] { 0x28, "*NOP", 1, 4, null },
            new object[] { 0x29, "DAD H", 1, 10, null },
            new object[] { 0x2A, "LHLD a16", 3, 16, null },
            new object[] { 0x2B, "DCX H", 1, 5, null },
            new object[] { 0x2C, "INR L", 1, 5, null },
            new object[] { 0x2D, "DCR L", 1, 5, null },
            new object[] { 0x2E, "MVI L, d8", 2, 7, null },
            new object[] { 0x2F, "CMA", 1, 4, null },
            new object[] { 0x30, "*NOP", 1, 4, null },
            new object[] { 0x31, "LXI SP, d16", 3, 10, null },
            new object[] { 0x32, "STA a16", 3, 13, null },
            new object[] { 0x33, "INX SP", 1, 5, null },
            new object[] { 0x34, "INR M", 1, 10, null },
            new object[] { 0x35, "DCR M", 1, 10, null },
            new object[] { 0x36, "MVI M, d8", 2, 10, null },
            new object[] { 0x37, "STC", 1, 4, null },
            new object[] { 0x38, "*NOP", 1, 4, null },
            new object[] { 0x39, "DAD SP", 1, 10, null },
            new object[] { 0x3A, "LDA a16", 3, 13, null },
            new object[] { 0x3B, "DCX SP", 1, 5, null },
            new object[] { 0x3C, "INR A", 1, 5, null },
            new object[] { 0x3D, "DCR A", 1, 5, null },
            new object[] { 0x3E, "MVI A, d8", 2, 7, null },
            new object[] { 0x3F, "CMC", 1, 4, null },
            new object[] { 0x40, "MOV B, B", 1, 5, null },
            new object[] { 0x41, "MOV B, C", 1, 5, null },
            new object[] { 0x42, "MOV B, D", 1, 5, null },
            new object[] { 0x43, "MOV B, E", 1, 5, null },
            new object[] { 0x44, "MOV B, H", 1, 5, null },
            new object[] { 0x45, "MOV B, L", 1, 5, null },
            new object[] { 0x46, "MOV B, M", 1, 7, null },
            new object[] { 0x47, "MOV B, A", 1, 5, null },
            new object[] { 0x48, "MOV C, B", 1, 5, null },
            new object[] { 0x49, "MOV C, C", 1, 5, null },
            new object[] { 0x4A, "MOV C, D", 1, 5, null },
            new object[] { 0x4B, "MOV C, E", 1, 5, null },
            new object[] { 0x4C, "MOV C, H", 1, 5, null },
            new object[] { 0x4D, "MOV C, L", 1, 5, null },
            new object[] { 0x4E, "MOV C, M", 1, 7, null },
            new object[] { 0x4F, "MOV C, A", 1, 5, null },
            new object[] { 0x50, "MOV D,B", 1, 5, null },
            new object[] { 0x51, "MOV D,C", 1, 5, null },
            new object[] { 0x52, "MOV D,D", 1, 5, null },
            new object[] { 0x53, "MOV D,E", 1, 5, null },
            new object[] { 0x54, "MOV D,H", 1, 5, null },
            new object[] { 0x55, "MOV D,L", 1, 5, null },
            new object[] { 0x56, "MOV D,M", 1, 7, null },
            new object[] { 0x57, "MOV D,A", 1, 5, null },
            new object[] { 0x58, "MOV E,B", 1, 5, null },
            new object[] { 0x59, "MOV E,C", 1, 5, null },
            new object[] { 0x5A, "MOV E,D", 1, 5, null },
            new object[] { 0x5B, "MOV E,E", 1, 5, null },
            new object[] { 0x5C, "MOV E,H", 1, 5, null },
            new object[] { 0x5D, "MOV E,L", 1, 5, null },
            new object[] { 0x5E, "MOV E,M", 1, 7, null },
            new object[] { 0x5F, "MOV E,A", 1, 5, null },
            new object[] { 0x60, "MOV H,B", 1, 5, null },
            new object[] { 0x61, "MOV H,C", 1, 5, null },
            new object[] { 0x62, "MOV H,D", 1, 5, null },
            new object[] { 0x63, "MOV H,E", 1, 5, null },
            new object[] { 0x64, "MOV H,H", 1, 5, null },
            new object[] { 0x65, "MOV H,L", 1, 5, null },
            new object[] { 0x66, "MOV H,M", 1, 7, null },
            new object[] { 0x67, "MOV H,A", 1, 5, null },
            new object[] { 0x68, "MOV L,B", 1, 5, null },
            new object[] { 0x69, "MOV L,C", 1, 5, null },
            new object[] { 0x6A, "MOV L,D", 1, 5, null },
            new object[] { 0x6B, "MOV L,E", 1, 5, null },
            new object[] { 0x6C, "MOV L,H", 1, 5, null },
            new object[] { 0x6D, "MOV L,L", 1, 5, null },
            new object[] { 0x6E, "MOV L,M", 1, 7, null },
            new object[] { 0x6F, "MOV L,A", 1, 5, null },
            new object[] { 0x70, "MOV M,B", 1, 7, null },
            new object[] { 0x71, "MOV M,C", 1, 7, null },
            new object[] { 0x72, "MOV M,D", 1, 7, null },
            new object[] { 0x73, "MOV M,E", 1, 7, null },
            new object[] { 0x74, "MOV M,H", 1, 7, null },
            new object[] { 0x75, "MOV M,L", 1, 7, null },
            new object[] { 0x76, "HLT", 1, 7, null },
            new object[] { 0x77, "MOV M,A", 1, 7, null },
            new object[] { 0x78, "MOV A,B", 1, 5, null },
            new object[] { 0x79, "MOV A,C", 1, 5, null },
            new object[] { 0x7A, "MOV A,D", 1, 5, null },
            new object[] { 0x7B, "MOV A,E", 1, 5, null },
            new object[] { 0x7C, "MOV A,H", 1, 5, null },
            new object[] { 0x7D, "MOV A,L", 1, 5, null },
            new object[] { 0x7E, "MOV A,M", 1, 7, null },
            new object[] { 0x7F, "MOV A,A", 1, 5, null },
            new object[] { 0x80, "ADD B", 1, 4, null },
            new object[] { 0x81, "ADD C", 1, 4, null },
            new object[] { 0x82, "ADD D", 1, 4, null },
            new object[] { 0x83, "ADD E", 1, 4, null },
            new object[] { 0x84, "ADD H", 1, 4, null },
            new object[] { 0x85, "ADD L", 1, 4, null },
            new object[] { 0x86, "ADD M", 1, 7, null },
            new object[] { 0x87, "ADD A", 1, 4, null },
            new object[] { 0x88, "ADC B", 1, 4, null },
            new object[] { 0x89, "ADC C", 1, 4, null },
            new object[] { 0x8A, "ADC D", 1, 4, null },
            new object[] { 0x8B, "ADC E", 1, 4, null },
            new object[] { 0x8C, "ADC H", 1, 4, null },
            new object[] { 0x8D, "ADC L", 1, 4, null },
            new object[] { 0x8E, "ADC M", 1, 7, null },
            new object[] { 0x8F, "ADC A", 1, 4, null },
            new object[] { 0x90, "SUB B", 1, 4, null },
            new object[] { 0x91, "SUB C", 1, 4, null },
            new object[] { 0x92, "SUB D", 1, 4, null },
            new object[] { 0x93, "SUB E", 1, 4, null },
            new object[] { 0x94, "SUB H", 1, 4, null },
            new object[] { 0x95, "SUB L", 1, 4, null },
            new object[] { 0x96, "SUB M", 1, 7, null },
            new object[] { 0x97, "SUB A", 1, 4, null },
            new object[] { 0x98, "SBB B", 1, 4, null },
            new object[] { 0x99, "SBB C", 1, 4, null },
            new object[] { 0x9A, "SBB D", 1, 4, null },
            new object[] { 0x9B, "SBB E", 1, 4, null },
            new object[] { 0x9C, "SBB H", 1, 4, null },
            new object[] { 0x9D, "SBB L", 1, 4, null },
            new object[] { 0x9E, "SBB M", 1, 7, null },
            new object[] { 0x9F, "SBB A", 1, 4, null },
            new object[] { 0xA0, "ANA B", 1, 4, null },
            new object[] { 0xA1, "ANA C", 1, 4, null },
            new object[] { 0xA2, "ANA D", 1, 4, null },
            new object[] { 0xA3, "ANA E", 1, 4, null },
            new object[] { 0xA4, "ANA H", 1, 4, null },
            new object[] { 0xA5, "ANA L", 1, 4, null },
            new object[] { 0xA6, "ANA M", 1, 7, null },
            new object[] { 0xA7, "ANA A", 1, 4, null },
            new object[] { 0xA8, "XRA B", 1, 4, null },
            new object[] { 0xA9, "XRA C", 1, 4, null },
            new object[] { 0xAA, "XRA D", 1, 4, null },
            new object[] { 0xAB, "XRA E", 1, 4, null },
            new object[] { 0xAC, "XRA H", 1, 4, null },
            new object[] { 0xAD, "XRA L", 1, 4, null },
            new object[] { 0xAE, "XRA M", 1, 7, null },
            new object[] { 0xAF, "XRA A", 1, 4, null },
            new object[] { 0xB0, "ORA B", 1, 4, null },
            new object[] { 0xB1, "ORA C", 1, 4, null },
            new object[] { 0xB2, "ORA D", 1, 4, null },
            new object[] { 0xB3, "ORA E", 1, 4, null },
            new object[] { 0xB4, "ORA H", 1, 4, null },
            new object[] { 0xB5, "ORA L", 1, 4, null },
            new object[] { 0xB6, "ORA M", 1, 7, null },
            new object[] { 0xB7, "ORA A", 1, 4, null },
            new object[] { 0xB8, "CMP B", 1, 4, null },
            new object[] { 0xB9, "CMP C", 1, 4, null },
            new object[] { 0xBA, "CMP D", 1, 4, null },
            new object[] { 0xBB, "CMP E", 1, 4, null },
            new object[] { 0xBC, "CMP H", 1, 4, null },
            new object[] { 0xBD, "CMP L", 1, 4, null },
            new object[] { 0xBE, "CMP M", 1, 7, null },
            new object[] { 0xBF, "CMP A", 1, 4, null },
            new object[] { 0xC0, "RNZ", 1, 5, 11 },
            new object[] { 0xC1, "POP B", 1, 10, null },
            new object[] { 0xC2, "JNZ a16", 3, 10, null },
            new object[] { 0xC3, "JMP a16", 3, 10, null },
            new object[] { 0xC4, "CNZ a16", 3, 11, 17 },
            new object[] { 0xC5, "PUSH B", 1, 11, null },
            new object[] { 0xC6, "ADI d8", 2, 7, null },
            new object[] { 0xC7, "RST 0", 1, 11, null },
            new object[] { 0xC8, "RZ", 1, 5, 11 },
            new object[] { 0xC9, "RET", 1, 10, null },
            new object[] { 0xCA, "JZ a16", 3, 10, null },
            new object[] { 0xCB, "*JMP a16", 3, 10, null },
            new object[] { 0xCC, "CZ a16", 3, 11, 17 },
            new object[] { 0xCD, "CALL a16", 3, 17, null },
            new object[] { 0xCE, "ACI d8", 2, 7, null },
            new object[] { 0xCF, "RST 1", 1, 11, null },
            new object[] { 0xD0, "RNC", 1, 5, 11 },
            new object[] { 0xD1, "POP D", 1, 10, null },
            new object[] { 0xD2, "JNC a16", 3, 10, null },
            new object[] { 0xD3, "OUT d8", 2, 10, null },
            new object[] { 0xD4, "CNC a16", 3, 11, 17 },
            new object[] { 0xD5, "PUSH D", 1, 11, null },
            new object[] { 0xD6, "SUI d8", 2, 7, null },
            new object[] { 0xD7, "RST 2", 1, 11, null },
            new object[] { 0xD8, "RC", 1, 5, 11 },
            new object[] { 0xD9, "*RET", 1, 10, null },
            new object[] { 0xDA, "JC a16", 3, 10, null },
            new object[] { 0xDB, "IN d8", 2, 10, null },
            new object[] { 0xDC, "CC a16", 3, 11, 17 },
            new object[] { 0xDD, "*CALL a16", 3, 17, null },
            new object[] { 0xDE, "SBI d8", 2, 7, null },
            new object[] { 0xDF, "RST 3", 1, 11, null },
            new object[] { 0xE0, "RPO", 1, 5, 11 },
            new object[] { 0xE1, "POP H", 1, 10, null },
            new object[] { 0xE2, "JPO a16", 3, 10, null },
            new object[] { 0xE3, "XTHL", 1, 18, null },
            new object[] { 0xE4, "CPO a16", 3, 11, 17 },
            new object[] { 0xE5, "PUSH H", 1, 11, null },
            new object[] { 0xE6, "ANI d8", 2, 7, null },
            new object[] { 0xE7, "RST 4", 1, 11, null },
            new object[] { 0xE8, "RPE", 1, 5, 11 },
            new object[] { 0xE9, "PCHL", 1, 5, null },
            new object[] { 0xEA, "JPE a16", 3, 10, null },
            new object[] { 0xEB, "XCHG", 1, 5, null },
            new object[] { 0xEC, "CPE a16", 3, 11, 17 },
            new object[] { 0xED, "*CALL a16", 3, 17, null },
            new object[] { 0xEE, "XRI d8", 2, 7, null },
            new object[] { 0xEF, "RST 5", 1, 11, null },
            new object[] { 0xF0, "RP", 1, 5, 11 },
            new object[] { 0xF1, "POP PSW", 1, 10, null },
            new object[] { 0xF2, "JP a16", 3, 10, null },
            new object[] { 0xF3, "DI", 1, 4, null },
            new object[] { 0xF4, "CP a16", 3, 11, 17 },
            new object[] { 0xF5, "PUSH PSW", 1, 11, null },
            new object[] { 0xF6, "ORI d8", 2, 7, null },
            new object[] { 0xF7, "RST 6", 1, 11, null },
            new object[] { 0xF8, "RM", 1, 5, 11 },
            new object[] { 0xF9, "SPHL", 1, 5, null },
            new object[] { 0xFA, "JM a16", 3, 10, null },
            new object[] { 0xFB, "EI", 1, 4, null },
            new object[] { 0xFC, "CM a16", 3, 11, 17 },
            new object[] { 0xFD, "*CALL a16", 3, 17, null },
            new object[] { 0xFE, "CPI d8", 2, 7, null },
            new object[] { 0xFF, "RST 7", 1, 11, null }
        };

        public InstructionMetaDataTests()
        {
            _opcodes = OpcodeTable.Opcodes;
        }

        [Theory]
        [MemberData(nameof(OpcodeData))]
        public void OpcodeMetaDataShouldMatch(int index, string mnenomic, ushort length, int cycles, int? cyclesBranch)
        {
            // Act
            var op = _opcodes[index];

            // Assert
            Assert.Equal(mnenomic, op.Mnenomic);
            Assert.Equal(length, op.Length);
            Assert.Equal(cycles, op.Cycles);
            Assert.Equal(cyclesBranch, op.CyclesBranch);
        }
    }
}