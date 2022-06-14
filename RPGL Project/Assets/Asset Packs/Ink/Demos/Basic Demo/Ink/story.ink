I've been waiting forever, I'm glad you're FINALLY here. #F.DroneSpeed.1.2 #F.DroneName.Chance
* What? Where am I?
    - I need you to open that door for me. #E.ShowStartingDoor
    * I'll try, but I'm not sure what to do. -> instructions
    * I don't think I want to do that right now #E.ReturnCameraToPlayer
     Good Luck getting out of here then.. -> END
    
== instructions ==
Go to the panel, it's in the back room. #E.ShowBackRoom
    *Why can't you do that?
        It is against my protocal...
        * * Okay, I'm on it! #E.ReturnCameraToPlayer #E.InspectPanelQuest
            Thanks!  ->END
- -> END