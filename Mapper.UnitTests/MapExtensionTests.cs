﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mapper.UnitTests
{
    [TestFixture]
    public class MapExtensionTests
    {
        [Test]
        public void can_clone_string_property()
        {
            var input = new SingleProp<string>{ Value = "hello" };
            var copy = input.Clone();
            Assert.AreNotSame(input, copy);
            Assert.AreSame(input.Value, copy.Value);
        }

        [Test]
        public void can_clone_bool_property()
        {
            var input = new SingleProp<bool>{ Value = true };
            var copy = input.Clone();
            Assert.AreNotSame(input, copy);
            Assert.AreEqual(input.Value, copy.Value);
        }

        [Test]
        public void can_clone_byte_property()
        {
            var input = new SingleProp<byte>{ Value = 1 };
            var copy = input.Clone();
            Assert.AreNotSame(input, copy);
            Assert.AreEqual(input.Value, copy.Value);
        }

        [Test]
        public void can_clone_short_property()
        {
            var input = new SingleProp<short>{ Value = 1 };
            var copy = input.Clone();
            Assert.AreNotSame(input, copy);
            Assert.AreEqual(input.Value, copy.Value);
        }

        [Test]
        public void can_clone_int_property()
        {
            var input = new SingleProp<int>{ Value = 1 };
            var copy = input.Clone();
            Assert.AreNotSame(input, copy);
            Assert.AreEqual(input.Value, copy.Value);
        }

        [Test]
        public void can_clone_long_property()
        {
            var input = new SingleProp<long>{ Value = 1 };
            var copy = input.Clone();
            Assert.AreNotSame(input, copy);
            Assert.AreEqual(input.Value, copy.Value);
        }

        [Test]
        public void can_clone_datetime_property()
        {
            var input = new SingleProp<DateTime>{ Value = DateTime.Now };
            var copy = input.Clone();
            Assert.AreNotSame(input, copy);
            Assert.AreEqual(input.Value, copy.Value);
        }

        [Test]
        public void can_clone_float_property()
        {
            var input = new SingleProp<float>{ Value = 1.1f };
            var copy = input.Clone();
            Assert.AreNotSame(input, copy);
            Assert.AreEqual(input.Value, copy.Value);
        }

        [Test]
        public void can_clone_double_property()
        {
            var input = new SingleProp<double>{ Value = 1.1d };
            var copy = input.Clone();
            Assert.AreNotSame(input, copy);
            Assert.AreEqual(input.Value, copy.Value);
        }

        [Test]
        public void can_clone_decimal_property()
        {
            var input = new SingleProp<decimal>{ Value = 1.1m };
            var copy = input.Clone();
            Assert.AreNotSame(input, copy);
            Assert.AreEqual(input.Value, copy.Value);
        }

        [Test]
        public void can_clone_array_property()
        {
            var input = new SingleProp<decimal[]>{ Value = new [] {1m, 2m} };
            var copy = input.Clone();
            Assert.AreNotSame(input, copy);
            Assert.AreSame(input.Value, copy.Value);
        }


        [Test]
        public void can_clone_list_property()
        {
            var input = new SingleProp<List<string>>{ Value = new List<string> {"one", "two"} };
            var copy = input.Clone();
            Assert.AreNotSame(input, copy);
            Assert.AreSame(input.Value, copy.Value);
        }

        [Test]
        public void can_map_enum_to_int()
        {
            var input = new SingleProp<TestEnum> { Value = TestEnum.Something};
            var output = input.Map<SingleProp<TestEnum>, SingleProp<int>>();
            Assert.AreEqual((int)input.Value, output.Value);
        }

        [Test]
        public void can_map_enum_to_long()
        {
            var input = new SingleProp<TestEnum> { Value = TestEnum.Something };
            var output = input.Map<SingleProp<TestEnum>, SingleProp<long>>();
            Assert.AreEqual((long)input.Value, output.Value);
        }

        [Test]
        public void can_map_int_to_enum()
        {
            var input = new SingleProp<int> { Value = 1};
            var output = input.Map<SingleProp<int>, SingleProp<TestEnum>>();
            Assert.AreEqual((TestEnum)input.Value, output.Value);
        }

        [Test]
        public void can_map_long_to_enum()
        {
            var input = new SingleProp<long> { Value = 1 };
            var output = input.Map<SingleProp<long>, SingleProp<TestEnum>>();
            Assert.AreEqual((TestEnum)input.Value, output.Value);
        }

        [Test]
        public void can_map_nullable_int_to_int()
        {
            var input = new SingleProp<int?> { Value = 1 };
            var output = input.Map<SingleProp<int?>, SingleProp<int>>();
            Assert.AreEqual(1, output.Value);
        }

        [Test]
        public void can_map_long_to_nullable_long() {
            var input = new SingleProp<long> { Value = 1 };
            var output = input.Map<SingleProp<long>, SingleProp<long?>>();
            Assert.AreEqual(input.Value, output.Value);
        }

        [Test]
        public void can_map_nullable_long_to_long() {
            var input = new SingleProp<long?> { Value = 1 };
            var output = input.Map<SingleProp<long?>, SingleProp<long>>();
            Assert.AreEqual(input.Value.Value, output.Value);
        }

        [Test]
        public void can_map_null_nullable_long_to_default() {
            var input = new SingleProp<long?> { Value = (long?)null };
            var output = input.Map<SingleProp<long?>, SingleProp<long>>();
            Assert.AreEqual(0, output.Value);
        }

        [Test]
        public void can_map_nullable_int_to_long() {
            var input = new SingleProp<int?> { Value = 1 };
            var output = input.Map<SingleProp<int?>, SingleProp<long>>();
            Assert.AreEqual(1, output.Value);
        }

        [Test]
        public void can_map_null_nullable_int_to_long() {
            var input = new SingleProp<int?> { Value = (int?)null };
            var output = input.Map<SingleProp<int?>, SingleProp<long>>();
            Assert.AreEqual(0, output.Value);
        }
    }

    public class SingleProp<T>
    {
        public T Value { get; set; }
    }

    public enum TestEnum
    {
        Undefined = 0,
        Something = 1
    }
}