VAR level = 1
//LIST doorState = hospital, train, stall. hospital2

-> theVoid

=== theVoid ===
{level != 1: Your vision fades to white, and you feel a sense of anticipation come over you. Life is just around the corner. Until...}
You stand in a black void, { level ==1: holding a shotgun, }with nothing before you but {level == 1:an ashen wood-paneled door}{level == 2: a traincar door}{level == 3: what appears to be a bathroom stall}{level == 4: the same door from the hospital, all those years ago}. {level == 1: A | The} doormat laid before it reads only one word: {level == 1:"PROVE"}{level == 2: "WORTHY"}{level == 3: "LEARN"}{level == 4: "LIVE"}.

 * {level == 1} [Open the door.] -> levelOne
 * {level == 2} [Open the door.] -> levelTwo
 * {level == 3} [Open the stall.] -> levelThree
 * {level == 4} [Open the door.] -> levelFour

=== levelOne ===
The room beyond the doorway appears to be a hospital nursery. It is empty, and so are all of the cradles within it, save for one which bleeds a sort of goopy darkness. You search for the patient informtion slip, but find that every line is redacted. The cradle's darkness leads to an office on the other side of the room.
*[Enter the office.] -> enter

===tutorial===
"oooo child, things are gonna get easier..."
* ['What?']->what
* ['Where am I?']->where
* ['Who are you?']->who
-(what)"don't worry your pretty head about that just yet. go on... pick up a block."
->END
-(where)"don't be rude. obvious you weren't around long enough to learn some manners."
->END
-(who)"nobody."
->END
=== enter ===
- You enter the office, and within the new room stands a creature made entirely of eyes. They wear ill-fitting scrubs, which serve as poor coverage for their sickly form.
*[Ask the creature where you are.] -> END


    ===talktonurse===
    "Please go back to your room, sweetheart."
    * [Ask where you are meant to go.]
    *[. . .]->Goodbye_Nurse
    -"Back, if you can. But you have to get through here first."
    *[Ask how you get out.]
    *[. . .]->Goodbye_Nurse
    -"Find yourself."
    *[. . .]->Goodbye_Nurse
    
    === Goodbye_Nurse ===
    With that, the Nurse begins to disappear, and leaves nothing but a pile of black sludge in their wake. ->END
    
        === attack_nurse ===
        You attack the nurse, killing them swiftly. Their body melts into a pile of black sludge, with a shiny silver flashlight sitting within it.
        *[Take the flashlight.]-> END
    
    
    === nursery_again ===
    Returning to the nursery, you are once again drawn towards the dark cradle. 
    //{hasFlashlight == true: Shining your brand-new flashlight on the patient information,| Approaching it, you notice a shiny silver object inside that you swore wasn't there before: a heavy-duty flashlight. You pick it up, and shining it on the patient information, } you can now see that an infant called Esther Vance was transferred to the Neonatal Intensve Care Unit before getting sent to the nursery. You set off in search of it. 
    *[Look for the NICU.]
    -> hallway
    
    === hallway ===
    The door you came in through from the Void now leads to along hallway littered with tiny monsters that look like fetuses. They are hostile, and you mow them down with little trouble. At the end of the network of halls, you finally find the section of the hospital you were in search of.
    *[Enter the NICU.]
    ->NICU
    
    === NICU ===
    The Neonatal Intensive Care Unit contains four beds that look more like cryogenic tanks than a place where one could sleep. Beside one of the beds sits a couple constructed of shadows. Neither has a face. -> decision
    = decision
    *[Talk to the woman.] -> END
    *[Talk to the man.] -> END
    * ->goForth
    
        ===mummy===
        This uncannily familiar woman sighs and takes your hand. "Darling, I'm so sorry. I didn't know. I couldn't have known..."
        *[Walk away.] 
        ->END
        *[Ask, 'What happened?']
        - She turns to the face sheet pasted to a stand on an incubator. "It's my fault. It's MY fault..."
        * [Disengage and look for the chart.]
        ->END
        *[Hug her.]
        - She smiles and holds your hand."My love, don't let people get too close-- especially when you're young. That way, nothing can hurt you." 
        ->END
        
        ===daddy===
        "What a man gets for marrying a whore." ->END
        
        === goForth ===
        Your parents both stare at you, as if expecting you to know what to say or do next. Where is your body? Are you dead?
        As if able to read your thoughts, they both turn towards a set of double doors on the far side of the room. Even from here, "DELIVERY" can be seen printed above it in red letters. Nobody speaks another word.
        * [Go to the delivery room.]
        -> delivery_room
        
    === delivery_room ===
    In the delivery room, you finally see your body, sickly yellow and covered in amniotic fluid. She is in the arms of a hulking shadow in a lab coat. It looms over her, its sharp claw not a centimeter away from her face.
    You must save yourself.
    * [Attack the doctor.]
    - You smash the monster to bits. In the black residue from his body, you find he has left a silencer which attaches perfectly to your weapon.
    * (silencer)[Pick up the silencer.]
    - Picking up the silencer, you reach eye level with a vent in the room with no grate. It glows softly in the otherwise dark space.
    * [Go through the vent.]
    ~ level = 2
    -> theVoid

    
    
=== levelTwo ===
Unsurprisingly, you step into a smelly car in an underground train. The only other person present is sitting on in the center of the traincar, looking up at the map. She beckons to you enthusiastically. For some unexplicable reason, you know her name to be Jessica.

* (j1)[Talk to Jessica.]->jess

=== jess ===
"I know you're not, like, in LOVE with the venue, but I promise I'll make dragging you down here worth it. 
*[...]
-And it's not just because I can't get roofied again." 
*[...]
-"Besides, they're your favorite band, right??? I won't mind if you spend more time dancing than with me."
*['...Alright.']->next
*[Leave.]
->END
===next===
"We're the next stop." You both stand, and feel the jolt of the rickety train screeching to a halt. 
-> END

    === night_club===
    Leaving the train, you step directly into a dark room with neon lights and dancing shadows. Looking back, the door is no longer the same as before.
    * [Explore the venue.]
    - This music hall is a labyrinth of poorly-lit stairwells and rooms, with shadows standing and swaying in the corners, undisturbed by you or the crawling creatures that begin attacking you. Your new silencer comes in handy, as well as your flashlight, which now shines ultraviolet. Cute.
    *[Finish them.]
    - While making your way through these enemies, you spot Jessica with a man in the corner. They are NOT leaving room for Jesus.
    * [Talk to Jessica.]->bad_friend
    *(stealth) [Leave her be.]
    - Now, some trickier enemies begin showing up, ones that you cannot see without shining your flashlight. After a time, you're able to evade and kill enough of them to mare safely walk around. Finally, you find the women's restroom, which shines with a comfortable fluorescence. 
    * [Enter the bathroom.]->bathroom
    
        === bad_friend ===
        As you approach and wave, Jessica looks up in disdain, and giggles quietly. 
        <i> "Do I know you?" </i> You surmise that she'd rather be occupied with this stranger than with you. You soldier on. 
        * [Continue.]
        ->night_club.stealth
        
        === bathroom ===
        As soon as you walk in, you immediately recognize the heels sticking out beneath the furthest stall door, and hear faint retching.
        * [Open the stall.]->jbathroom
        
        === jbathroom ===
        Jessica looks up, her face pallid and sickly. "Where in the HELL have you been?!" 
        * ["Killing monsters."]->monsters
        * ["You told me to go away the one time I saw you."]->truth
        - (monsters) "Right. What a compelling excuse. Do me a favor and piss off." She keels slightly, clearly very drunk. It's your funeral, not hers. She'll be fine. ->cont
        - (truth) She scowls drunkenly. "Fucking whatever. Just go, I'm sick of you and this place and the booze and my dress and..." ->cont
        - (cont) 
        *[Leave.]
        ->END
    
    === disco_boss ===
    Finally, you emerge in the main hall, where your favorite band <i>should</i> be playing. Instead it is entirely empty, save for a taped-off area in the pit, surrounding a broken body. It is covered in bootmarks and breathes raggedly. Suddenly, the disco ball hanging above the stage begins to lower.
    * [Climb onto the stage.]
    - Moving up closer, you see the individual mirrors of the ball begin to shift around, as if its tides are rising and falling. Then, it morphs into a many-limbed beast covered with mirrors. You are the only thing standing between it and the body. <i>Your</i> body.
    * [Attack.]
    - Once defeating the disco monster, it once again produces a boon in the pile of black goop it leaves behind, this time a hunting scope.
    * (scope)[Pick up the scope.]
    - You pick up the scope.
    Past the black viscera, you notice a trapdoor upstage. The cracks between it and the floor glow faintly.
    * [Go through the trapdoor.]
    ~ level = 3
    -> theVoid
    
 
    
=== levelThree ===
You walk into what just might be the most rancid bathroom you've ever seen. There is moss growing out of the grout of the wall tiling, the single overhead light flickers ominously, and the mirror is shattered. You can barely make out your figure in the surface.
* [Exit the bathroom.]
- Exiting the bathroom, you find yourself in a musty gas station convenience store. There are no other patrons, but there is an attendant at the cash register.
*[Approach.]
- (gas_man) As before, the attendant is featureless. He asks, <i>"Anything I can getcha?"</i>
*"No thank you". ->outside
*"May I buy some gas?" ->buy_gas

-(buy_gas) You purchase a full tank using a wad of singed bills you find after fishing through your pockets. When handing you the reciept, the attendant turns his non-face up to you apologetically.
<i>"I'm sorry I wasn't fast enough for the both of you."</i> Before you can ask what he means, he turns away and begins organizing a display of cigarettes and lottery tickets. ->go
- (outside) You turn away.
- (go)
* [Make your way outside.]
- Outside, right next to the door, there is a payphone, with its telephone piece lying on the ground. You can hear faint noises coming from it.
- (cont)
*[Pick up the phone.] ->phone
*[Continue on.]->gas_station
- (phone) The phone continually dials the same numbers— you recognize the sequence. It's calling 9-1-1.->cont

    === gas_station ===
    Investingaing the gas station, you realize that not a single pump has a car next to it. One, however, sports a dark blot on the ground.
    Walking towards it, you realize that the dark spot is a car-sized puddle of gasoline on the pavement. A pair of tire tracks lead from it out to the open road.
    * [Follow the tracks.]->hunting_time
    
    === hunting_time ===
    Once again, there are monsters here. This time, they stalk the fields surrounding the highway, and you shoot at them from afar. It's methodical and gruesome work. A few minutes later, you being to notice shards of aluminium and rubber littering the road. Their frequency increases as the monsters do.
    More creatures attack you, and you take them out when necessary.
    * [Forge onward.]
    - Eventually, you spot a pickup truck with a silhouetted figure beside it. You approach it cautiously.
    *[Reach the car.] -> partner
    
    === partner ===
    Approaching the car and therefore able to study it more closely, you realize that the figure is a burnt husk, whatever is left of someone who was killed here. 
    They reach their hand out to you.
    * [Let them.]->love
    * [Attack.]->hate
    - (love) They hold it softly.
    <i>"This is not your fault. I love you more than you know. Goodbye."</i> The figure -> spouse_dies
    - (hate) You attack the apparation, killing them almost instantly. Without warning, their body ->spouse_dies
    - (spouse_dies) turns to dust and blows away with the wind, leaving a simple bronze wedding band in their wake.
    They had been standing next to the passenger's side, so you only notice when they're gone that there is a second shape slumped against the driver's seat.
    *[Investigate.]
    - This time, you recognize your own body almost immediately. Your arms and neck are twisted in directions they shouldn't be able to go, and your legs are entirely crushed from the impact of the apparent crash that left you in this state. One hand still clutches the steering wheel limply, and it sports an identical bronze ring to the one you found outside.
    You search for more bodies, more clues. How did this happen?
    That question answers itself quickly. From a ditch beside the road, the some type of animal begins to moan.
    *[Approach.]
    - As you walk towards it, the animal's bones begin to crack under its fur. It grows in size, slowly and excruciatingly, until it is a hulking, gruesome beast.
    *[Attack.]
    -> roadkill
    
    === roadkill ===
    Finally defeating the monster, its body melts into the ground, leaving a manhole glowing with familiar light.
    *[Go through the manhole.]
    ~ level = 4
    -> theVoid
    
   
    
=== levelFour ===
You step into the hospital once more, this time into a nondescript hallway. Save for minute signs of wear and tear, the color of the walls is the only difference between now and decades before.
*[Walk.]
- Making your way down, you realize that every door available to you is locked. Up ahead, a door leading into a patient room stands ajar.
*[Enter the room.]
-> hospital_death

    === hospital_death ===
    The scene before you becomes clear immediately: you are dying. And this time, it's not in a way you can save yourself from. Every story must have an ending. In the small space, there sits a shadow, who has pulled up a chair next to the bed where your pody lies. At the foot, there is a bouquet of daisies in a paper cup. There is a not attached to them.
    - (choose)
    * [Read the note.]->note
    * [Talk to the shadow.]->kid1
    * -> DEATH
    - (note) 
    The note reads as follows:
    <i>Mom—
    <i>I'm so sorry that I haven't been able to see you recently, but I've been swamped. Please call when you get a chance. I love you.
    The name and signature on the bottom are redacted, and this time you have no flashlight to aid you.
    * [Set it down.]
    ->choose
    
    - (kid1) When you speak to them, they refer to the body on the bed as if the words are coming from her mouth. You ask who they are. 
    <i>"You don't remember today? That's okay, mom. I'll still keep visiting, as long as you're around."</i>
    *[Continue.]
    You tell them that it might not be much longer. You can feel the essence of death creeping into you, weighing your sould down. Every second is a hurdle.
    They sigh, and lay their head next to your body. <i>"I want you to know that you were loved. And we'll remember. All of the people you cared about."</i> They stay there for several moments.
    ->choose
    
    === DEATH ===
    * [Lie down in bed.]
    At this moment, your body and sould are together once again, for the last time. You feel <i>tired</i>.
    Impressed at how far you've gotten, and fulfilled in the life you led, you smile as you close your eyes. Your child holds your hand tight as your vision fades into pure blackness.
        -> END
 
    
    
    
    
    
    
