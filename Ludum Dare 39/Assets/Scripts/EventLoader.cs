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
            "Our jump didn't bring us as far as we intended and so the [ENEMIES] got close enough to launch a volley at us.\nWe can still do something about this. What is your call, Captain?",
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
            "It took us a bit of extra power, but your crew managed to gracefully pilot their way out of the [ENEMIES] attack and got us to a safe distance. The only injury is the [ENEMIES] pride.",
            new EventOption[] { evOp1 },
            true
            );
        eventList.addEvent(nEvent);

        //Event 3
        evOpEff = new Effect[] { new LivesEffect(1000, 3000), new MoraleEffect() };
        evOpNumChange = new int[] { ((LivesEffect)evOpEff[0]).getRandomNum(), -2 };
        evOp1 = new EventOption("1. Treat the wounded and clean the dead. We'll mourn the loss later. We need to keep moving before they catch up to us again. - Effect: " + ((LivesEffect)evOpEff[0]).Min + " to " + ((LivesEffect)evOpEff[0]).Max + " people, lose " + evOpNumChange[1] + " morale, [positive thing]", evOpEff, evOpNumChange, -2);

        evOpEff = new Effect[] { new LivesEffect(1000, 3000), new MoraleEffect() };
        evOpNumChange = new int[] { ((LivesEffect)evOpEff[0]).getRandomNum(), -1 };
        evOp2 = new EventOption("2. Treat the wounded. We'll hold a proper funeral tonight - Effect: " + ((LivesEffect)evOpEff[0]).Min + " to " + ((LivesEffect)evOpEff[0]).Max + " people, lose " + evOpNumChange[1] + " morale.", evOpEff, evOpNumChange, -2);

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
        evOp1 = new EventOption("1. So do I... - Effect: " + ((LivesEffect)evOpEff[0]).Min + " to " + ((LivesEffect)evOpEff[0]).Max + " people, lose " + evOpNumChange[1] + " morale, lose " + evOpNumChange[2] + " power", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "That hurt...",
            "We tried to steer away from some of hit, but we took the brunt of the volley. Our shields didn't hold and the hull took some damage. Hundreds of our passengers died and some of our facilities took severe damage that we're going to need to repair. I hope you were certain about this decision, Captain.",
            new EventOption[] { evOp1 },
            true
            );
        eventList.addEvent(nEvent);

        //Final Speech
        evOpEff = new Effect[] { new LivesEffect(100000, 100000), new MoraleEffect(), new PowerEffect() };
        evOpNumChange = new int[] { ((LivesEffect)evOpEff[0]).getRandomNum(), -10, -1000 };
        evOp1 = new EventOption("1. I'm... afraid so, William. It... it was an honor to serve with everyone on this ship. I'm ready to give my final speech...", evOpEff, evOpNumChange, -3);

        evOpEff = new Effect[] { new PowerEffect() };
        evOpNumChange = new int[] { 0 };
        evOp2 = new EventOption("2. ...No! I've changed my mind. We can still do this!", evOpEff, evOpNumChange, -2);

        nEvent = new Event(
            "Your final speech",
            "Do you... really think we're doomed? I-I... I can patch you to the rest of the ship... so you can give everyone the news but... I... You're basically telling everyone that we're dead! Have you... have you really lost all hope, Captain?",
            new EventOption[] { evOp1 },
            false
            );

        eventList.addEvent(nEvent);
    }
}
