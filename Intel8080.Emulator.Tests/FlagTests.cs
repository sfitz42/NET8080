using Intel8080.Emulator;
using Xunit;

namespace Intel8080.Emulator.Tests
{
    public class FlagTests
    {
        private Flags _flags;

        public FlagTests()
        {
            _flags = new Flags();

            _flags.Clear();
        }

        [Fact]
        public void SignBitIsSet_SetSignFlagTrue()
        {
            // Act
            _flags.CalcSignFlag(0x8C);

            // Assert
            Assert.True(_flags.Sign);
            Assert.Equal(0x82, _flags.F);
        }

        [Fact]
        public void SignBitIsUnset_SetSignFlagFalse()
        {
            // Act
            _flags.CalcSignFlag(0x7F);

            // Assert
            Assert.False(_flags.Sign);
            Assert.Equal(0x02, _flags.F);
        }

        [Fact]
        public void Data_Zero_SetZeroFlagTrue()
        {
            // Act
            _flags.CalcZeroFlag(0x00);

            // Assert
            Assert.True(_flags.Zero);
            Assert.Equal(0x42, _flags.F);
        }

        [Fact]
        public void Data_NonZero_SetZeroFlagFalse()
        {
            // Act
            _flags.CalcZeroFlag(0x01);

            // Assert
            Assert.False(_flags.Zero);
            Assert.Equal(0x02, _flags.F);
        }

        [Fact]
        public void AuxiliaryCarry_ValueGreaterThan0x0F_SetAuxCarryFlagTrue()
        {
            // Act
            _flags.CalcAuxCarryFlag(0x0F, 1);

            // Assert
            Assert.True(_flags.AuxiliaryCarry);
            Assert.Equal(0x12, _flags.F);
        }

        [Fact]
        public void AuxiliaryCarry_ValueLessThan0x0F_SetAuxCarryFlagFalse()
        {
            // Act
            _flags.CalcAuxCarryFlag(0x00, 1);

            // Assert
            Assert.False(_flags.AuxiliaryCarry);
            Assert.Equal(0x02, _flags.F);
        }

        [Fact]
        public void Parity_Even_SetParityFlagTrue()
        {
            // Act
            _flags.CalcParityFlag(0x3F);

            // Assert
            Assert.True(_flags.Parity);
            Assert.Equal(0x06, _flags.F);
        }

        [Fact]
        public void Parity_Zero_SetParityFlagTrue()
        {
            // Act
            _flags.CalcParityFlag(0x3F);

            // Assert
            Assert.True(_flags.Parity);
            Assert.Equal(0x06, _flags.F);
        }

        [Fact]
        public void Parity_Odd_SetParityFlagFalse()
        {
            // Act
            _flags.CalcSignFlag(0x7F);

            // Assert
            Assert.False(_flags.Parity);
            Assert.Equal(0x02, _flags.F);
        }

        [Fact]
        public void Carry_ValueGreaterThan0xFF_SetCarryFlagTrue()
        {
            // Act
            _flags.CalcCarryFlag(0x0100);

            // Assert
            Assert.True(_flags.Carry);
            Assert.Equal(0x03, _flags.F);
        }

        [Fact]
        public void Carry_ValueEqual0xFF_SetCarryFlagFalse()
        {
            // Act
            _flags.CalcCarryFlag(0xFF);

            // Assert
            Assert.False(_flags.Carry);
            Assert.Equal(0x02, _flags.F);
        }

        [Fact]
        public void Carry_ValueGreaterThan0xFFFF_SetCarryFlagTrue()
        {
            // Act
            _flags.CalcCarryFlagRegisterPair(0x010000);

            // Assert
            Assert.True(_flags.Carry);
            Assert.Equal(0x03, _flags.F);
        }

        [Fact]
        public void Carry_ValueLessThan0xFFFF_SetCarryFlagFalse()
        {
            // Act
            _flags.CalcCarryFlagRegisterPair(0xFFFF);

            // Assert
            Assert.False(_flags.Carry);
            Assert.Equal(0x02, _flags.F);
        }

        [Fact]
        public void Flags_Clear_SetFlagRegisterDefault()
        {
            // Arrange
            _flags.CalcSignFlag(0xC0);
            _flags.CalcParityFlag(0x80);

            // Act
            _flags.Clear();

            // Assert
            Assert.Equal(0x02, _flags.F);
        }
    }
}