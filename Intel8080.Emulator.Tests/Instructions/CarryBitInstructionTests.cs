using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class CarryBitInstructionTests
    {
        private readonly CPU _cpu;
        private readonly Mock<IMemory> _memory;
        private readonly IInstructionSet _instructionSet;

        public CarryBitInstructionTests()
        {
            _memory = new Mock<IMemory>();

            _instructionSet = new DefaultInstructionSet();
            _cpu = new CPU(_memory.Object, _instructionSet);
        }

        [Fact]
        public void NOP_ShouldAffectOnlyPCAndCycles()
        {
            // Act
            _instructionSet.NOP(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void STC_ShouldSetCarry()
        {
            // Arrange
            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.STC(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMC_ShouldSetCarryIfCarryIsFalse()
        {
            // Arrange
            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.CMC(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMC_ShouldUnsetCarryIfCarryIsTrue()
        {
            // Arrange
            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.CMC(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Carry);
        }
    }
}