---json
{
  "documentId": 0,
  "title": "Songhay Studio: MEF imperative Exports broke Prism, Region-based Navigation system",
  "documentShortName": "2014-10-09-songhay-studio-mef-imperative-exports-broke-prism-region-based-navigation-system",
  "fileName": "index.html",
  "path": "./entry/2014-10-09-songhay-studio-mef-imperative-exports-broke-prism-region-based-navigation-system",
  "date": "2014-10-09T07:00:00Z",
  "modificationDate": "2014-10-09T07:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2014-10-09-songhay-studio-mef-imperative-exports-broke-prism-region-based-navigation-system",
  "tag": "{\r\n  \"extract\": \"The instance of NavigationResult in the “navigation callback” of IRegionManager.RequestNavigate() returned an “object reference not set to an instance of an object” (null reference) exception as Navigation failed “silently.” This exception disappeared af...\"\r\n}"
}
---

# Songhay Studio: MEF imperative Exports broke Prism, Region-based Navigation system

The instance of `NavigationResult` in the “navigation callback” of `IRegionManager.RequestNavigate()` returned an “object reference not set to an instance of an object” (null reference) exception as Navigation failed “silently.” This exception disappeared after several hours of investigation when imperative Exports were removed:

```cs
#region builders:

var rflContext = new RegistrationBuilder();
    rflContext
        .ForType<IndexView>().Export<IndexView>(builder => builder.AsContractName("IndexView"));

var rflContextForModelContextModule = new RegistrationBuilder();
    rflContextForModelContextModule
        .ForTypesDerivedFrom<IRestModelContextService>().Export<IRestModelContextService>();

#endregion
```

Using attribute-based `Export` declarations stopped Navigation from failing silently.

<https://github.com/BryanWilhite/>
