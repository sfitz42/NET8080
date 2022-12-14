using Intel8080.Emulator.Instructions;
using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class RotateInstructionTests
    {
        private readonly CPU _cpu;
        private readonly Mock<IMemory> _memory;

        public RotateInstructionTests()
        {
            _memory = new Mock<IMemory>();
            _cpu = new CPU(_memory.Object);
        }

        [Fact]
        public void RLC_ShouldRotateAcculmuatlorLeftAndSetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0xF2;

            // Act
            DefaultInstructionSet.RLC(_cpu);

            // Assert
            Assert.Equal(0xE5, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void RRC_ShouldRotateARightAndSetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0xF2;

            // Act
            DefaultInstructionSet.RRC(_cpu);

            // Assert
            Assert.Equal(0x79, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void RAL_ShouldRotateALeftThroughCarry()
        {
            // Arrange
            _cpu.Registers.A = 0xB5;

            // Act
            DefaultInstructionSet.RAL(_cpu);

            // Assert
            Assert.Equal(0x6A, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void RAL_ShouldRotateALeftThroughCarry_CarrySet()
        {
            // Arrange
            _cpu.Registers.A = 0xB5;
            _cpu.Flags.Carry = true;


            // Act
            DefaultInstructionSet.RAL(_cpu);

            // Assert
            Assert.Equal(0x6B, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void RAR_ShouldRotateARightThroughCarry_CarryUnset()
        {
            // Arrange
            _cpu.Registers.A = 0x6A;

            // Act
            DefaultInstructionSet.RAR(_cpu);

            // Assert
            Assert.Equal(0x35, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void RAR_ShouldRotateARightThroughCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x6A;
            _cpu.Flags.Carry = true;

            // Act
            DefaultInstructionSet.RAR(_cpu);

            // Assert
            Assert.Equal(0xB5, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Carry);
        }
    }
}