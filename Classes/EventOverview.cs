using System;
using System.Collections.Generic;

namespace _2.semEksamenProjekt
{
    public class EventOverview
    {
        public List<Event> AllEvents;

        // constructor
        public EventOverview()
        {
            AllEvents = new List<Event>();
        }
        //accessor, returnerer, funktionsnavn og (parameter). Hvad har denne funktion brug for, for at kunne udføre handlingen.
        public List<Event> FilterByTag(string tag)
        {
            List<Event> result = new List<Event>();
            //foreach er mindre stabil at bruge i forhold til for - loops.
            foreach (Event e in AllEvents) //Vi skal kigge alle event igennem i listen. Klasse, lokal variabelnavn, in er en del af foreach loop, AllEvents listen
            {
                if (e.tags != null && e.tags.Contains(tag)) //Hvis der er et tag, så skal eventet  
                    result.Add(e); 
            }

            return result; //Tilføjer resultatet retur til metoden
        }
    }
}
