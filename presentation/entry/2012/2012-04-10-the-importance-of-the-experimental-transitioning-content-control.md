---json
{
  "documentId": 0,
  "title": "The Importance of the “Experimental” Transitioning Content Control",
  "documentShortName": "2012-04-10-the-importance-of-the-experimental-transitioning-content-control",
  "fileName": "index.html",
  "path": "./entry/2012-04-10-the-importance-of-the-experimental-transitioning-content-control",
  "date": "2012-04-10T18:34:00Z",
  "modificationDate": "2012-04-10T18:34:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-04-10-the-importance-of-the-experimental-transitioning-content-control",
  "tag": "{\r\n  \"extract\": \"The TransitioningContentControl, developed by Ruurd Boeke, is one of the few Silverlight controls striving for what I am calling “data-driven animation.” You can load content from a database—let’s say an Observable Collection of data—, display one item f...\"\r\n}"
}
---

# The Importance of the “Experimental” Transitioning Content Control

The `TransitioningContentControl`, developed by [Ruurd Boeke](https://twitter.com/), is one of the few Silverlight controls striving for what I am calling “data-driven animation.” You can load content from a database—let’s say an Observable Collection of data—, display one item from this Collection in the `TransitioningContentControl` and then *transition* to the next item in the Collection—to be displayed in the `TransitioningContentControl`. This transition is, by default, a story-board animation. Awe… some!

[<img alt="TransitioningContentControl with UserControl Collection Sample" src="http://farm6.staticflickr.com/5034/7065171509_b2503321d3.jpg">](http://wordwalkingstick.com/silverlightbiggestbox/ "TransitioningContentControl with UserControl Collection Sample")

## Workflow…

* Compose a “[previz](http://en.wikipedia.org/wiki/Previsualization)” storyboard in a separate file (I open a XAML-only file in Expression Blend among my “packed XAML” samples in my [Silverlight BiggestBox](http://wordwalkingstick.com/silverlightbiggestbox/)).
* Edit a copy of the `TransitioningContentControl` style in the actual layout.
* Add a new, named `VisualState` to the `VisualStateGroup x:Name="PresentationStates"` in the Template setter of your copy of the `TransitioningContentControl` style.
* Set the `Setter Property="Transition"` value to the name of this `VisualState` in the `TransitioningContentControl` style.
* When the transition is triggered, ensure that it does not trigger again *during* the transition. This will cause an exception. Use the `TransitionCompleted` event in a strategy to avoid this exception.

Composing the “[previz](http://en.wikipedia.org/wiki/Previsualization)” storyboard is the first time in my Microsoft developer life that a business need demands the use of storyboard composition (within the Expression Blend 4 timeframe of course).

## Now some critiques…

* You should not *need* to use a style to customize the transition animation. This should not be the only way of customizing the transition.
* Silverlight, animation-based behaviors, like the `FluidMoveBehavior` should be pluggable/Blendable into the control.
* No MSDN documentation (still considered “experimental”?).

## Beyond the Transitioning Content Control?

Expression Blend Architect Kenny Young suggested years ago that Behaviors allow developers to avoid resorting to building storyboards by hand for relatively simple animations. Animating the event when an item is added/removed to/from a `ListBox` should be considered a ‘simple’ animation. A Behavior should handle this.

The Transitioning Content Control does not support behaviors out of the box. In fact, to customize the animations that come with this control requires knowledge of “[templating](http://msdn.microsoft.com/en-us/library/ms745683.aspx)” *and* building storyboards. This would explain to me why this control might still be considered “experimental.”

So I tried for several days to avoid using this control by trying several techniques based on Behaviors. These are some of my findings:

* The `FluidMoveBehavior` can be configured to animate `Self` or `Children`. I have been unable to get the expected results from `FluidMoveBehavior` in ‘self-mode’… There is an old sample marked “[Download AppliesTo: Self Example](http://www.kirupa.com/blend_silverlight/fluidmove_pg4.htm)” by Microsoft’s Kirupa Chinnathambi that shows `Self` working for Silverlight 3—however, when I upgrade the sample to Silverlight 4 it *stops* working! By the way, where the hell is Kenny Young?
* One workaround that *should* deal with this `FluidMoveBehavior` in ‘self-mode’ issue involves using an `ItemsControl` that is meant to only hold *one* item. Then `ItemsControl.ItemsPanel` can hold this behavior in its template. I tried this without success (but was probably confused with drowsy, late-night frustration).

## Related Links

* “[Animated Visual State Transitions with the Transitioning Content Control](http://jesseliberty.com/2009/04/29/animated-visual-state-transitions-with-the-transitioning-content-control/) [Jesse Liberty]”
* “[Using the FluidMove Behavior—Page 4](http://www.kirupa.com/blend_silverlight/fluidmove_pg4.htm)”
* “[ItemsControl.Items must not be a UIElement type when an ItemTemplate is set.](http://forums.silverlight.net/t/195397.aspx/1)” This error came to me from trying to bind the currently selected item of a `ListBox` to a `UserControl` (which inherits `UIElement`).
* “`InitialTag` Specify the tag that this element will appear to come from. Select Element for a stand-alone scenario. Select `DataContext` for a data-bound scenario. The `FluidMoveBehavior` action will attempt to locate an element that has been previously tagged with the same data using a `FluidMoveSetTagBehavior` action.” [[MSDN](http://msdn.microsoft.com/en-us/library/ff723946(v=expression.40).aspx)]

<https://github.com/BryanWilhite/>
