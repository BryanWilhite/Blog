---json
{
  "author": "Bryan Wilhite",
  "content": "I’m not going to explain why because billions of people on this planet do not care. I’ll just write it like this: it bothers me when my bash shell history gets too “long”—tapping that up arrow key for tens of seconds grinds my gears. What is worse is the...",
  "inceptDate": "2015-07-28T16:57:14.516863-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "complete-control-and-domination-over-my-ubuntu-bash-shell-history",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Complete control and domination over my Ubuntu bash shell history"
}
---

I’m not going to explain why because billions of people on this planet do not care. I’ll just write it like this: it bothers me when my bash shell history gets too “long”—tapping that up arrow key for tens of seconds grinds my gears. What is worse is the ever-so-slight dip in morale when I enter `history -c` only to find that my history was not cleared—most of the time I seme-consciously realized this was happening to me I was mired in an emergency too desperate to investigate this issue.

These three commands solve the issue:


history -c &amp;&amp; history -w &amp;&amp; exit
    

What is better is to save the ‘messy’ history before clearing the buffer:


history -w ~/Desktop/history_bak.txt
    

What I am fond of doing is sorting `history_bak.txt` and removing duplicates—like this:


sort history_bak.txt | uniq &gt; history_bak_tmp.txt
    

Then I move `history_bak_tmp.txt` over `history_bak.txt`. I can then cherry-pick the best lines and paste them into the terminal as needed.

I have this “weird” expectation that my history file will settle down into about a dozen commands used routinely. Any spike in command usage means something abnormal has happened—prompting the need to clear the bash history again.

### Related Links

*   “[how to clear bash history and what to watch out for](http://www.giannistsakiris.com/2007/09/13/how-to-clear-bash-history-and-what-to-watch-out-for/)”
*   “[How to clear bash history completely?](http://askubuntu.com/questions/191999/how-to-clear-bash-history-completely/331655)”
*   “[How to View bash shell history and Change bash history file size in Ubuntu](http://www.ubuntugeek.com/how-to-view-bash-shell-history-and-change-bash-history-file-size-in-ubuntu.html)”
