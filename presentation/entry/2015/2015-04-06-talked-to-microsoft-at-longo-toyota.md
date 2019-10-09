---json
{
  "documentId": 0,
  "title": "Talked to Microsoft …at Longo Toyota!",
  "documentShortName": "2015-04-06-talked-to-microsoft-at-longo-toyota",
  "fileName": "index.html",
  "path": "./entry/2015-04-06-talked-to-microsoft-at-longo-toyota",
  "date": "2015-04-06T07:00:00.000Z",
  "modificationDate": "2015-04-06T07:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-04-06-talked-to-microsoft-at-longo-toyota",
  "tag": "{\r\n  \"extract\": \"It would be very romantic to say that I self-sabotaged by first serious contact with Microsoft by getting my car serviced on the same day as my phone screen (in part because my youngest son does not want me to leave California for Microsoft Land). But I ...\"\r\n}"
}
---

# Talked to Microsoft …at Longo Toyota!

It would be very romantic to say that I self-sabotaged by first serious contact with Microsoft by getting my car serviced on the same day as my phone screen (in part because my youngest son does not want me to leave California for Microsoft Land). But I really, *really* did not think that my car would be held (with me waiting) from 11am to 4pm! So when the interviewer called he *did* offer to reschedule but I went ahead and frustrated myself anyway. I interviewed with Microsoft while walking the lots, waiting rooms and offices of Longo Toyota! Very stupid.

After the standard, “tell me a *little* bit about yourself” stuff (which I answer with a *lot* about myself), the interview moved to a [collabedit.com](http://collabedit.com/) session where I was asked to remove all the duplicate characters from a string. This felt like the first *easy* question of a series of questions. But I failed to answer it. I do not blame the noise of air hammers, the PA system blaring, the people walking around me at Longo Toyota. There was *no* way I was going to come up with this answer on the phone:

(new string(input.ToCharArray().Distinct().ToArray()))

This was not the answer told to me by the interviewer. This is not the answer I looked up on the Internet. My experience as a developer tells me that this *is* the answer. However, on the phone impromptu, I was *not* going remember that string has a `ToCharArray()` method and I was *not* going to remember that LINQ to objects has a `Distinct()` extension method. In fact, immediately after the interview, I pulled out my computer and wrote this solution in LINQPad within an hour:

```c#
var input = "Microsoft Windows";
    input.Dump("input");

var placeholder = "*";

var duplicates = input
        .ToCharArray() //would never have remembered this on the call!
        .Select((c,i) => new { Char=c, Index=i })
        .GroupBy(i => i.Char) //should have remembered this!
        .Where(i => i.Count() > 1)
        .ToArray();

duplicates.Dump("duplicate data");

var output = input;

duplicates.ForEachInEnumerable(i =>
    {
        i.Skip(1).ForEachInEnumerable(j =>
        {
            output = (j.Index &lt; output.Length) ?
                output.Insert(j.Index, placeholder)
                :
                string.Concat(output, placeholder);
            output = output.Remove(j.Index + 1, 1);
        });
    });

output.Dump("output with placeholder");

output.Replace(placeholder, string.Empty).Dump("final output");
```

As one of my comments denote in the code above, I *should* have remembered `GroupBy()` because it was, as they say, right on “the tip of my tongue” (during the call)—but it was still involved in the *wrong* answer. According to the elite-programmer conceptual model of the interviewer, I definitely took too long to discover the wrong answer anyway.

So I returned to my *real* programming world after the Microsoft interview. After looking on StackOverflow.com, I was reminded of `IEnumerable.Distinct()` (I just forgot about this method on the phone call in spite of the fact that I’ve used it many, many times before), the use of interactive IntelliSense in LINQPad reminded me of `ToCharArray()` and then from experience I knew immediately to do this:

(new string(input.ToCharArray().Distinct().ToArray()))

I am not upset with myself about not remembering because I *understand* the question posed to me (I took about an hour instead of few seconds)—and *most importantly* I need to understand such a question for my *personal* practice.

It would be great to have all of my understanding just a few seconds away from some other person’s command. But I’m not that kind of work-on-command guy (according to the ideals of the [French Enlightenment](http://en.wikipedia.org/wiki/Age_of_Enlightenment), by the way, *no one* should be that guy). It would also be great to live in a world where intelligence is not tested in such mechanical and unimaginative ways. In fact, I do argue that my intelligence was not tested but my response speed to a relatively arbitrary problem. After 18 years of doing interviews, I get very, *very* frustrated and disrespectful of the whole random-access, speed-test process and desire the meeting to be over… there is nothing like the triumphant will of a twirling cog in an impersonal corporation ready to oblige me.
[<img alt="rapping to @shanselman aboiut my botched Microsoft interview" src="https://farm9.staticflickr.com/8823/17058379165_828802c701_o_d.png">](http://songhayblog.azurewebsites.net/Entry/Show/windows-10-minimum-hardware-requirements-for-pc-and-other-tweeted-links "rapping to @shanselman aboiut my botched Microsoft interview")

So here are some points I need to make to remember this first contact with Microsoft:

* Since I applied for more than one Microsoft position, I did not know what position I was interviewing for and the interviewer gave no details of the job description. I should have journaled the positions I applied for…
* I contacted Microsoft directly so I was not warned about the interview style through professional recruiters (who are often wrong anyway). I *do* feel that the interviewer should have warned me that interview will *require* a computer with a live connection to the Internet *before* the interview date.
* My Windows Phone was unable to share Internet and handle a phone call at the same time; my notebook could not connect to the Longo public Wi-Fi. I had to do the CollabEdit.com session through my phone! Very frustrating!

@[BryanWilhite](https://twitter.com/BryanWilhite)
