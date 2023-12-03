# MemorySearchV2

This is an edited version of XeClutch's Xbox 360 Cheat Engine which can be found here https://github.com/XeClutch/Cheat-Engine-For-Xbox-360

Improvements:
* The initial search function is ran in a Parallel.ForEach loop to utilize multiple threads. I'm not sure about the performance on lower end machines though.
* Using boyer-moore-horspool algorithm to try to increase speed. Not sure if this is making much of a difference but it does seem faster.
* there are quite a few small improvements but most has to do with the search functions.

  
Known issues:
* Very slow for large data sets. Try to keep the search range limited and if you are dealing with 1000's of results the second search will take a while.
* String searches are limited to 8 bytes for now but it does work


<blockquote class="imgur-embed-pub" lang="en" data-id="6epNGXx"><a href="https://imgur.com/6epNGXx">View post on imgur.com</a></blockquote><script async src="//s.imgur.com/min/embed.js" charset="utf-8"></script>
