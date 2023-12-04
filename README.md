# MemorySearchV2

This is an edited version of XeClutch's Xbox 360 Cheat Engine which can be found here https://github.com/XeClutch/Cheat-Engine-For-Xbox-360

*Uses DevExpress 19.2 and xedevkit.dll. You will need them to compile. 

Improvements:
* The initial search function is ran in a Parallel.ForEach loop to utilize multiple threads. I'm not sure about the performance on lower end machines though.
* Using boyer-moore-horspool algorithm to try to increase speed. Not sure if this is making much of a difference but it does seem faster.
* there are quite a few small improvements but most has to do with the search functions.

  
Known issues:
* Very slow for large data sets. Try to keep the search range limited and if you are dealing with 1000's of results the second search will take a while.
* Certain memory regions don't seem to read but I could be wrong
* Definitely better if you have an idea of the memory range you're looking for.

If anyone wants to impove it feel free. It would be useful if it actually dumped memory faster but I'm assuming that's some kind of limitation of using GetMemory. I feel like there should be a better way to dump large chunks or whole modules but I'm burning out on it. Of course there are other tools to use but I have yet to find one that does it all. Typically I use XCE Tools 2, X360 Trainer Tool, and Peek Poker all together so one more won't hurt xD

Release
https://www.thetechgame.com/Forums/p=40821042/fixed-version-of-xeclutchs-cheat-engine-for-xbox-360.html#40821042

<a href="https://gyazo.com/80ce96c9f6e956701bd9395555866a4b"><img src="https://i.gyazo.com/80ce96c9f6e956701bd9395555866a4b.png" alt="Image from Gyazo" width="580"/></a>
<a href="https://gyazo.com/a2cfd468fa1c394dbdda9dfbe7102c9e"><img src="https://i.gyazo.com/a2cfd468fa1c394dbdda9dfbe7102c9e.png" alt="Image from Gyazo" width="580"/></a>
