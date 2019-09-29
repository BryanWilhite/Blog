---json
{
  "author": "Bryan Wilhite",
  "content": "The instance of NavigationResult in the “navigation callback” of IRegionManager.RequestNavigate() returned an “object reference not set to an instance of an object” (null reference) exception as Navigation failed “silently.” This exception disappeared af...",
  "inceptDate": "2014-10-09T00:00:00",
  "isPublished": true,
  "slug": "songhay-studio-mef-imperative-exports-broke-prism-region-based-navigation-system",
  "title": "Songhay Studio: MEF imperative Exports broke Prism, Region-based Navigation system"
}
---

The instance of `NavigationResult` in the “navigation callback” of `IRegionManager.RequestNavigate()` returned an “object reference not set to an instance of an object” (null reference) exception as Navigation failed “silently.” This exception disappeared after several hours of investigation when imperative Exports were removed:

    #region builders:

    var rflContext = new RegistrationBuilder();
    rflContext
        .ForType&lt;IndexView&gt;().Export&lt;IndexView&gt;(builder =&gt; builder.AsContractName("IndexView"));

    var rflContextForModelContextModule = new RegistrationBuilder();
    rflContextForModelContextModule
        .ForTypesDerivedFrom&lt;IRestModelContextService&gt;().Export&lt;IRestModelContextService&gt;();

    #endregion

Using attribute-based `Export` declarations stopped Navigation from failing silently.
