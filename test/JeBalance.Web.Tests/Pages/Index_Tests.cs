using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace JeBalance.Pages;

public class Index_Tests : JeBalanceWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
