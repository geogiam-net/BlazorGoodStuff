using BlazorWeb.Pages;
using Bunit;

namespace BlazorWebUnitTests;
public class CounterShould : TestContext
{
  [Fact]
  public void RenderCorrectlyWithInitialZero()
  {
    IRenderedComponent<ContadorBase> cut = RenderComponent<Contador>();
    cut.MarkupMatches(@"
        <h1>Contador</h1>
        <p role=""status"">Current count: 0</p>
        <button class=""btn btn-primary"" >
          Click me
        </button>
        ");
  }
    
  [Fact]
  public void RenderParagraphCorrectlyWithInitialZero()
  {
    IRenderedComponent<Contador> cut = RenderComponent<Contador>();
    cut.Find(cssSelector: "p")
       .MarkupMatches("""<p role="status">Current count: 0</p>""");
  }

  [Fact]
  public void IncrementCounterWhenButtonIsClicked()
  {
    IRenderedComponent<Contador> cut = RenderComponent<Contador>();
    cut.Find(cssSelector: "button")
       .Click();
    cut.Find(cssSelector: "p")
       .MarkupMatches(@"<p role=""status"">Current count: 1</p>");
  }
    
}
