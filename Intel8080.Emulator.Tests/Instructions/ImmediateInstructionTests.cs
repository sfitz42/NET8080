using Intel8080.Emulator.Instructions;
using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class ImmediateInstructionTests
    {
        private readonly CPU _cpu;
        private readonly IMemory _memory;

        public ImmediateInstructionTests()
        {
            _memory = new DefaultMemory(0x100);
            _cpu = new CPU(_memory);

            _cpu.Registers.PC = 1;
        }

        [Fact]
        public void LXI_B_ShouldStoreImmediateDataInBC()
        {
            // Arrange
            _memory[0x0001] = 0x03;
            _memory[0x0002] = 0x01;

            // Act
            DefaultInstructionSet.LXI_B(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0103, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void LXI_D_ShouldStoreImmediateDataInDE()
        {
            // Arrange
            _memory[0x0001] = 0x03;
            _memory[0x0002] = 0x01;

            // Act
            DefaultInstructionSet.LXI_D(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0103, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void LXI_H_ShouldStoreImmediateDataInHL()
        {
            // Arrange
            _memory[0x0001] = 0x03;
            _memory[0x0002] = 0x01;

            // Act
            DefaultInstructionSet.LXI_H(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0103, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void LXI_SP_ShouldStoreImmediateDataInSP()
        {
            // Arrange
            _memory[0x0001] = 0x03;
            _memory[0x0002] = 0x01;

            // Act
            DefaultInstructionSet.LXI_SP(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0103, _cpu.Registers.SP);
        }

        [Fact]
        public void MVI_B_ShouldStoreImmediateDataInB()
        {
            // Arrange
            _memory[0x0001] = 0xFF;

            // Act
            DefaultInstructionSet.MVI_B(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MVI_C_ShouldStoreImmediateDataInC()
        {
            // Arrange
            _memory[0x0001] = 0xFF;

            // Act
            DefaultInstructionSet.MVI_C(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MVI_D_ShouldStoreImmediateDataInD()
        {
            // Arrange
            _memory[0x0001] = 0xFF;

            // Act
            DefaultInstructionSet.MVI_D(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MVI_E_ShouldStoreImmediateDataInE()
        {
            // Arrange
            _memory[0x0001] = 0xFF;

            // Act
            DefaultInstructionSet.MVI_E(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MVI_H_ShouldStoreImmediateDataInH()
        {
            // Arrange
            _memory[0x0001] = 0xFF;

            // Act
            DefaultInstructionSet.MVI_H(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFF00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MVI_L_ShouldStoreImmediateDataInL()
        {
            // Arrange
            _memory[0x0001] = 0xFF;

            // Act
            DefaultInstructionSet.MVI_L(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x00FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MVI_M_ShouldStoreImmediateDataInMemoryLocation()
        {
            // Arrange
            _cpu.Registers.HL = 0x0050;
            _memory[0x0001] = 0xFF;

            // Act
            DefaultInstructionSet.MVI_M(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0050, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0xFF, _cpu.Memory[0x0050]);
        }

        [Fact]
        public void MVI_A_ShouldStoreImmediateDataInAccumulator()
        {
            // Arrange
            _memory[0x0001] = 0xFF;

            // Act
            DefaultInstructionSet.MVI_A(_cpu);

            // Assert
            Assert.Equal(0x00FF, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void ADI_ShouldAddImmediateDataToAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x6C;
            _memory[0x0001] = 0x2E;

            // Act
            DefaultInstructionSet.ADI(_cpu);

            // Assert
            Assert.Equal(0x9A, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ACI_ShouldAddImmediateDataToAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _memory[0x0001] = 0x3D;

            _cpu.Flags.Carry = true;

            // Act
            DefaultInstructionSet.ACI(_cpu);

            // Assert
            Assert.Equal(0x80, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SUI_ShouldSubtractImmediateDataFromAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x3E;
            _memory[0x01] = 0x3E;

            // Act
            DefaultInstructionSet.SUI(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.True(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBI_ShouldSubtractImmediateDataFromAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _memory[0x01] = 0x02;

            _cpu.Flags.Carry = false;

            // Act
            DefaultInstructionSet.SBI(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBI_ShouldSubtractImmediateDataFromAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _memory[0x01] = 0x02;

            _cpu.Flags.Carry = true;

            // Act
            DefaultInstructionSet.SBI(_cpu);

            // Assert
            Assert.Equal(0x01, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ANI_ShouldBitwiseANDAccumulatorImmediateData()
        {
            // Arrange
            _cpu.Registers.A = 0xFC;
            _memory[0x0001] = 0x0F;

            // Act
            DefaultInstructionSet.ANI(_cpu);

            // Assert
            Assert.Equal(0x0C, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void XRI_ShouldBitwiseXORAccumulatorImmediateData()
        {
            // Arrange
            _cpu.Registers.A = 0x5C;
            _memory[0x0001] = 0x78;

            // Act
            DefaultInstructionSet.XRI(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }
        
        [Fact]
        public void ORI_ShouldBitwiseOrAccumulatorImmediateData()
        {
            // Arrange
            _cpu.Registers.A = 0x33;
            _cpu.Memory[0x0001] = 0x0F;

            // Act
            DefaultInstructionSet.ORI(_cpu);

            // Assert
            Assert.Equal(0x3F, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void CPI_ShouldAccumulatorAndImmediateData()
        {
            // Arrange
            _cpu.Registers.A = 0x02;
            _cpu.Memory[0x0001] = 0x05;

            // Act
            DefaultInstructionSet.CPI(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.True(_cpu.Flags.Carry);
        }
    }
}