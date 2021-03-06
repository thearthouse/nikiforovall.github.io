using System;
using System.Collections.Generic;
using Memento;

public class Program {
    public static void Main () {
        (string, int) [] states = {
            ("1", 0),
            ("2", 10),
            ("3", 20),
        };
        Originator originator = new Originator ();
        var caretaker = new Caretaker ();

        originator.State = states[0];
        caretaker.Push (originator.CreateMemento ());
        originator.State = states[1];
        caretaker.Push (originator.CreateMemento ());
        originator.State = states[2];

        originator.SetMemento (caretaker.Pop ());
        Assert.Equal (states[1], originator.State);
        originator.SetMemento (caretaker.Pop ());
        Assert.Equal (states[0], originator.State);
        //Assert.Empty (caretaker);
        TestRunner.Print ();
    }
}
