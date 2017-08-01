using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLoader : MonoBehaviour {

    private EventList eventList;
    private Effect[] evOpEff;
    private int[] evOpNumChange;
    private Event nEvent;
    private EventOption evOp1;
    private EventOption evOp2;
    private EventOption evOp3;

    // Use this for initialization
    void Start() {
        eventList = gameObject.GetComponent<EventList>();

        //Event 0
        evOpEff = new Effect[] { new MoraleEffect() };
        evOpNumChange = new int[] { 1 };
        evOp1 = new EventOption("1. Thanks. Let's get to work. - Gain " + evOpNumChange[0] + " morale", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "Good morning, Captain!",
            "Welcome back from cryosleep. My name's William and I'll be your assistant. I'm in charge of reporting to you all the events that happen and to send out the orders to execute your decisions. I'll be honest with you; the situation is grim. The last Captain's shift was gruesome. He did his best, but I'm not sure we have enough to get to our destination. We're getting chased by some kind of alien race, we're running out of power, the crew's morale is getting low and those that are out of their pods are getting a bit unruly. Your shift was next on the list. I think you might have just been given the short end of the stick.\nI'd avise you stay a while on each system before warping to the next destination to let our pilots and miners try and gather some resources. Though I'd imagine something might happen if you stay too long.\nAnyway, let's just try to do the best with what he have, ok? I look forward to working with you, Captain.",
            new EventOption[] { evOp1 },
            true
            );
        eventList.addEvent(nEvent);

        //Event 1
        evOpEff = new Effect[] { new PowerEffect() };
        evOpNumChange = new int[] { -15 };
        evOp1 = new EventOption("1.Divert power to engines and dodge that volley! - Effect: " + evOpNumChange[0] + " power", evOpEff, evOpNumChange, 2);

        evOpEff = new Effect[] { new PowerEffect() };
        evOpNumChange = new int[] { -10 };
        evOp2 = new EventOption("2.Divert power to shields and try to dodge it! - Effect: " + evOpNumChange[0] + " power", evOpEff, evOpNumChange, 3);

        evOpEff = new Effect[] { new PowerEffect() };
        evOpNumChange = new int[] { 0 };
        evOp3 = new EventOption("3. We have to take this hit... - Effect: " + evOpNumChange[0] + " power", evOpEff, evOpNumChange, 4);

        nEvent = new Event(
            "Volley from hostile aliens",
            "Our jump didn't bring us as far as we intended and so the Gazorpazorps got close enough to launch a volley at us.\nWe can still do something about this. What is your call, Captain?",
            new EventOption[] { evOp1, evOp2, evOp3 },
            false
            );
        eventList.addEvent(nEvent);

        //Event 2
        evOpEff = new Effect[] { new MoraleEffect() };
        evOpNumChange = new int[] { 1 };
        evOp1 = new EventOption("1. Nice! - Gain " + evOpNumChange[0] + " morale", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "Dodged it!",
            "It took us a bit of extra power, but your crew managed to gracefully pilot their way out of the Gazorpazorps' attack and got us to a safe distance. The only injury is their pride.",
            new EventOption[] { evOp1 },
            true
            );
        eventList.addEvent(nEvent);

        //Event 3
        evOpEff = new Effect[] { new LivesEffect(1000, 3000), new MoraleEffect() };
        evOpNumChange = new int[] { ((LivesEffect)evOpEff[0]).getRandomNum(), -2 };
        evOp1 = new EventOption("1. Treat the wounded and clean the dead. We'll mourn the loss later. We need to keep moving before they catch up to us again. - Effect: " + ((LivesEffect)evOpEff[0]).Min + " to " + ((LivesEffect)evOpEff[0]).Max + " people, " + evOpNumChange[1] + " morale, [positive thing]", evOpEff, evOpNumChange, -2);

        evOpEff = new Effect[] { new LivesEffect(1000, 3000), new MoraleEffect() };
        evOpNumChange = new int[] { ((LivesEffect)evOpEff[0]).getRandomNum(), -1 };
        evOp2 = new EventOption("2. Treat the wounded. We'll hold a proper funeral tonight - Effect: lose " + ((LivesEffect)evOpEff[0]).Min + " to " + ((LivesEffect)evOpEff[0]).Max + " people, " + evOpNumChange[1] + " morale.", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "The damage was mitigated",
            "We couldn't avoid getting hit a few times, but the damage was a lot less severe than it could have been thanks to our shields. But the damage still killed some people.",
            new EventOption[] { evOp1, evOp2 },
            true
            );
        eventList.addEvent(nEvent);

        //Event 4
        evOpEff = new Effect[] { new LivesEffect(5000, 10000), new MoraleEffect(), new PowerEffect() };
        evOpNumChange = new int[] { ((LivesEffect)evOpEff[0]).getRandomNum(), -2, -5 };
        evOp1 = new EventOption("1. So do I... - Effect: lose " + ((LivesEffect)evOpEff[0]).Min + " to " + ((LivesEffect)evOpEff[0]).Max + " people, " + evOpNumChange[1] + " morale, " + evOpNumChange[2] + " power", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "That hurt...",
            "We tried to steer away from some of hit, but we took the brunt of the volley. Our shields didn't hold and the hull took some damage. Hundreds of our passengers died and some of our facilities took severe damage that we're going to need to repair. I hope you were certain about this decision, Captain.",
            new EventOption[] { evOp1 },
            true
            );
        eventList.addEvent(nEvent);

        //Event 5
        evOpEff = new Effect[] { new PowerEffect() };
        evOpNumChange = new int[] { 30 };
        evOp1 = new EventOption("1. We need that power. Take as much as we can. - Gain " + evOpNumChange[0] + " power", evOpEff, evOpNumChange, 6);

        evOpEff = new Effect[] { new PowerEffect() };
        evOpNumChange = new int[] { 15 };
        evOp2 = new EventOption("2. Give the miners a timeframe to gather what they can. - Gain " + evOpNumChange[0] + " power.", evOpEff, evOpNumChange, -2);

        evOpEff = new Effect[] { };
        evOpNumChange = new int[] { };
        evOp3 = new EventOption("3. The integrity of the ship's systems is more important than some extra power, we can do without it.", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "A boon...?",
            "Our scanners seem to be showing a rather large cluster of materials we can convert into power for the ship in one of the asteroid belts of this system. We should try and make the most of this as possible, but the star here seems to be unstable. Massive blasts of energy and radiation come out at regular intervals. According to the science team, another one should be coming soon. We can't sustain such a wave at that distance without damage to our ship.",
            new EventOption[] { evOp1, evOp2, evOp3 },
            false
            );
        eventList.addEvent(nEvent);

        //Event 6
        evOpEff = new Effect[] { new LivesEffect(30, 100), new PowerEffect() };
        evOpNumChange = new int[] { ((LivesEffect)evOpEff[0]).getRandomNum(), -5 };
        evOp1 = new EventOption("1. ...Frak. - Effect: " + evOpNumChange[1] + " power, lose " + ((LivesEffect)evOpEff[0]).Min + " to " + ((LivesEffect)evOpEff[0]).Max + " people, ", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "We got greedy",
            "The miners did as asked, but we stayed too long. The sun blasted us and some of the mining ships were fried, along with their pilots. Some of the minerals also got wasted, but we still managed to bring in a decent haul. We'll have to spend some time fixing things though.",
            new EventOption[] { evOp1 },
            true
            );
        eventList.addEvent(nEvent);

        //Event 7
        evOpEff = new Effect[] { };
        evOpNumChange = new int[] { };
        evOp1 = new EventOption("1. Send a few scouts to try to find them.", evOpEff, evOpNumChange, 8);

        evOpEff = new Effect[] { new PowerEffect() };
        evOpNumChange = new int[] { -1};
        evOp2 = new EventOption("2. Blast a system-wide signal with a message of peace to whomever is in here. - Effect: " + evOpNumChange[0] + " power", evOpEff, evOpNumChange, 9);

        evOpEff = new Effect[] { };
        evOpNumChange = new int[] { };
        evOp3 = new EventOption("3. Ignore them. They're probably just some raiders trying to make some money out of the naïve.", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "Distress signal",
            "Communications picked up a signal from some stranded ship somewhere around the area of this system. Something seems to be jamming part of the signal itself though, so we can't pinpoint the location for sure. It's possible it's the ship itself, so they can figure out whether the 'heroes' are well-intended or not before they get seen. We could try and send a signal of our own to try and contact them and convince them to show themselves. Or we can just leave them. It can be a trap as well.",
            new EventOption[] { evOp1, evOp2, evOp3 },
            false
            );
        eventList.addEvent(nEvent);

        //Event 8
        evOpEff = new Effect[] { new PowerEffect() };
        evOpNumChange = new int[] { -1 };
        evOp1 = new EventOption("1. Blast a system-wide signal with a message of peace to whomever is in here. - Effect: " + evOpNumChange[0] + " power", evOpEff, evOpNumChange, 9);

        evOpEff = new Effect[] { };
        evOpNumChange = new int[] { };
        evOp2 = new EventOption("2. Ignore them. They're probably just some raiders trying to make some money out of the naïve.", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "Elusive ones",
            "The scouts didn't find the signal hosts, but they did find the signal source. There's a self-powered antena stuck against one of many debris here. It's been turned off, but we don't know where they are, still.",
            new EventOption[] { evOp1, evOp2 },
            true
            );
        eventList.addEvent(nEvent);

        //Event 9
        evOpEff = new Effect[] { };
        evOpNumChange = new int[] { };
        evOp1 = new EventOption("1. Offer them to come aboard. We have spare rooms we can give them. They population might not like it, but it's the right thing to do.", evOpEff, evOpNumChange, 10);

        evOpEff = new Effect[] { };
        evOpNumChange = new int[] { };
        evOp2 = new EventOption("2. Apologise and be on your way. You can't risk helping someone you can't even see, based on a single response.", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "They speak",
            "The signal hosts responded to your message with another of their own. You still can't quite tell where they are, but their message comes in a rather garbled form. Communications managed to understand the gist of it. There are only two ships. Their FTL drives are destroyed and they have no way to fix them; they've been here for a while and really need the help, and the previous visit they got was from a group of raiders who would have killed them if they had managed to find their location so that's why they're hiding.\nI don't know, Captain, I'm not sure we can trust them, but at the same time, their plea for help seems honest.",
            new EventOption[] { evOp1, evOp2 },
            true
            );
        eventList.addEvent(nEvent);

        //Event 10
        evOpEff = new Effect[] { new LivesEffect(50, 100), new PowerEffect(), new MoraleEffect() };
        evOpNumChange = new int[] { ((LivesEffect)evOpEff[0]).getRandomNum(), 15, -1};
        evOp1 = new EventOption("1. Hopefully they won't cause trouble - Gain " + ((LivesEffect)evOpEff[0]).Min + " to " + ((LivesEffect)evOpEff[0]).Max + " people, gain " + evOpNumChange[1] + " power, " + evOpNumChange[2] + " morale ", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "They grumble, but don't complain",
            "As you thought, the people in the ship weren't exactly thrilled about it. Some of the more conservative folk even went as far as question the decision out loud, but soon resigned to just grumbling amongst themselves. The aliens themselves though, were ecstatic. They needed some adapting, but they thanked you profusely for your kindness and offered you tips on places around the area with rich materials you can use for power.",
            new EventOption[] { evOp1 },
            true
            );
        eventList.addEvent(nEvent);

        //Event 11
        evOpEff = new Effect[] { };
        evOpNumChange = new int[] { };
        evOp1 = new EventOption("1. Send an away team and try to strike a deal with them.", evOpEff, evOpNumChange, 12);

        evOpEff = new Effect[] { };
        evOpNumChange = new int[] { };
        evOp2 = new EventOption("2. Screw them. Set up a quick outpost and get the miners to work. If they attack, kill on sight.", evOpEff, evOpNumChange, 13);

        evOpEff = new Effect[] { };
        evOpNumChange = new int[] { };
        evOp3 = new EventOption("3. Leave them alone. We shouldn't mess with the natural progess and we don't need the extra power.", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "This planet has life!",
            "It may not be habitable for us, but this planet holds life. It's primitive life, but life nonetheless. The science team tells us that they seem to be on the equivalent of a Bronze Age. Here lies the problem though, the material they're using to make their tools also is also extremely efficient when fed into our power source. If we try to harvest it, it's impossible to avoid contact. What do you want to do, Captain?",
            new EventOption[] { evOp1, evOp2, evOp3 },
            false
            );
        eventList.addEvent(nEvent);

        //Event 12
        evOpEff = new Effect[] { new PowerEffect() };
        evOpNumChange = new int[] { 35 };
        evOp1 = new EventOption("1. Wonderful! A point for intergalactic space diplomacy! - Gain " + evOpNumChange[0] + " power", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "I think it worked...?",
            "We touched down and made contact. They were suspicious and aggressive at first, but their crude weapons could not do anything to us and they eventually calmed down when we showed we were not hostile.\nCommunicating was hard, but after a day of attempted negotiations and a lot of curiosity from the natives, they understood what we wanted.\nWe offered knicknacks and basic gadgets in return and, after a few days, we got a pretty considerable amount of mining done.",
            new EventOption[] { evOp1 },
            true
            );
        eventList.addEvent(nEvent);

        //Event 13
        evOpEff = new Effect[] { new PowerEffect() };
        evOpNumChange = new int[] { 20 };
        evOp1 = new EventOption("1. The men are tired, but at least we got what we wanted. - Gain " + evOpNumChange[0] + " power", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "They made us work for it",
            "We touched down and immediately got to work. The natives were suspicious and aggressive and never let go. Our technology made it so they couldn't really hurt us much, so long as we paid attention. We had to keep people working around the clock as watchguards as the aliens tried to attack us at every opportunity they got.",
            new EventOption[] { evOp1 },
            true
            );
        eventList.addEvent(nEvent);

        //Final Speech
        evOpEff = new Effect[] { new LivesEffect(0, 0), new MoraleEffect(), new PowerEffect() };
        evOpNumChange = new int[] { ((LivesEffect)evOpEff[0]).getRandomNum(), 10, 1000 };
        evOp1 = new EventOption("1. I'm... afraid so, William. It... it was an honor to serve with everyone on this ship. I'm ready to give my final speech...", evOpEff, evOpNumChange, -3);

        evOpEff = new Effect[] { new PowerEffect() };
        evOpNumChange = new int[] { 0 };
        evOp2 = new EventOption("2. ...No! I've changed my mind. We can still do this!", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "Your final speech",
            "Do you... really think we're doomed? I-I... I can patch you to the rest of the ship... so you can give everyone the news but... I... You're basically telling everyone that we're dead! Have you... have you really lost all hope, Captain?",
            new EventOption[] { evOp1, evOp2 },
            false
            );
        eventList.addEvent(nEvent);
    }
}
