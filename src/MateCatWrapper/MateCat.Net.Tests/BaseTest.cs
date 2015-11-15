using SpecsFor;
using StructureMap;

namespace MateCat.Net.Tests
{
    public class BaseTest : SpecsFor<MateCatApi>
    {
        protected override void ConfigureContainer(IContainer container)
        {
            container.Configure(n =>
            {
                n.For<MateCatApi>().Use(() => new MateCatApi());
            });
        }
    }
}
