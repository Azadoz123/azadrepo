using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Allegory.SampleMongoApp.Pages;

[Collection(SampleMongoAppTestConsts.CollectionDefinitionName)]
public class Index_Tests : SampleMongoAppWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
