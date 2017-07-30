using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLoader : MonoBehaviour {

    [SerializeField]
    private EventList eventList;
    private Effect[] evOpEff;
    private int[] evOpNumChange;
    private Event nEvent;
    private EventOption evOp1;
    private EventOption evOp2;
    private EventOption evOp3;

    // Use this for initialization
    void Start() {

        //Event 1
        evOpEff = new Effect[] { new PowerEffect() };
        evOpNumChange = new int[] { -1 };
        evOp1 = new EventOption("1.Divert power to engines and dodge that volley! - Lose " + evOpNumChange[0] + " power", evOpEff, evOpNumChange, 2);

        evOpEff = new Effect[] { new PowerEffect() };
        evOpNumChange = new int[] { -1 };
        evOp2 = new EventOption("2.Divert power to shields and try to dodge it! - Lose " + evOpNumChange[0] + " power", evOpEff, evOpNumChange, 3);

        evOpEff = new Effect[] { new PowerEffect() };
        evOpNumChange = new int[] { 0 };
        evOp3 = new EventOption("3. We have to take this hit... - Lose " + evOpNumChange[0] + " power", evOpEff, evOpNumChange, 4);

        nEvent = new Event(
            "Volley from hostile aliens",
            "Our jump didn't bring us as far as we intended and so the [ENEMIES] got close enough to launch a volley at us.\nWe can still do something about this. What is your call, Captain?",
            new EventOption[] { evOp1, evOp2, evOp3 }
            );
        eventList.addEvent(nEvent);

        //Event 2
        evOpEff = new Effect[] { new MoraleEffect() };
        evOpNumChange = new int[] { -1 };
        evOp1 = new EventOption("1. Nice! - Gain " + evOpNumChange[0] + " morale", evOpEff, evOpNumChange, -1);

        nEvent = new Event(
            "Dodged it!",
            "It took us a bit of extra power, but your crew managed to gracefully pilot their way out of the [ENEMIES] attack and got us to a safe distance. The only injury is the [ENEMIES] pride.",
            new EventOption[] { evOp1 }
            );
        eventList.addEvent(nEvent);

        //Event 3
        evOpEff = new Effect[] { new LivesEffect(-1, 1), new MoraleEffect() };
        evOpNumChange = new int[] { ((LivesEffect)evOpEff[0]).getRandomNum(), -1 };
        evOp1 = new EventOption("1. Treat the wounded and clean the dead. We'll mourn the loss later. We need to keep moving before they catch up to us again. - Lose " + ((LivesEffect)evOpEff[0]).Min + " to " + ((LivesEffect)evOpEff[0]).Max + "people, lose " + evOpNumChange[1] + " morale, [positive thing]", evOpEff, evOpNumChange, -1);

        evOpEff = new Effect[] { new LivesEffect(-1, 1), new MoraleEffect() };
        evOpNumChange = new int[] { ((LivesEffect)evOpEff[0]).getRandomNum(), -1 };
        evOp2 = new EventOption("2. Treat the wounded. We'll hold a proper funeral tonight - ose " + ((LivesEffect)evOpEff[0]).Min + " to " + ((LivesEffect)evOpEff[0]).Max + "people, lose " + evOpNumChange[1] + " morale.", evOpEff, evOpNumChange, -1);

        nEvent = new Event(
            "The damage was mitigated",
            "We couldn't avoid getting hit a few times, but the damage was a lot less severe than it could have been thanks to our shields. But the damage still killed some people.",
            new EventOption[] { evOp1, evOp2 }
            );
        eventList.addEvent(nEvent);
    }
}
