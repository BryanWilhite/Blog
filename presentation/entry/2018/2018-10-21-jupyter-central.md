---json
{
  "documentId": 0,
  "title": "jupyter central",
  "documentShortName": "2018-10-21-jupyter-central",
  "fileName": "index.html",
  "path": "./entry/2018-10-21-jupyter-central",
  "date": "2018-10-21T18:17:34.401Z",
  "modificationDate": "2018-10-21T18:17:34.401Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2018-10-21-jupyter-central",
  "tag": "{\r\n  \"extract\": \"I am sure there are many reasons why Span<T> (and Memory<T>) was introduced to the .NET Framework. To me, these C# language features are a response to the dangerous (and tedious) supremacy of handling data in unmanaged memory in general and t...\"\r\n}"
}
---

# jupyter central

[<img alt="The Algorithm Design Manual" src="https://images-na.ssl-images-amazon.com/images/I/515GcxK1FFL.jpg" style="float:right;margin:16px;">](https://www.amazon.com/Algorithm-Design-Manual-Steven-Skiena/dp/1848000693?SubscriptionId=1SW6D7X6ZXXR92KVX0G2&tag=thekintespacec00&linkCode=xm2&camp=2025&creative=165953&creativeASIN=1848000693)

I am sure there are many reasons why `Span<T>` (and `Memory<T>`) was [introduced](https://channel9.msdn.com/Events/Connect/2017/T125) to the .NET Framework. To me, these C# language features are a response to the dangerous (and tedious) supremacy of handling data in unmanaged memory in general and the ease of handling gigantic chunks of in-memory data in Python in particular.

My interest in Python goes back to [my attraction to Blender 3D](https://www.blender.org/features/scripting/) but the active use of Python really got going for me with my discovery of [jupyter notebooks](http://jupyter.org/try). In the same flippant manner that I regard `Span<T>` (and `Memory<T>`) as response to what has been in enjoyed in Python (inter-operating with unmanaged libraries) for years, jupyter notebooks are an open-source response to commercial [Mathematica notebooks](http://www.wolfram.com/technologies/nb/).

## jupyter notebooks online

The complications around sharing Mathematica notebooks online are now laughable to me as I use [Azure notebooks](https://notebooks.azure.com/rasx) and [binder](https://mybinder.org/) which I can point at [my jupyter central repo](https://github.com/BryanWilhite/jupyter-central).

Mathematica *will* reign supreme in many, many applications from its *three decades* of development but Mathematica by design has *one*[term-rewriting](https://en.wikipedia.org/wiki/Rewriting) language for its kernel while jupyter notebooks can support [several kernels](https://github.com/jupyter/jupyter/wiki/Jupyter-kernels) in addition to the traditional/historical python. There is even a kernel for [the Wolfram language](https://github.com/mmatera/iwolfram)! Moreover, jupyter notebooks can be supported by Docker containers via [JupyterHub](https://jupyterhub.readthedocs.io/en/latest/), spinning up custom environments for, say, [anaconda](https://medium.com/@ybarraud/setting-up-jupyterhub-with-sudospawner-and-anaconda-844628c0dbee).

## Coursera algorithms jupyter notebooks

[<img alt="Algorithms (4th Edition)" src="https://images-na.ssl-images-amazon.com/images/I/41%2BpJNrGujL.jpg" style="float:left;margin:16px;">](https://www.amazon.com/Algorithms-4th-Robert-Sedgewick/dp/032157351X?SubscriptionId=1SW6D7X6ZXXR92KVX0G2&tag=thekintespacec00&linkCode=xm2&camp=2025&creative=165953&creativeASIN=032157351X)

I decided to take on the Princeton course, [Algorithms, Part I](https://www.coursera.org/learn/algorithms-part1/), based on my ignorant assumption that I could participate through the use of jupyter notebooks. I discovered quickly that the course *requires* the use of Java. I then responded with *more* ignorance, thinking that I can use [a jupyter Java kernel](https://github.com/SpencerPark/IJava).

As of this writing, Microsoft’s Azure notebooks offers only an F# kernel as an alternative to Python. This means that I might find a repo with a YAML file showing me how to setup a Java-kernel jupyter environment for [binder](https://mybinder.org/). But the binder experience is still in beta and quite temporal.

To not use jupyter notebooks for this study means I would have to work exclusively on Ubuntu virtual machines where I can tolerate Java installations. I cannot bring myself to dump upwards of 600MB of Java environment on a Windows machine just to “play” with it. Pathetically, I dropped out of the Princeton course.

The Princeton course is a wonderful product of the Robert Sedgewick ‘camp’ which is responsibly Java based, coming with all the formal time constraints of actively participating in a college course. I have found the *algorist* camp, the online world setup by Steven S. Skiena ([algorist.com](http://algorist.com/)), more freeform, language-agnostic and casual.

And it must be said that there is a Udemy course in Python by Holczer Balazs, his [Algorithms and Data Structures in Python](https://www.udemy.com/algorithms-and-data-structures-in-python/). There is also a Pluralsight course, [Working with Graph Algorithms in Python](https://www.pluralsight.com/courses/graph-algorithms-python?aid=7010a000001x3JXAAY&promo=&oid=&utm_source=non_branded&utm_medium=digital_paid_search_bing&utm_campaign=Bing_US_Dynamic&utm_content=&s_kwcid=AL!5668!10!77446913240513!dat-2329246664020045:loc-190&ef_id=WbqObwAABGZYzA5z:20181021084406:s), by Googler [Janani Ravi](https://www.linkedin.com/in/jananiravi). But these Python-friendly courses are not free of charge.

## learning data visualization and algorithms with jupyter notebooks

When I quit the Sedgewick course, I was very interested in visualizing [*percolation*](https://introcs.cs.princeton.edu/java/assignments/percolation.html) in a jupyter notebook. There are [a couple of repos on GitHub](https://github.com/topics/monte-carlo-simulation?l=jupyter+notebook) that look promising. Stumbling into examples of additional visualizations, I have this jumble so far:

* “[Making trees in the Jupyter notebook](http://chuckpr.github.io/blog/trees2.html)”
* “[Python Tree-plots](https://plot.ly/python/tree-plots/)”
* “[Creating and Visualizing Decision Trees with Python](https://medium.com/@rnbrown/creating-and-visualizing-decision-trees-with-python-f8e8fa394176)”
* “[The Programmable Tree Drawing Engine—A Python Environment for (phylogenetic) Tree Exploration](http://etetoolkit.org/docs/2.3/tutorial/tutorial_drawing.html)”
* “[Saving nltk drawn parse tree to image file](https://stackoverflow.com/questions/23429117/saving-nltk-drawn-parse-tree-to-image-file/24748479#24748479)”
* “[Windows 8 Drawing Binary Search Trees sample in C# for Visual Studio 2008](https://code.msdn.microsoft.com/windowsapps/Drawing-Binary-Search-Trees-4c49410f)” [to emphasize my apparent lack of focus]

## going forward

When I quit the Sedgewick course, I left [a jupyter notebook of my notes](https://notebooks.azure.com/rasx/libraries/coursera-algorithms-part-1) and sense of accomplishment. So far, I am regarding my study of [the backtracking algorithm in C# via LINQpad](https://github.com/BryanWilhite/LinqPad/blob/e472f15f572f35a4557f47c769e684eddccd8d4a/Queries/funkyKB/Interview%20-%20powered%20by%20HackerRank%20-%20consecutive%20sums.linq) as my only accomplishment in this area.

It *feels* like I am planning to continue my read of [*The Algorithm Design Manual*](https://www.amazon.com/Algorithm-Design-Manual-Steven-Skiena/dp/1848000693?SubscriptionId=1SW6D7X6ZXXR92KVX0G2&tag=thekintespacec00&linkCode=xm2&camp=2025&creative=165953&creativeASIN=1848000693) (which was interrupted by following a disinterested third-party into the Sedgewick camp). Staying focused on the Skiena camp as an introduction and [watching his lecture videos](https://www.youtube.com/watch?v=ZFjhkohHdAA&list=PLOtl7M3yp-DV69F32zdK7YJcNXpTunF2b) without time constraints might be the way to go. I can do the other stuff later which, sadly, might be *years* later.

The Skiena read is punctuated by exercises that *will* lead me back to jupyter notebooks. It should help to regard this Blog entry as my survey of the lay of the land, allowing me to withdraw and focus on *my* comfort zone of self-study. There is no pleasing of others.

<https://github.com/BryanWilhite/>
