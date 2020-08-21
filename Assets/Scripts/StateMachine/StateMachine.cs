using System;
using System.Collections.Generic;


public class StateMachine
{
    private IState _currentState;
    private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();
    private List<Transition> _currentTransitions = new List<Transition>();
    private List<Transition> _anyTransitions = new List<Transition>();
    private static List<Transition> EmptyTransitions = new List<Transition>(0);

    public void Tick()
    {
        // ser etter en transition
        var transition = GetTransition();
        //hvis den får en transition, setter den state til transitions destinasjon ("To").
        if (transition != null)
            SetState(transition.To);

        //Statemachine sier til current state "to Tick".
        _currentState?.Tick();
    }



    public void SetState(IState state)
    {
        //is new state same as current? Hvis det så bailer vi bare.
        if (state == _currentState)
            return;

        //if we have a previous state - call OnExit on that state.
        _currentState?.OnExit();
        //set currentState to the state that is passed in.
        _currentState = state;

        //hey oppslagsverk. gi meg listen til _currentstate og dytt den inn i _currentTransitions.
        _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions);

        //hvis det ikke er noen liste der så bare gi meg EmptyTransitions.
        if (_currentTransitions == null)
            _currentTransitions = EmptyTransitions;

        _currentState.OnEnter();
    }

    public void AddTransition(IState from, IState to, Func<bool> predicate)
    {
        //vi prøver å få listen med transitions for den aktuelle state ("from"). if(vi sjekker om key i _transitions er lik from og putter verdien i transitions)
        if (_transitions.TryGetValue(from.GetType(), out var transitions) == false)
        {
            //Hvis vi verdien ikke er lik (ikke samme key)
            //En "Transition" inneholder navnet på state(s?) den kan gå til og bool(s?) som må være sann for at det skal skje.
            transitions = new List<Transition>();
            _transitions[from.GetType()] = transitions;
        }

        //her legger vi til listen ("transitions) i oppslagsverket.
        transitions.Add(item: new Transition(to, predicate));
    }

    //AnyTransitions er transitions som kan bli utført uansett hvilken state man er i.
    public void AddAnyTransition(IState state, Func<bool> predicate)
    {
        _anyTransitions.Add(item: new Transition(state, predicate));
    }


    private class Transition
    {
        //en trigger som er sann hvis conditions er sann - utløser for transition
        public Func<bool> Condition { get; }
        //Den aktuelle IState (den aktuelle state)
        public IState To { get; }

        //En constructor
        public Transition(IState to, Func<bool> condition)
        {
            To = to;
            Condition = condition;
        }
    }

    private Transition GetTransition()
    {
        //loop igjennom alle _anyTransitions - de som kan slå inn i alle states.
        foreach (var transition in _anyTransitions)
            //hvis transitions == true - return denne transition - det er denne som er valid.
            if (transition.Condition())
                return transition;

        //etter at vi har sjekke om det er noen aktuelle anyTransitions ser vi etter vanlige transitions.
        foreach (var transition in _currentTransitions)
            if (transition.Condition())
                return transition;

        return null;
    }
}

