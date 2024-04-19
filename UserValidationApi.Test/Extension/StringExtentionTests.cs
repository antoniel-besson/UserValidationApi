using System;
using Xunit;
using UserValidationApi.Extension;

namespace UserValidationApi.Test.Extension
{
    public class StringExtentionTests
    {
        public class StringExtensionTests
        {
            public enum TestEnum
            {
                Value1,
                Value2,
                Value3
            }

            [Fact]
            public void ToEnum_ValidValue_ReturnsEnum()
            {
                // Arrange
                string validValue = "Value1";

                // Act
                var result = validValue.ToEnum<TestEnum>();

                // Assert
                Assert.Equal(TestEnum.Value1, result);
            }

            [Fact]
            public void ToEnum_InvalidValue_ThrowsArgumentException()
            {
                // Arrange
                string invalidValue = "InvalidValue";

                // Act & Assert
                var exception = Assert.Throws<ArgumentException>(() => invalidValue.ToEnum<TestEnum>());
                Assert.Equal("Failed to parse InvalidValue to TestEnum", exception.Message);
            }

            [Fact]
            public void ToEnum_NullValue_ThrowsArgumentNullException()
            {
                // Arrange
                string nullValue = null;

                // Act & Assert
                var exception = Assert.Throws<ArgumentException>(() => nullValue.ToEnum<TestEnum>());
                Assert.Equal("Failed to parse  to TestEnum", exception.Message);
            }

            [Fact]
            public void ToEnum_EmptyValue_ThrowsArgumentException()
            {
                // Arrange
                string emptyValue = string.Empty;

                // Act & Assert
                var exception = Assert.Throws<ArgumentException>(() => emptyValue.ToEnum<TestEnum>());
                Assert.Equal("Failed to parse  to TestEnum", exception.Message);
            }

            [Fact]
            public void ToEnum_InvalidEnumType_ThrowsArgumentException()
            {
                // Arrange
                string validValue = "Value1";

                // Act & Assert
                var exception = Assert.Throws<ArgumentException>(() => validValue.ToEnum<int>());
                Assert.Equal("TEnum must be an enum type", exception.Message);
            }
        }
    }
}

