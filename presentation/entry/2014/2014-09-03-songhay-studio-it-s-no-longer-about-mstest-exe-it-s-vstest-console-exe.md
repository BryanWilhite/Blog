---json
{
  "author": "Bryan Wilhite",
  "content": "Yes, I feel like I’m the only one in the world (outside of Redmond) using the default testing tools shipping with Visual Studio. So it should be no surprise to not even notice that MSTEST.EXE is no longer recommended—this is the new deal: \"%ProgramFiles(...",
  "inceptDate": "2014-09-03T00:00:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "songhay-studio-it-s-no-longer-about-mstest-exe-it-s-vstest-console-exe",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Songhay Studio: It’s No Longer about MSTEST.EXE; it’s vstest.console.exe…"
}
---

Yes, I feel like I’m the only one in the world (outside of Redmond) using the default testing tools shipping with Visual Studio. So it should be no surprise to not even notice that MSTEST.EXE is no longer recommended—this is the new deal:


"%ProgramFiles(x86)%\Microsoft Visual Studio 11.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
    

Also there is an “enable code coverage” option I have not tried out yet:
[<img alt="vstest.console.exe EnableCodeCoverage" src="https://farm6.staticflickr.com/5580/15056654695_9b65db23d8_o_d.png">](https://www.flickr.com/photos/wilhite/15056654695/ "vstest.console.exe EnableCodeCoverage")

### Related Links

<table class="WordWalkingStickTable"><tr><td>

“[MSTest.exe Command-Line Options](http://msdn.microsoft.com/en-us/library/ms182489.aspx)”
</td><td>

“For example, for ordered tests, the test container is the `.orderedtest` file that defines the ordered test. For unit tests, it is the assembly built from the test project that contains the unit test source files.”
</td></tr><tr><td>

“[Using VSTest.Console from the Command Line](http://msdn.microsoft.com/en-us/library/jj155800(v=vs.110).aspx)”
</td><td>

“You can use the `VSTest.Console.exe` program to run automated unit and coded UI tests from a command line. `VSTest.Console.exe` is optimized for performance and is used in place of `MSTest.exe` in Visual Studio 2012.”
</td></tr><tr><td>

“[New Unit Test functionality in VS2012 Update 2: Test Playlist](http://www.codewrecks.com/blog/index.php/2013/03/14/new-unit-test-functionality-in-vs2012-update-2-test-playlist/)”
</td><td>

Do not confuse a “playlist” with an “ordered test”—it feels like “playlist” tests must be ‘true’ unit tests (no dependencies on other tests).
</td></tr><tr><td>

“[How to manage unit tests in Visual Studio 2012 Update 1: Part 1–Using Traits in the Unit Test Explorer](http://blogs.msdn.com/b/visualstudioalm/archive/2012/11/09/how-to-manage-unit-tests-in-visual-studio-2012-update-1-part-1-using-traits-in-the-unit-test-explorer.aspx)”
</td><td>

“Traits are not only useful as a grouping mechanism in the Test Explorer, it also part of what can control which tests you run. This has been a big request—because it means the developer can focus on the tests relevant to the work, and not be bothered with running other, perhaps long-running tests, which would otherwise slow down the whole development experience.”
</td></tr><tr><td>

“[How To Unit Test Async Methods with MSTest, XUnit and VS11 Beta](http://www.richard-banks.org/2012/03/how-to-unit-test-async-methods-with.html)”
</td><td>

“`MSTest` finally got some love with the Visual Studio 11 Beta and one of those changes was to enable tests to run asynchronously using the `async` and `await` keywords.”
</td></tr><tr><td>

“[Gotchas: MSTest’s [DeploymentItem] attribute](http://www.ademiller.com/blogs/tech/2007/10/gotchas-mstests-deploymentitem-attribute/)”
</td><td>

“Essentially it seemed far too easy to create a test that worked fine on the local developer’s machine and failed either on the CI server or in someone else’s development environment. In fact 25% of our unit test related build breaks were caused by this issue and some of them took a while to track down!”
</td></tr></table>
