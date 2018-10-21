## jupyter central

I am sure there are many reasons why `Span<T>` (and `Memory<T>`) was [introduced](https://channel9.msdn.com/Events/Connect/2017/T125) to the .NET Framework. To me, these C# language features are a response to the dangerous (and tedious) supremacy of handling data in unmanaged memory in general and the ease of handling gigantic chunks of in-memory data in Python in particular.

My interest in Python goes back to [my attraction to Blender 3D](https://www.blender.org/features/scripting/) but the active use of Python really got going for me with my discovery of [jupyter notebooks](http://jupyter.org/try). In the same flippant manner that I regard `Span<T>` (and `Memory<T>`) as response to what has been in enjoyed in Python (inter-operating with unmanaged libraries) for years, jupyter notebooks are an open-source response to commercial [Mathematica notebooks](http://www.wolfram.com/technologies/nb/).

### jupyter notebooks online

The complications around sharing Mathematica notebooks online are now laughable to me as I use [Azure notebooks](https://notebooks.azure.com/rasx) and [binder](https://mybinder.org/) which I can point at [my jupyter central repo](https://github.com/BryanWilhite/jupyter-central).

Now Mathematica will reign supreme in many, many applications from its _three decades_ of development but Mathematica by design has _one_ [term-rewriting](https://en.wikipedia.org/wiki/Rewriting) language for its kernel while jupyter notebooks can support [several kernels](https://github.com/jupyter/jupyter/wiki/Jupyter-kernels) in addition to the traditional/historical python. There is even a kernel for [the Wolfram language](https://github.com/mmatera/iwolfram)! Moreover, jupyter notebooks can be supported by Docker containers via [JupyterHub](https://jupyterhub.readthedocs.io/en/latest/).

### Coursera algorithms jupyter notebooks

I decided to take on the Princeton course, [Algorithms, Part I](https://www.coursera.org/learn/algorithms-part1/), based on my ignorant assumption that I could participate through the use of jupyter notebooks. I discovered quickly that the course _requires_ the use of Java. I then responded with _more_ ignorance, thinking that I can use [a jupyter Java kernel](https://github.com/SpencerPark/IJava).

As of this writing, Microsoft’s Azure notebooks offers only an F# kernel as an alternative to Python. This means that I might find a repo with a YAML file showing me how to setup a Java-kernel jupyter environment for [binder](https://mybinder.org/). But the binder experience is still in beta and quite temporal.

To not use jupyter notebooks for this study means I would have to work exclusively on Ubuntu virtual machines where I can tolerate Java installations. I cannot bring myself to dump upwards of 600MB of Java environment on a Windows machine just to “play” with it. Pathetically, I dropped out of the Princeton course.

@[BryanWilhite](https://twitter.com/BryanWilhite)