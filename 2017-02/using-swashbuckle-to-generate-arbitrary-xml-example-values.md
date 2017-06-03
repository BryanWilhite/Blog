# Using Swashbuckle to Generate Arbitrary XML Example Values

These notes follow a previous entry, “[Using Swashbuckle to Support Swaggerfied XML Production and Consumption](http://songhayblog.azurewebsites.net/entry/using-swashbuckle-to-support-swaggerfied-xml-production-and-consumption),” continuing to challenge of producing Swagger UI output like this:

<div style="text-align:center">

[![Swashbuckle Swagger UI with produces Example Value in Arbitrary XML](https://farm4.staticflickr.com/3829/32768627106_141f2fe4a0_o_d.png "Swashbuckle Swagger UI with produces Example Value in Arbitrary XML")](https://www.flickr.com/photos/wilhite/32768627106/in/dateposted-public/)

</div>

and this:

<div style="text-align:center">

[![Swashbuckle Swagger UI with consumes Example Value in Arbitrary XML](https://farm3.staticflickr.com/2539/32768627276_e1a5e59894_o_d.png "Swashbuckle Swagger UI with consumes Example Value in Arbitrary XML")](https://www.flickr.com/photos/wilhite/32768627276/in/dateposted-public/)

</div>

The way this is done is by building a new [`Swashbuckle.Swagger.Schema`](https://github.com/domaindrivendev/Swashbuckle/blob/2ed189b041e0e7849ec59a2fa2c0078e540a8359/Swashbuckle.Core/Swagger/SwaggerDocument.cs#L162) and using it on `Response.schema` for Swagger `produces` and `Parameter.schema` for Swagger `consumes`. These operations can be tacked on the end of [the blocks of code we saw earlier](https://gist.github.com/BryanWilhite/1a0e8c14a5002995aa5eb7984bfa5cd0) in `IOperationFilter.Apply()`.

I have centralized this code in extension methods. So, for `consumes`, I have this extension method:

``` c#
public static Parameter WithAbbreviatedSchema(this Parameter parameter)
{
    if (parameter == null) return null;
    if (parameter.schema == null) return null;

    parameter.schema.SetAbbreviatedSchema(isConsumingSchema: true);

    return parameter;
}
```

For `produces`, I have:

``` c#
public static Response WithAbbreviatedSchema(this Response response)
{
    if (response == null) return null;
    if (response.schema == null) response.schema = new Schema();

    response.schema.SetAbbreviatedSchema(isConsumingSchema: false);

    return response;
}
```

This simple pattern I am showing leads to, “What the hell is `SetAbbreviatedSchema()`?” Here is the answer:

``` c#
public static void SetAbbreviatedSchema(this Schema schema, bool isConsumingSchema)
{
    if (schema == null) return;

    var oneSpace = " ";
    var sendingPartyId = isConsumingSchema ? "CONSUMING_MODE" : "PRODUCING_MODE";
    var topLevelTitle = isConsumingSchema ? "in:PAYLOAD" : "out:PAYLOAD";

    schema.properties = new Dictionary<string, Schema> {
        {
            "HEADER",
            new Schema
            {
                properties = new Dictionary<string, Schema>
                {
                    { "PROPERTY_ONE", new Schema { type = "string", example = sendingPartyId } },
                    { "PROPERTY_TWO", new Schema { type = "string", example = oneSpace } },
                    { "PROPERTY_THREE", new Schema { type = "string", example = oneSpace } },
                },
                type = "object"
            }
        },
        {
            "BODY",
            new Schema
            {
                properties = new Dictionary<string, Schema>
                {
                    { "PROPERTY_ONE", new Schema { type = "string", example = oneSpace } },
                    { "PROPERTY_TWO", new Schema { type = "string", example = oneSpace } },
                },
                type = "object"
            }
        }
    };
    schema.title = topLevelTitle;
    schema.type = "object";
}
```

All of these extension methods are wonderful but Swashbuckle will ignore all of this work for `consumes` unless we make sure that `Parameter.schema.@ref` is set to `null`. This, for me, leads to a final extension method:

``` c#
public static Parameter WitNullSchemaReference(this Parameter parameter)
{
    if (parameter == null) return null;
    if (parameter.schema == null) return null;
    parameter.schema.@ref = null;
    return parameter;
}
```

We can now return to the implementation of `IOperationFilter`, `SwaggerContentTypeOperationFilter`, from [my previous post](http://songhayblog.azurewebsites.net/entry/using-swashbuckle-to-support-swaggerfied-xml-production-and-consumption) with its `ApplyConsumption()` method:

``` c#
static void ApplyConsumption(SwaggerContentTypeAttribute swaggerAttribute, Parameter swaggerParameter)
{
    switch (swaggerAttribute.Tag)
    {
        case "ConsumeXml":
            swaggerParameter.WitNullSchemaReference().WithAbbreviatedSchema();
            break;
    }
}
```

and its `ApplyProduction()` method:

``` c#
static void ApplyProduction(SwaggerContentTypeAttribute swaggerAttribute, Operation operation)
{
    Response okResponse = null;

    switch (swaggerAttribute.Tag)
    {
        case "ConsumeXml":
            okResponse = new Response()
                .WithOkDescription()
                .WithAbbreviatedSchema();
            break;
    }

    if (okResponse != null) operation.responses.Add(okResponse.To200Pair());
}
```

Now, for the question, “What is going on with that `topLevelTitle` variable in `SetAbbreviatedSchema()`?” This question refers to this (shown above):

``` c#
var topLevelTitle = isConsumingSchema ? "in:PAYLOAD" : "out:PAYLOAD";
```

This line is a hack to get around the current situation with Swagger/Swashbuckle where `Schema` definitions are considered duplicates when they have the same `Schema.title`.