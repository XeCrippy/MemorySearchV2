# MemorySearchV2

This is an edited version of XeClutch's Xbox 360 Cheat Engine which can be found here https://github.com/XeClutch/Cheat-Engine-For-Xbox-360

Improvements:
* The initial search function is ran in a Parallel.ForEach loop to utilize multiple threads. I'm not sure about the performance on lower end machines though.
* Using boyer-moore-horspool algorithm to try to increase speed. Not sure if this is making much of a difference but it does seem faster.
* there are quite a few small improvements but most has to do with the search functions.

  
Known issues:
* Very slow for large data sets. Try to keep the search range limited and if you are dealing with 1000's of results the second search will take a while.
* String searches are limited to 8 bytes for now but it does work

<a href="https://gyazo.com/80ce96c9f6e956701bd9395555866a4b"><img src="https://i.gyazo.com/80ce96c9f6e956701bd9395555866a4b.png" alt="Image from Gyazo" width="580"/></a>
<a href="https://gyazo.com/a2cfd468fa1c394dbdda9dfbe7102c9e"><img src="https://i.gyazo.com/a2cfd468fa1c394dbdda9dfbe7102c9e.png" alt="Image from Gyazo" width="580"/></a>
