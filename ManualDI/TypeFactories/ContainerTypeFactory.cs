﻿namespace ManualDI.TypeFactories
{
    public class ContainerTypeFactory<T, Y> : ITypeFactory<Y>
        where T : Y
    {
        public Y Create(IDiContainer container)
        {
            return container.Resolve<T>();
        }
    }
}
