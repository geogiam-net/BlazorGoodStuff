using BlazorWeb.Redux.Stores;
using Fluxor;

namespace BlazorWeb.Redux.Features;

public class AppFeature : Feature<AppStore>
{
  public override string GetName()
  => nameof(AppStore);

  protected override AppStore GetInitialState()
  => new(
    IsSubmitting: false,
    NewCustomer: null
    );
}