﻿using NSubstitute;
using NUnit.Framework;

namespace ManualDi.Main.Tests
{
    public class TestDiContainerInject
    {
        private IDiContainer container;

        [SetUp]
        public void SetUp()
        {
            container = new ContainerBuilder().Build();
        }

        [Test]
        public void TestInject()
        {
            var instance = new object();
            var injectMethod = Substitute.For<InjectionDelegate<object>>();
            container.BindFinishAndResolve<object>(b => b.FromInstance(instance).Inject(injectMethod).Inject(injectMethod));

            injectMethod.Received(2).Invoke(Arg.Is(instance), Arg.Is(container));
        }
    }
}
