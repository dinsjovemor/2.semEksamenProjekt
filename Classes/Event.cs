namespace _2.semEksamenProjekt
{
    public class Event
    {
        public int id;  //disse er helt almindelige fields, med deklaration direkte i klassen (og heller ingen get; set; accessors som ved properties) 
        public int? flowId; // tilknyttet flow (null = intet flow)
        public string title; //field med default "tom" værdi
        public string description;
        public List<string> rooms;
        public DateTime start;
        public DateTime end;
        public List<User> teachers;
        public string city = String.Empty; //field deklareret/initialized med en default tom string
        public List<Team> teams = new List<Team>(); //field deklareret med default tomme parametre()
        // FYLDESTGØRENDE FORKLARING: public List<string> tags = new List<string>();
        // Access modifier er valgt som "public", som derfor kan læses/skrives fra udenfor klassen.
        // "List<string>" er typen af variablen.
        // Da "<string>" er udfyldt med "string" og ikke den generiske "T", så skal denne liste specifikt indeholde string-værdier
        // "tags" er et selvvalgt variabelnavn.
        // "=" er assigment operatoren, og hvadend der er på højre side, bliver tillagt "tags".
        // "new List<string>()" er selve objektoprettelsen,
        // "new" allokerer et nyt List<string> objekt i hukommelsen.
        // "()" kalder constructoren (i dette tilfælde parameterløse constructor, som derfor opretter en tom liste)

        // KORT FORKLARING: public List<string> tags = new List<string>(); 
        // Opretter en PUBLIC FIELD kaldet TAGS, 
        // som er en LIST der indeholder STRING, 
        // der INITIALISERES for nu, som en ny (tom) liste
        public List<string> tags = new List<string>(); // I tilfælde af, at det i stedet for field var PROPERTY, 
        // havde det været: List<string> tags { get; set; }

        // tilføjer event til event overviewet
        public void AddEvent(EventOverview overview)
        {
            overview.AllEvents.Add(this);
        }

        // fjerner event fra event overviewet
        public void DeleteEvent(EventOverview overview)
        {
            overview.AllEvents.Remove(this);
        }

        // erstatter et eksisterende event i overviewet med dette events opdaterede værdier
        public void EditEvent(EventOverview overview, Event oldEvent)
        {
            int index = overview.AllEvents.IndexOf(oldEvent);
            if (index >= 0)
            {
                overview.AllEvents[index] = this;
            }
        }
    }
}
