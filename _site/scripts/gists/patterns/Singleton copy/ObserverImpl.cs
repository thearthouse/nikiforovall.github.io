using System;
using System.Collections.Generic;

namespace Observer {
    public class ConcreteObserver : Observer {
        public string State { get; private set; }

        public override void Update (Subject state) {
            State = (state as ConcreteSubject).SubjectState;
        }
    }
}
namespace Observer {
    public class ConcreteSubject : Subject {
        public string SubjectState { get; set; }
    }
}

namespace Observer {
    public abstract class Observer {
        public abstract void Update (Subject state);
    }
}

namespace Observer {
    public abstract class Subject {
        List<Observer> _observers = new List<Observer> ();

        public void Attach (Observer observer) {
            _observers.Add (observer);
        }

        public void Detach (Observer observer) {
            _observers.Remove (observer);
        }

        public void Notify () {
            foreach (var observer in _observers) {
                observer.Update (this);
            }
        }
    }
}
